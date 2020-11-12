namespace PhoneBook
{
    partial class ImportFrom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.UserLogin = new Telerik.WinControls.UI.RadTextBox();
            this.UserPassword = new Telerik.WinControls.UI.RadTextBox();
            this.SaveUserAccount = new Telerik.WinControls.UI.RadCheckBox();
            this.UpdateMSSQL = new Telerik.WinControls.UI.RadCheckBox();
            this.UpdateSharePoint = new Telerik.WinControls.UI.RadCheckBox();
            this.SPUpdateSettings = new Telerik.WinControls.UI.RadGroupBox();
            this.MainUpdateSettings = new Telerik.WinControls.UI.RadGroupBox();
            this.StartUpdate = new Telerik.WinControls.UI.RadButton();
            this.LogTextBox = new Telerik.WinControls.UI.RadTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.UserLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaveUserAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpdateMSSQL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpdateSharePoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SPUpdateSettings)).BeginInit();
            this.SPUpdateSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainUpdateSettings)).BeginInit();
            this.MainUpdateSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StartUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // UserLogin
            // 
            this.UserLogin.Location = new System.Drawing.Point(26, 24);
            this.UserLogin.Name = "UserLogin";
            this.UserLogin.NullText = "Введите логин";
            this.UserLogin.Size = new System.Drawing.Size(242, 36);
            this.UserLogin.TabIndex = 0;
            this.UserLogin.ThemeName = "Material";
            // 
            // UserPassword
            // 
            this.UserPassword.Location = new System.Drawing.Point(274, 24);
            this.UserPassword.Name = "UserPassword";
            this.UserPassword.NullText = "Введите пароль";
            this.UserPassword.PasswordChar = '*';
            this.UserPassword.Size = new System.Drawing.Size(243, 36);
            this.UserPassword.TabIndex = 1;
            this.UserPassword.ThemeName = "Material";
            // 
            // SaveUserAccount
            // 
            this.SaveUserAccount.AutoSize = false;
            this.SaveUserAccount.Location = new System.Drawing.Point(26, 67);
            this.SaveUserAccount.Name = "SaveUserAccount";
            this.SaveUserAccount.Size = new System.Drawing.Size(443, 19);
            this.SaveUserAccount.TabIndex = 7;
            this.SaveUserAccount.Text = "Сохранить учетные данные?";
            this.SaveUserAccount.ThemeName = "Material";
            // 
            // UpdateMSSQL
            // 
            this.UpdateMSSQL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UpdateMSSQL.Location = new System.Drawing.Point(26, 30);
            this.UpdateMSSQL.Name = "UpdateMSSQL";
            this.UpdateMSSQL.Size = new System.Drawing.Size(241, 19);
            this.UpdateMSSQL.TabIndex = 8;
            this.UpdateMSSQL.Text = "Обновить данные базы MSSQL ";
            this.UpdateMSSQL.ThemeName = "Material";
            this.UpdateMSSQL.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // UpdateSharePoint
            // 
            this.UpdateSharePoint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UpdateSharePoint.Location = new System.Drawing.Point(26, 55);
            this.UpdateSharePoint.Name = "UpdateSharePoint";
            this.UpdateSharePoint.Size = new System.Drawing.Size(222, 19);
            this.UpdateSharePoint.TabIndex = 9;
            this.UpdateSharePoint.Text = "Обновить данные SharePoint";
            this.UpdateSharePoint.ThemeName = "Material";
            this.UpdateSharePoint.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.UpdateSharePoint.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.UpdateSharePoint_ToggleStateChanged);
            // 
            // SPUpdateSettings
            // 
            this.SPUpdateSettings.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.SPUpdateSettings.Controls.Add(this.UserLogin);
            this.SPUpdateSettings.Controls.Add(this.UserPassword);
            this.SPUpdateSettings.Controls.Add(this.SaveUserAccount);
            this.SPUpdateSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.SPUpdateSettings.HeaderText = "Доступ к srv-shpf01 (PowerShell)";
            this.SPUpdateSettings.Location = new System.Drawing.Point(0, 85);
            this.SPUpdateSettings.Name = "SPUpdateSettings";
            this.SPUpdateSettings.Size = new System.Drawing.Size(529, 93);
            this.SPUpdateSettings.TabIndex = 10;
            this.SPUpdateSettings.Text = "Доступ к srv-shpf01 (PowerShell)";
            this.SPUpdateSettings.ThemeName = "Material";
            // 
            // MainUpdateSettings
            // 
            this.MainUpdateSettings.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.MainUpdateSettings.Controls.Add(this.UpdateMSSQL);
            this.MainUpdateSettings.Controls.Add(this.UpdateSharePoint);
            this.MainUpdateSettings.Controls.Add(this.StartUpdate);
            this.MainUpdateSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.MainUpdateSettings.HeaderText = "Список хранилищ для обновления";
            this.MainUpdateSettings.Location = new System.Drawing.Point(0, 0);
            this.MainUpdateSettings.Name = "MainUpdateSettings";
            this.MainUpdateSettings.Size = new System.Drawing.Size(529, 85);
            this.MainUpdateSettings.TabIndex = 11;
            this.MainUpdateSettings.Text = "Список хранилищ для обновления";
            this.MainUpdateSettings.ThemeName = "Material";
            // 
            // StartUpdate
            // 
            this.StartUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.StartUpdate.Location = new System.Drawing.Point(274, 27);
            this.StartUpdate.Name = "StartUpdate";
            this.StartUpdate.Size = new System.Drawing.Size(243, 47);
            this.StartUpdate.TabIndex = 4;
            this.StartUpdate.Text = "Начать обновление";
            this.StartUpdate.ThemeName = "Material";
            this.StartUpdate.Click += new System.EventHandler(this.StartUpdate_Click);
            // 
            // LogTextBox
            // 
            this.LogTextBox.AutoSize = false;
            this.LogTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogTextBox.Location = new System.Drawing.Point(0, 178);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogTextBox.Size = new System.Drawing.Size(529, 262);
            this.LogTextBox.TabIndex = 13;
            this.LogTextBox.ThemeName = "Material";
            // 
            // ImportFrom
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(529, 440);
            this.Controls.Add(this.LogTextBox);
            this.Controls.Add(this.SPUpdateSettings);
            this.Controls.Add(this.MainUpdateSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ImportFrom";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Обновление телефонной книги";
            this.ThemeName = "Material";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SPImportFrom_FormClosing);
            this.Load += new System.EventHandler(this.SPImportFrom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UserLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaveUserAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpdateMSSQL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpdateSharePoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SPUpdateSettings)).EndInit();
            this.SPUpdateSettings.ResumeLayout(false);
            this.SPUpdateSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainUpdateSettings)).EndInit();
            this.MainUpdateSettings.ResumeLayout(false);
            this.MainUpdateSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StartUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBox UserLogin;
        private Telerik.WinControls.UI.RadTextBox UserPassword;
        private Telerik.WinControls.UI.RadCheckBox SaveUserAccount;
        private Telerik.WinControls.UI.RadCheckBox UpdateMSSQL;
        private Telerik.WinControls.UI.RadCheckBox UpdateSharePoint;
        private Telerik.WinControls.UI.RadGroupBox SPUpdateSettings;
        private Telerik.WinControls.UI.RadGroupBox MainUpdateSettings;
        private Telerik.WinControls.UI.RadButton StartUpdate;
        private Telerik.WinControls.UI.RadTextBox LogTextBox;
    }
}
