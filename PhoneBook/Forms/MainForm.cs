using PhoneBook.Classes;
using PhoneBook.Repositorys;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;


namespace PhoneBook
{
    public partial class MainForm : RadForm
    {
        public MainForm()
        {
            InitializeComponent();

            RadMessageBox.ThemeName = ThemeName;
            DepartmentPageView.ViewElement.MouseWheel += ViewElement_MouseWheel;
        }

        private List<Employee> _employeeList;

        public void UpdateEmployeeList()
        {
            static List<Employee> GetEmployeeList()
            {
                if (SqlRepository.HasAdministratorRights)
                {
                    return Properties.Settings.Default.DefaultRepository switch
                    {
                        "GetSqlEmployeeList" => SqlRepository.GetEmployeeList(),
                        "GetSPEmployeeList" => SPRepository.GetEmployeeList(),
                        "GetADEmployeeList" => ADRepository.GetEmployeeList(),
                        _ => throw new NotImplementedException("Не вернуй параметр " + Properties.Settings.Default.DefaultRepository),
                    };
                }
                else
                    return SqlRepository.GetEmployeeList();
            }
            static Employee Normalize(Employee employee)
            {
                employee.Company = string.IsNullOrEmpty(employee.Company) ? "[без названия]" : employee.Company.Replace("&quot;", "\"").Trim();
                employee.Department = string.IsNullOrEmpty(employee.Department) ? "[без названия]" : employee.Department.Replace("&quot;", "\"").Trim();
                return employee;
            }

            _employeeList = GetEmployeeList().Select(x => Normalize(x))
                 .OrderBy(x => x.Company).ThenBy(x => x.Department).ThenBy(x => x.FullName).ToList();

            FindEmployee.Clear();
            CompanyPageView.Pages.Clear();
            _employeeList.GroupBy(x => x.Company).ToList().ForEach(x => CompanyPageView.Pages.Add(new RadPageViewPage(x.Key)));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            AdminMenu.Visibility = SqlRepository.HasAdministratorRights
                ? ElementVisibility.Visible
                : ElementVisibility.Collapsed;

            SelectTheme_Click(Properties.Settings.Default.ColorTheme switch
            {
                "BlueGrayTheme" => BlueGrayTheme,
                "TealTheme" => TealTheme,
                "PinkTheme" => PinkTheme,
                _ => DefaultTheme,
            }, new EventArgs());

            (Properties.Settings.Default.DefaultRepository switch
            {
                "GetADEmployeeList" => GetADEmployeeList,
                "GetSPEmployeeList" => GetSPEmployeeList,
                _ => GetSqlEmployeeList,
            }).ToggleState = ToggleState.On;

            UpdateEmployeeList();
        }
        private void CompanyPageView_SelectedPageChanged(object sender, EventArgs e)
        {
            string WordWarp(string source)
            {
                var words = source.Replace("-", "- ").Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
                string buff = words.FirstOrDefault();
                string result = string.Empty;

                foreach (var word in words.Skip(1))
                    if (TextRenderer.MeasureText(buff + word, DepartmentPageView.Font).Width < 180)
                    {
                        buff += word.Length > 2 && word[0] == '-' ? word : " " + word;
                    }
                    else
                    {
                        result += buff + "\r\n";
                        buff = word;
                    }

                return (result + buff).Trim(new char[] { '\r', '\n', ' ' });
            }

            if (CompanyPageView.SelectedPage != null)
            {
                DepartmentPageView.Pages.Clear();
                _employeeList.Where(x => x.Company == CompanyPageView.SelectedPage.Text).GroupBy(x => x.Department).ToList()
                    .ForEach(x => DepartmentPageView.Pages.Add(new RadPageViewPage(WordWarp(x.Key)) { Tag = x.Key }));
                HeaderDescription.Text = CompanyPageView.SelectedPage.Text;
            }
            else
            {
                CompanyPageView.SelectedPage = null;
                HeaderDescription.Text = string.Empty;
            }
        }
        private void DepartmentPageView_SelectedPageChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FindEmployee.Text))
                return;

            EmployeeListView.Items.Clear();
            if (CompanyPageView.SelectedPage != null && DepartmentPageView.SelectedPage != null)
            {
                EmployeeListView.Items.AddRange(
                _employeeList.Where(x => x.Company == CompanyPageView.SelectedPage.Text
                    && x.Department == DepartmentPageView.SelectedPage.Tag.ToString())
                    .Select(x => new ListViewDataItem(x.SID, new string[] { x.FullName, x.Phone, x.MPersonPhone, x.СorporatePhone, x.Mail, x.Role }))
                    .ToArray());
            }
        }
        private void ViewElement_MouseWheel(object sender, MouseEventArgs e)
        {
            if (DepartmentPageView.SelectedPage != null)
            {
                int index = DepartmentPageView.Pages.IndexOf(DepartmentPageView.SelectedPage);
                DepartmentPageView.SelectedPage = e.Delta > 0
                    ? DepartmentPageView.SelectedPage = DepartmentPageView.Pages[Math.Max(index - 1, 0)]
                    : DepartmentPageView.SelectedPage = DepartmentPageView.Pages[Math.Min(index + 1, DepartmentPageView.Pages.Count - 1)];
            }
            else
            {
                DepartmentPageView.SelectedPage = DepartmentPageView.DefaultPage;
            }
        }
        private void UpdateEmlpoeeList_Click(object sender, EventArgs e)
        {
            UpdateEmployeeList();
        }
        private void UpdatePhoneBook_Click(object sender, EventArgs e)
        {
            using var spImportFrom = new ImportFrom { Owner = this };
            spImportFrom.ShowDialog();
            if (spImportFrom.UpdateReady)
                UpdateEmployeeList();
        }
        private void GetEmployeeList_Click(object sender, EventArgs e)
        {
            if (sender is RadMenuItem menuItem)
            {
                Properties.Settings.Default.DefaultRepository = menuItem.Name;
                Properties.Settings.Default.Save();
                UpdateEmployeeList();

                GetSqlEmployeeList.ToggleState = ToggleState.Off;
                GetADEmployeeList.ToggleState = ToggleState.Off;
                GetSPEmployeeList.ToggleState = ToggleState.Off;
                menuItem.ToggleState = ToggleState.On;
            }
        }
        private void SelectTheme_Click(object sender, EventArgs e)
        {
            if (sender is RadMenuItem menuItem)
            {
                foreach (RadMenuItem item in SelectThemeMenu.Items)
                    item.ToggleState = item.Name == menuItem.Name ? ToggleState.On : ToggleState.Off;

                ThemeResolutionService.ApplicationThemeName = menuItem.Name switch
                {
                    "BlueGrayTheme" => "MaterialBlueGrey",
                    "TealTheme" => "MaterialTeal",
                    "PinkTheme" => "MaterialPink",
                    _ => "Material",
                };
                Properties.Settings.Default.ColorTheme = menuItem.Name;
                Properties.Settings.Default.Save();
            }
        }
        private void FindEmployee_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FindEmployee.Text))
            {
                var findText = FindEmployee.Text.ToLower();

                EmployeeListView.Items.Clear();
                EmployeeListView.Items.AddRange(
                _employeeList.Where(x => x.Contains(findText))
                    .Select(x => new ListViewDataItem(x.SID, new string[] { x.FullName, x.Phone, x.MPersonPhone, x.СorporatePhone, x.Mail, x.Role }))
                    .ToArray());
            }
            else
                DepartmentPageView_SelectedPageChanged(DepartmentPageView, new EventArgs());
        }
        private void ImportToCSVClick(object sender, EventArgs e)
        {
            using var saveDialog = new SaveFileDialog
            {
                Filter = "CSV файл(*.csv)|*.csv|Текстовый файл(*.txt)|*.txt"
            };
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                var employeeProperties = Type.GetType("PhoneBook.Classes.Employee").GetProperties();
                var header = string.Join(";", employeeProperties.Select(x => "\"" + x.Name + "\""));
                var body = string.Join("\r\n", _employeeList.Select(x => string.Join(";", employeeProperties
                    .Select(y => "\"" + y.GetValue(x, null)?.ToString().Replace("\"", "\"\"") + "\""))));

                File.WriteAllText(saveDialog.FileName, header + "\r\n" + body + "\r\n", Encoding.GetEncoding("Windows-1251"));
            }
        }

        private void EmployeeListView_SelectedItemChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FindEmployee.Text) && EmployeeListView.SelectedItem != null)
            {
                var employee = _employeeList.First(x => x.SID == EmployeeListView.SelectedItem.Text);
                CompanyPageView.SelectedPage = CompanyPageView.Pages.FirstOrDefault(x => x.Text == employee.Company);
                DepartmentPageView.SelectedPage = DepartmentPageView.Pages.FirstOrDefault(x => x.Text.Replace("\r\n", "") == employee.Department);
            }
        }
    }
}
