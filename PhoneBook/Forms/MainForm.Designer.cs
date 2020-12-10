namespace PhoneBook
{
    partial class MainForm
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
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn7 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "ФИО");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn8 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 1", "Внутренний");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn9 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 2", "Городской");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn10 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 3", "Мобильный");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn11 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 4", "Электронная почта");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn12 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 5", "Должность");
            Telerik.WinControls.UI.ListViewDataItem listViewDataItem2 = new Telerik.WinControls.UI.ListViewDataItem("ListViewItem 1");
            this.materialTheme1 = new Telerik.WinControls.Themes.MaterialTheme();
            this.CompanyPageView = new Telerik.WinControls.UI.RadPageView();
            this.DepartmentPageView = new Telerik.WinControls.UI.RadPageView();
            this.EmployeeListView = new Telerik.WinControls.UI.RadListView();
            this.HeaderPanel = new Telerik.WinControls.UI.RadPanel();
            this.HeaderDescription = new Telerik.WinControls.UI.RadLabel();
            this.materialTealTheme1 = new Telerik.WinControls.Themes.MaterialTealTheme();
            this.materialBlueGreyTheme1 = new Telerik.WinControls.Themes.MaterialBlueGreyTheme();
            this.UpdateEmployeList = new Telerik.WinControls.UI.RadMenuItem();
            this.AdminMenu = new Telerik.WinControls.UI.RadMenuItem();
            this.UpdatePhoneBook = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuSeparatorItem1 = new Telerik.WinControls.UI.RadMenuSeparatorItem();
            this.GetSqlEmployeeList = new Telerik.WinControls.UI.RadMenuItem();
            this.GetSPEmployeeList = new Telerik.WinControls.UI.RadMenuItem();
            this.GetADEmployeeList = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuSeparatorItem2 = new Telerik.WinControls.UI.RadMenuSeparatorItem();
            this.radMenuItem1 = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.FindEmployee = new Telerik.WinControls.UI.RadTextBox();
            this.SelectThemeMenu = new Telerik.WinControls.UI.RadMenuItem();
            this.DefaultTheme = new Telerik.WinControls.UI.RadMenuItem();
            this.BlueGrayTheme = new Telerik.WinControls.UI.RadMenuItem();
            this.TealTheme = new Telerik.WinControls.UI.RadMenuItem();
            this.PinkTheme = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuButtonItem2 = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.radMenuButtonItem1 = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.materialPinkTheme1 = new Telerik.WinControls.Themes.MaterialPinkTheme();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyPageView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentPageView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeListView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderPanel)).BeginInit();
            this.HeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            this.radMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FindEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // CompanyPageView
            // 
            this.CompanyPageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CompanyPageView.Location = new System.Drawing.Point(200, 0);
            this.CompanyPageView.Name = "CompanyPageView";
            this.CompanyPageView.Size = new System.Drawing.Size(1206, 52);
            this.CompanyPageView.TabIndex = 5;
            this.CompanyPageView.ThemeName = "Material";
            this.CompanyPageView.SelectedPageChanged += new System.EventHandler(this.CompanyPageView_SelectedPageChanged);
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.CompanyPageView.GetChildAt(0))).ShowItemPinButton = false;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.CompanyPageView.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.Scroll;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.CompanyPageView.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Top;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.CompanyPageView.GetChildAt(0))).ShowItemCloseButton = false;
            // 
            // DepartmentPageView
            // 
            this.DepartmentPageView.Dock = System.Windows.Forms.DockStyle.Left;
            this.DepartmentPageView.Location = new System.Drawing.Point(0, 89);
            this.DepartmentPageView.Name = "DepartmentPageView";
            this.DepartmentPageView.Size = new System.Drawing.Size(200, 638);
            this.DepartmentPageView.TabIndex = 6;
            this.DepartmentPageView.ThemeName = "Material";
            this.DepartmentPageView.ViewMode = Telerik.WinControls.UI.PageViewMode.Backstage;
            this.DepartmentPageView.SelectedPageChanged += new System.EventHandler(this.DepartmentPageView_SelectedPageChanged);
            ((Telerik.WinControls.UI.RadPageViewBackstageElement)(this.DepartmentPageView.GetChildAt(0))).ItemFitMode = Telerik.WinControls.UI.StripViewItemFitMode.FillHeight;
            ((Telerik.WinControls.UI.RadPageViewBackstageElement)(this.DepartmentPageView.GetChildAt(0))).MinSize = new System.Drawing.Size(200, 0);
            // 
            // EmployeeListView
            // 
            this.EmployeeListView.AllowColumnReorder = false;
            this.EmployeeListView.AllowEdit = false;
            this.EmployeeListView.AllowRemove = false;
            listViewDetailColumn7.HeaderText = "ФИО";
            listViewDetailColumn7.Width = 280F;
            listViewDetailColumn8.HeaderText = "Внутренний";
            listViewDetailColumn8.Width = 120F;
            listViewDetailColumn9.HeaderText = "Городской";
            listViewDetailColumn9.Width = 150F;
            listViewDetailColumn10.HeaderText = "Мобильный";
            listViewDetailColumn10.Width = 150F;
            listViewDetailColumn11.HeaderText = "Электронная почта";
            listViewDetailColumn12.HeaderText = "Должность";
            listViewDetailColumn12.Width = 300F;
            this.EmployeeListView.Columns.AddRange(new Telerik.WinControls.UI.ListViewDetailColumn[] {
            listViewDetailColumn7,
            listViewDetailColumn8,
            listViewDetailColumn9,
            listViewDetailColumn10,
            listViewDetailColumn11,
            listViewDetailColumn12});
            this.EmployeeListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EmployeeListView.EnableSorting = true;
            this.EmployeeListView.GroupItemSize = new System.Drawing.Size(200, 32);
            listViewDataItem2.Text = "ListViewItem 1";
            this.EmployeeListView.Items.AddRange(new Telerik.WinControls.UI.ListViewDataItem[] {
            listViewDataItem2});
            this.EmployeeListView.ItemSize = new System.Drawing.Size(200, 32);
            this.EmployeeListView.ItemSpacing = -1;
            this.EmployeeListView.Location = new System.Drawing.Point(200, 89);
            this.EmployeeListView.Name = "EmployeeListView";
            this.EmployeeListView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.EmployeeListView.SelectLastAddedItem = false;
            this.EmployeeListView.ShowGridLines = true;
            this.EmployeeListView.ShowGroups = true;
            this.EmployeeListView.Size = new System.Drawing.Size(1206, 638);
            this.EmployeeListView.TabIndex = 9;
            this.EmployeeListView.ThemeName = "Material";
            this.EmployeeListView.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView;
            this.EmployeeListView.SelectedItemChanged += new System.EventHandler(this.EmployeeListView_SelectedItemChanged);
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.Controls.Add(this.CompanyPageView);
            this.HeaderPanel.Controls.Add(this.HeaderDescription);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 37);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(1406, 52);
            this.HeaderPanel.TabIndex = 10;
            this.HeaderPanel.ThemeName = "Material";
            // 
            // HeaderDescription
            // 
            this.HeaderDescription.AutoSize = false;
            this.HeaderDescription.Dock = System.Windows.Forms.DockStyle.Left;
            this.HeaderDescription.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.HeaderDescription.Location = new System.Drawing.Point(0, 0);
            this.HeaderDescription.Name = "HeaderDescription";
            this.HeaderDescription.Size = new System.Drawing.Size(200, 52);
            this.HeaderDescription.TabIndex = 6;
            this.HeaderDescription.Text = "Список отделов";
            this.HeaderDescription.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.HeaderDescription.ThemeName = "Material";
            // 
            // UpdateEmployeList
            // 
            this.UpdateEmployeList.AutoSize = false;
            this.UpdateEmployeList.Bounds = new System.Drawing.Rectangle(0, 0, 200, 35);
            this.UpdateEmployeList.Name = "UpdateEmployeList";
            this.UpdateEmployeList.Text = "     Обновить данные";
            this.UpdateEmployeList.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.UpdateEmployeList.UseCompatibleTextRendering = false;
            this.UpdateEmployeList.Click += new System.EventHandler(this.UpdateEmlpoeeList_Click);
            // 
            // AdminMenu
            // 
            this.AdminMenu.AutoSize = false;
            this.AdminMenu.Bounds = new System.Drawing.Rectangle(0, 0, 200, 35);
            this.AdminMenu.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.UpdatePhoneBook,
            this.radMenuSeparatorItem1,
            this.GetSqlEmployeeList,
            this.GetSPEmployeeList,
            this.GetADEmployeeList,
            this.radMenuSeparatorItem2,
            this.radMenuItem1});
            this.AdminMenu.Name = "AdminMenu";
            this.AdminMenu.Text = "        Администратор";
            // 
            // UpdatePhoneBook
            // 
            this.UpdatePhoneBook.Name = "UpdatePhoneBook";
            this.UpdatePhoneBook.Text = "Обновить телефонную книгу";
            this.UpdatePhoneBook.Click += new System.EventHandler(this.UpdatePhoneBook_Click);
            // 
            // radMenuSeparatorItem1
            // 
            this.radMenuSeparatorItem1.Name = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.Text = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GetSqlEmployeeList
            // 
            this.GetSqlEmployeeList.Name = "GetSqlEmployeeList";
            this.GetSqlEmployeeList.Text = "Использовать данные из MS SQL";
            this.GetSqlEmployeeList.Click += new System.EventHandler(this.GetEmployeeList_Click);
            // 
            // GetSPEmployeeList
            // 
            this.GetSPEmployeeList.Name = "GetSPEmployeeList";
            this.GetSPEmployeeList.Text = "Использовать данные из SharePoin";
            this.GetSPEmployeeList.Click += new System.EventHandler(this.GetEmployeeList_Click);
            // 
            // GetADEmployeeList
            // 
            this.GetADEmployeeList.Name = "GetADEmployeeList";
            this.GetADEmployeeList.Text = "Использовать данные из Active Directory";
            this.GetADEmployeeList.Click += new System.EventHandler(this.GetEmployeeList_Click);
            // 
            // radMenuSeparatorItem2
            // 
            this.radMenuSeparatorItem2.Name = "radMenuSeparatorItem2";
            this.radMenuSeparatorItem2.Text = "radMenuSeparatorItem2";
            this.radMenuSeparatorItem2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radMenuItem1
            // 
            this.radMenuItem1.Name = "radMenuItem1";
            this.radMenuItem1.Text = "Сохранить в файл";
            this.radMenuItem1.Click += new System.EventHandler(this.ImportToCSVClick);
            // 
            // radMenu1
            // 
            this.radMenu1.Controls.Add(this.FindEmployee);
            this.radMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.UpdateEmployeList,
            this.AdminMenu,
            this.SelectThemeMenu});
            this.radMenu1.Location = new System.Drawing.Point(0, 0);
            this.radMenu1.Name = "radMenu1";
            this.radMenu1.Size = new System.Drawing.Size(1406, 37);
            this.radMenu1.TabIndex = 11;
            this.radMenu1.ThemeName = "Material";
            // 
            // FindEmployee
            // 
            this.FindEmployee.Location = new System.Drawing.Point(1126, 0);
            this.FindEmployee.Name = "FindEmployee";
            this.FindEmployee.NullText = "Поиск сотрудника...";
            this.FindEmployee.Size = new System.Drawing.Size(280, 36);
            this.FindEmployee.TabIndex = 0;
            this.FindEmployee.ThemeName = "Material";
            this.FindEmployee.TextChanged += new System.EventHandler(this.FindEmployee_TextChanged);
            // 
            // SelectThemeMenu
            // 
            this.SelectThemeMenu.AutoSize = false;
            this.SelectThemeMenu.Bounds = new System.Drawing.Rectangle(0, 0, 200, 35);
            this.SelectThemeMenu.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.DefaultTheme,
            this.BlueGrayTheme,
            this.TealTheme,
            this.PinkTheme});
            this.SelectThemeMenu.Name = "SelectThemeMenu";
            this.SelectThemeMenu.Text = "Цветовая схема";
            // 
            // DefaultTheme
            // 
            this.DefaultTheme.Name = "DefaultTheme";
            this.DefaultTheme.Tag = "";
            this.DefaultTheme.Text = "Синяя";
            this.DefaultTheme.Click += new System.EventHandler(this.SelectTheme_Click);
            // 
            // BlueGrayTheme
            // 
            this.BlueGrayTheme.Name = "BlueGrayTheme";
            this.BlueGrayTheme.Tag = "";
            this.BlueGrayTheme.Text = "Серо-голубая";
            this.BlueGrayTheme.Click += new System.EventHandler(this.SelectTheme_Click);
            // 
            // TealTheme
            // 
            this.TealTheme.Name = "TealTheme";
            this.TealTheme.Text = "Бирюзовая";
            this.TealTheme.Click += new System.EventHandler(this.SelectTheme_Click);
            // 
            // PinkTheme
            // 
            this.PinkTheme.Name = "PinkTheme";
            this.PinkTheme.Text = "Розовая";
            this.PinkTheme.Click += new System.EventHandler(this.SelectTheme_Click);
            // 
            // radMenuButtonItem2
            // 
            // 
            // 
            // 
            this.radMenuButtonItem2.ButtonElement.ShowBorder = false;
            this.radMenuButtonItem2.Name = "radMenuButtonItem2";
            this.radMenuButtonItem2.Text = "radMenuButtonItem2";
            this.radMenuButtonItem2.UseCompatibleTextRendering = false;
            // 
            // radMenuButtonItem1
            // 
            // 
            // 
            // 
            this.radMenuButtonItem1.ButtonElement.ShowBorder = false;
            this.radMenuButtonItem1.Name = "radMenuButtonItem1";
            this.radMenuButtonItem1.Text = "radMenuButtonItem1";
            this.radMenuButtonItem1.UseCompatibleTextRendering = false;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1406, 727);
            this.Controls.Add(this.EmployeeListView);
            this.Controls.Add(this.DepartmentPageView);
            this.Controls.Add(this.HeaderPanel);
            this.Controls.Add(this.radMenu1);
            this.Name = "MainForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Телефонная книга";
            this.ThemeName = "Material";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CompanyPageView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentPageView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeListView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderPanel)).EndInit();
            this.HeaderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HeaderDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            this.radMenu1.ResumeLayout(false);
            this.radMenu1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FindEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.Themes.MaterialTheme materialTheme1;
        private Telerik.WinControls.UI.RadPageView CompanyPageView;
        private Telerik.WinControls.UI.RadPageView DepartmentPageView;
        private Telerik.WinControls.UI.RadListView EmployeeListView;
        private Telerik.WinControls.UI.RadPanel HeaderPanel;
        private Telerik.WinControls.UI.RadLabel HeaderDescription;
        private Telerik.WinControls.Themes.MaterialTealTheme materialTealTheme1;
        private Telerik.WinControls.Themes.MaterialBlueGreyTheme materialBlueGreyTheme1;
        private Telerik.WinControls.UI.RadMenuItem UpdateEmployeList;
        private Telerik.WinControls.UI.RadMenuItem AdminMenu;
        private Telerik.WinControls.UI.RadMenuItem GetSqlEmployeeList;
        private Telerik.WinControls.UI.RadMenuItem GetSPEmployeeList;
        private Telerik.WinControls.UI.RadMenuItem GetADEmployeeList;
        private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem1;
        private Telerik.WinControls.UI.RadMenuItem UpdatePhoneBook;
        private Telerik.WinControls.UI.RadMenu radMenu1;
        private Telerik.WinControls.UI.RadMenuButtonItem radMenuButtonItem2;
        private Telerik.WinControls.UI.RadMenuButtonItem radMenuButtonItem1;
        private Telerik.WinControls.UI.RadMenuItem SelectThemeMenu;
        private Telerik.WinControls.UI.RadMenuItem DefaultTheme;
        private Telerik.WinControls.UI.RadMenuItem BlueGrayTheme;
        private Telerik.WinControls.UI.RadMenuItem TealTheme;
        private Telerik.WinControls.UI.RadMenuItem PinkTheme;
        private Telerik.WinControls.Themes.MaterialPinkTheme materialPinkTheme1;
        private Telerik.WinControls.UI.RadTextBox FindEmployee;
        private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem2;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem1;
    }
}