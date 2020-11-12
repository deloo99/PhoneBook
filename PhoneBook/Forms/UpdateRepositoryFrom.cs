using PhoneBook.Classes;
using PhoneBook.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace PhoneBook
{
    public partial class ImportFrom : RadForm
    {
        public ImportFrom()
        {
            InitializeComponent();
            CompliteChecker.Tick += CompliteChecker_Tick;
        }

        private readonly Timer CompliteChecker = new Timer { Interval = 100 };

        public bool UpdateReady { get; private set; }

        private void CompliteChecker_Tick(object sender, EventArgs e)
        {
            if (UpdateReady)
            {
                MainUpdateSettings.Visible = true;
                SPUpdateSettings.Visible = UpdateSharePoint.Checked;
                CompliteChecker.Stop();
            }
        }
        private void SPImportFrom_Load(object sender, EventArgs e)
        {
            Owner.Hide();
            UserLogin.Text = Properties.Settings.Default.UserLogin;
            UserPassword.Text = Cryptography.DecryptPassword(Properties.Settings.Default.UserLogin, Properties.Settings.Default.UserPassword);

            UpdateMSSQL.Checked = Properties.Settings.Default.UpdateMSSQL;
            UpdateSharePoint.Checked = Properties.Settings.Default.UpdateSharePoint;
            SaveUserAccount.Checked = Properties.Settings.Default.SaveUserAccount;
        }
        private void SPImportFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CompliteChecker.Enabled)
            {
                e.Cancel = true;
            }
            else
            {
                if (SaveUserAccount.Checked)
                {
                    Properties.Settings.Default.UserLogin = UserLogin.Text;
                    Properties.Settings.Default.UserPassword = Cryptography.EncryptPassword(UserLogin.Text, UserPassword.Text);
                }
                else
                {
                    Properties.Settings.Default.UserLogin = string.Empty;
                    Properties.Settings.Default.UserPassword = string.Empty;
                }
                Properties.Settings.Default.UpdateMSSQL = UpdateMSSQL.Checked;
                Properties.Settings.Default.UpdateSharePoint = UpdateSharePoint.Checked;
                Properties.Settings.Default.SaveUserAccount = SaveUserAccount.Checked;
                Properties.Settings.Default.Save();

                Owner.Show();
            }
        }
        private void UpdateSharePoint_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            SPUpdateSettings.Visible = UpdateSharePoint.Checked;
        }
        private void StartUpdate_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.UserLogin = UserLogin.Text;
            Properties.Settings.Default.UserPassword = Cryptography.EncryptPassword(UserLogin.Text, UserPassword.Text);

            LogTextBox.Clear();
            MainUpdateSettings.Visible = false;
            SPUpdateSettings.Visible = false;
            UpdateReady = false;
            CompliteChecker.Start();

            new Task(() =>
            {
                void AppendLog(string text)
                    => Invoke(new Action<string>(LogTextBox.AppendText), new object[] { text });

                try
                {
                    if (UpdateSharePoint.Checked || UpdateMSSQL.Checked)
                    {
                        AppendLog("Получение списка сортрудников Active Directory ");
                        var adEmployeeList = ADRepository.GetEmployeeList();
                        AppendLog($"({adEmployeeList.Count} записей)\r\n\r\n");

                        if (UpdateMSSQL.Checked)
                        {
                            AppendLog("Получение списка сортрудников MSSQL ");
                            var sqlEmployeeList = SqlRepository.GetEmployeeList();
                            AppendLog($"({sqlEmployeeList.Count} записей)\r\n");

                            AppendLog($"Поиск различий Active Directory и MSSQL\r\n");
                            (var createEmployeeList, var updateEmployeeList, var deleteEmployeeList) = DefiningDifferences(adEmployeeList, sqlEmployeeList);
                            AppendLog($"\tДобавить: {createEmployeeList.Count}\r\n"
                                + $"\tИзменить: {updateEmployeeList.Count}\r\n"
                                + $"\tУдалить: {deleteEmployeeList.Count}\r\n");

                            AppendLog($"Обновление данных MSSQL ");
                            SqlRepository.UpdateEmployeeList(createEmployeeList, updateEmployeeList, deleteEmployeeList);
                            AppendLog($"(Выполнено)\r\n\r\n");
                        }

                        if (UpdateSharePoint.Checked)
                        {
                            AppendLog("Получение списка сортрудников SharePoint ");
                            var spEmployeeList = SPRepository.GetEmployeeList();
                            AppendLog($"({spEmployeeList.Count} записей)\r\n");

                            AppendLog($"Поиск различий Active Directory и SharePoint:\r\n");
                            (var createEmployeeList, var updateEmployeeList, var deleteEmployeeList) = DefiningDifferences(adEmployeeList, spEmployeeList);
                            AppendLog($"\tДобавить: {createEmployeeList.Count}\r\n"
                                + $"\tИзменить: {updateEmployeeList.Count}\r\n"
                                + $"\tУдалить: {deleteEmployeeList.Count}\r\n");

                            AppendLog($"Обновление данных SharePoint ");
                            SPRepository.UpdateEmployeeList(createEmployeeList, updateEmployeeList, deleteEmployeeList);
                            AppendLog($"(Выполнено)\r\n\r\n");
                        }
                    }
                    else
                    {
                        AppendLog("Выполнение прервано, так как не указано ни одного хранилища данных.\r\n\r\n");
                    }
                }
                catch (Exception ex)
                {
                    AppendLog("Ошибка при выполнении:\r\n\t" + ex.Message + "\r\n\r\n" + "Трассировка: \r\n\t" + ex.StackTrace);
                }
                finally
                {
                    AppendLog($"Выполнение завершено\r\n");
                    UpdateReady = true;
                }
            }).Start();
        }
        private (List<Employee> createEmlpoyeeList, List<Employee> updateEmployeeList, List<Employee> deleteEmployeeList) DefiningDifferences
            (List<Employee> newEmployeeList, List<Employee> oldEmployeeList)
        {
            var adActualEmployeeList = newEmployeeList.Where(x => !(oldEmployeeList.FirstOrDefault(y => y.SID == x.SID)?.IsDispose) ?? true).ToList();
            var spActualEmployeeList = adActualEmployeeList.Select(x => oldEmployeeList.FirstOrDefault(y => y.SID == x.SID)).Where(x => x != null).ToList();
            var deleteEmployeeList = oldEmployeeList.Except(spActualEmployeeList).Where(x => x.ID > 0).ToList();
            var createEmlpoyeeList = adActualEmployeeList.Where(x => spActualEmployeeList.FirstOrDefault(y => y.SID == x.SID) == null).ToList();
            var updateEmployeeList = adActualEmployeeList.Except(createEmlpoyeeList).Where(x => spActualEmployeeList.FirstOrDefault(y => y.EqualsWithoutID(x)) == null).ToList();
            updateEmployeeList.ForEach(x => x.ID = spActualEmployeeList.Find(y => y.SID == x.SID).ID);

            return (createEmlpoyeeList, updateEmployeeList, deleteEmployeeList);
        }
    }
}
