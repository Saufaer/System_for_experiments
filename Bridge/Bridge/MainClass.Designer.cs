﻿namespace Bridge
{
    partial class MainClass
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LabelConf = new MetroFramework.Controls.MetroLabel();
            this.LabelProgName = new MetroFramework.Controls.MetroLabel();
            this.OpenXMLbutton = new MetroFramework.Controls.MetroButton();
            this.Run = new MetroFramework.Controls.MetroButton();
            this.MainTabControl = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.TextBoxOutLog = new MetroFramework.Controls.MetroTextBox();
            this.TextBoxChosenProgram = new MetroFramework.Controls.MetroTextBox();
            this.ButtonChoseProgram = new MetroFramework.Controls.MetroButton();
            this.TextBoxChosenXML = new MetroFramework.Controls.MetroTextBox();
            this.ButtonChoseTargetXML = new MetroFramework.Controls.MetroButton();
            this.metroTabPage4 = new MetroFramework.Controls.MetroTabPage();
            this.CreateDefault = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.EditorTabControl = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.TextBoxXML = new MetroFramework.Controls.MetroTextBox();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.SearchInfo = new MetroFramework.Controls.MetroButton();
            this.TextBoxSearch = new MetroFramework.Controls.MetroTextBox();
            this.LabelDecription = new MetroFramework.Controls.MetroLabel();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel13 = new MetroFramework.Controls.MetroLabel();
            this.ParNameTextBox = new MetroFramework.Controls.MetroTextBox();
            this.InfoTable = new MetroFramework.Controls.MetroGrid();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueTextBox = new MetroFramework.Controls.MetroTextBox();
            this.AddLink = new MetroFramework.Controls.MetroButton();
            this.TextBoxPath = new MetroFramework.Controls.MetroTextBox();
            this.ConfigTable = new MetroFramework.Controls.MetroGrid();
            this.Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.par = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComboBoxProgName = new MetroFramework.Controls.MetroComboBox();
            this.Delete = new MetroFramework.Controls.MetroButton();
            this.WriteConf = new MetroFramework.Controls.MetroButton();
            this.Create = new MetroFramework.Controls.MetroButton();
            this.MainTabControl.SuspendLayout();
            this.metroTabPage3.SuspendLayout();
            this.metroTabPage4.SuspendLayout();
            this.EditorTabControl.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InfoTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConfigTable)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelConf
            // 
            this.LabelConf.AutoSize = true;
            this.LabelConf.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.LabelConf.Location = new System.Drawing.Point(10, 70);
            this.LabelConf.Name = "LabelConf";
            this.LabelConf.Size = new System.Drawing.Size(101, 19);
            this.LabelConf.TabIndex = 15;
            this.LabelConf.Text = "Конфигурация";
            // 
            // LabelProgName
            // 
            this.LabelProgName.AutoSize = true;
            this.LabelProgName.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.LabelProgName.Location = new System.Drawing.Point(8, 51);
            this.LabelProgName.Name = "LabelProgName";
            this.LabelProgName.Size = new System.Drawing.Size(168, 19);
            this.LabelProgName.TabIndex = 16;
            this.LabelProgName.Text = "Программа-исполнитель";
            // 
            // OpenXMLbutton
            // 
            this.OpenXMLbutton.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.OpenXMLbutton.Location = new System.Drawing.Point(10, 3);
            this.OpenXMLbutton.Name = "OpenXMLbutton";
            this.OpenXMLbutton.Size = new System.Drawing.Size(65, 27);
            this.OpenXMLbutton.TabIndex = 19;
            this.OpenXMLbutton.Text = "Открыть";
            this.OpenXMLbutton.UseSelectable = true;
            this.OpenXMLbutton.Click += new System.EventHandler(this.OpenXMLbutton_Click);
            // 
            // Run
            // 
            this.Run.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.Run.Location = new System.Drawing.Point(3, 3);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(51, 29);
            this.Run.TabIndex = 23;
            this.Run.Text = "Старт";
            this.Run.UseSelectable = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // MainTabControl
            // 
            this.MainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTabControl.Controls.Add(this.metroTabPage3);
            this.MainTabControl.Controls.Add(this.metroTabPage4);
            this.MainTabControl.Location = new System.Drawing.Point(23, 63);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 1;
            this.MainTabControl.Size = new System.Drawing.Size(1505, 600);
            this.MainTabControl.TabIndex = 25;
            this.MainTabControl.UseSelectable = true;
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.TextBoxOutLog);
            this.metroTabPage3.Controls.Add(this.TextBoxChosenProgram);
            this.metroTabPage3.Controls.Add(this.ButtonChoseProgram);
            this.metroTabPage3.Controls.Add(this.TextBoxChosenXML);
            this.metroTabPage3.Controls.Add(this.ButtonChoseTargetXML);
            this.metroTabPage3.Controls.Add(this.Run);
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.HorizontalScrollbarSize = 10;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(1497, 558);
            this.metroTabPage3.TabIndex = 0;
            this.metroTabPage3.Text = "Проведение экспериментов";
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            this.metroTabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.VerticalScrollbarSize = 10;
            // 
            // TextBoxOutLog
            // 
            // 
            // 
            // 
            this.TextBoxOutLog.CustomButton.Image = null;
            this.TextBoxOutLog.CustomButton.Location = new System.Drawing.Point(175, 1);
            this.TextBoxOutLog.CustomButton.Name = "";
            this.TextBoxOutLog.CustomButton.Size = new System.Drawing.Size(523, 523);
            this.TextBoxOutLog.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxOutLog.CustomButton.TabIndex = 1;
            this.TextBoxOutLog.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxOutLog.CustomButton.UseSelectable = true;
            this.TextBoxOutLog.CustomButton.Visible = false;
            this.TextBoxOutLog.Lines = new string[0];
            this.TextBoxOutLog.Location = new System.Drawing.Point(793, 3);
            this.TextBoxOutLog.MaxLength = 32767;
            this.TextBoxOutLog.Multiline = true;
            this.TextBoxOutLog.Name = "TextBoxOutLog";
            this.TextBoxOutLog.PasswordChar = '\0';
            this.TextBoxOutLog.ReadOnly = true;
            this.TextBoxOutLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextBoxOutLog.SelectedText = "";
            this.TextBoxOutLog.SelectionLength = 0;
            this.TextBoxOutLog.SelectionStart = 0;
            this.TextBoxOutLog.ShortcutsEnabled = true;
            this.TextBoxOutLog.Size = new System.Drawing.Size(699, 525);
            this.TextBoxOutLog.TabIndex = 44;
            this.TextBoxOutLog.UseSelectable = true;
            this.TextBoxOutLog.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxOutLog.WaterMarkFont = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TextBoxChosenProgram
            // 
            // 
            // 
            // 
            this.TextBoxChosenProgram.CustomButton.Image = null;
            this.TextBoxChosenProgram.CustomButton.Location = new System.Drawing.Point(453, 1);
            this.TextBoxChosenProgram.CustomButton.Name = "";
            this.TextBoxChosenProgram.CustomButton.Size = new System.Drawing.Size(45, 45);
            this.TextBoxChosenProgram.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxChosenProgram.CustomButton.TabIndex = 1;
            this.TextBoxChosenProgram.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxChosenProgram.CustomButton.UseSelectable = true;
            this.TextBoxChosenProgram.CustomButton.Visible = false;
            this.TextBoxChosenProgram.Lines = new string[0];
            this.TextBoxChosenProgram.Location = new System.Drawing.Point(269, 58);
            this.TextBoxChosenProgram.MaxLength = 32767;
            this.TextBoxChosenProgram.Multiline = true;
            this.TextBoxChosenProgram.Name = "TextBoxChosenProgram";
            this.TextBoxChosenProgram.PasswordChar = '\0';
            this.TextBoxChosenProgram.ReadOnly = true;
            this.TextBoxChosenProgram.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextBoxChosenProgram.SelectedText = "";
            this.TextBoxChosenProgram.SelectionLength = 0;
            this.TextBoxChosenProgram.SelectionStart = 0;
            this.TextBoxChosenProgram.ShortcutsEnabled = true;
            this.TextBoxChosenProgram.Size = new System.Drawing.Size(499, 47);
            this.TextBoxChosenProgram.TabIndex = 33;
            this.TextBoxChosenProgram.UseSelectable = true;
            this.TextBoxChosenProgram.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxChosenProgram.WaterMarkFont = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // ButtonChoseProgram
            // 
            this.ButtonChoseProgram.Location = new System.Drawing.Point(101, 58);
            this.ButtonChoseProgram.Name = "ButtonChoseProgram";
            this.ButtonChoseProgram.Size = new System.Drawing.Size(162, 29);
            this.ButtonChoseProgram.TabIndex = 32;
            this.ButtonChoseProgram.Text = "Выбрать исполнителя";
            this.ButtonChoseProgram.UseSelectable = true;
            this.ButtonChoseProgram.Click += new System.EventHandler(this.ButtonChoseProgram_Click);
            // 
            // TextBoxChosenXML
            // 
            // 
            // 
            // 
            this.TextBoxChosenXML.CustomButton.Image = null;
            this.TextBoxChosenXML.CustomButton.Location = new System.Drawing.Point(453, 1);
            this.TextBoxChosenXML.CustomButton.Name = "";
            this.TextBoxChosenXML.CustomButton.Size = new System.Drawing.Size(45, 45);
            this.TextBoxChosenXML.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxChosenXML.CustomButton.TabIndex = 1;
            this.TextBoxChosenXML.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxChosenXML.CustomButton.UseSelectable = true;
            this.TextBoxChosenXML.CustomButton.Visible = false;
            this.TextBoxChosenXML.Lines = new string[0];
            this.TextBoxChosenXML.Location = new System.Drawing.Point(269, 3);
            this.TextBoxChosenXML.MaxLength = 32767;
            this.TextBoxChosenXML.Multiline = true;
            this.TextBoxChosenXML.Name = "TextBoxChosenXML";
            this.TextBoxChosenXML.PasswordChar = '\0';
            this.TextBoxChosenXML.ReadOnly = true;
            this.TextBoxChosenXML.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextBoxChosenXML.SelectedText = "";
            this.TextBoxChosenXML.SelectionLength = 0;
            this.TextBoxChosenXML.SelectionStart = 0;
            this.TextBoxChosenXML.ShortcutsEnabled = true;
            this.TextBoxChosenXML.Size = new System.Drawing.Size(499, 47);
            this.TextBoxChosenXML.TabIndex = 31;
            this.TextBoxChosenXML.UseSelectable = true;
            this.TextBoxChosenXML.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxChosenXML.WaterMarkFont = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // ButtonChoseTargetXML
            // 
            this.ButtonChoseTargetXML.Location = new System.Drawing.Point(101, 3);
            this.ButtonChoseTargetXML.Name = "ButtonChoseTargetXML";
            this.ButtonChoseTargetXML.Size = new System.Drawing.Size(162, 29);
            this.ButtonChoseTargetXML.TabIndex = 24;
            this.ButtonChoseTargetXML.Text = "Выбрать конфигурацию";
            this.ButtonChoseTargetXML.UseSelectable = true;
            this.ButtonChoseTargetXML.Click += new System.EventHandler(this.ButtonChoseTargetXML_Click);
            // 
            // metroTabPage4
            // 
            this.metroTabPage4.Controls.Add(this.CreateDefault);
            this.metroTabPage4.Controls.Add(this.metroLabel3);
            this.metroTabPage4.Controls.Add(this.EditorTabControl);
            this.metroTabPage4.Controls.Add(this.OpenXMLbutton);
            this.metroTabPage4.Controls.Add(this.TextBoxPath);
            this.metroTabPage4.Controls.Add(this.LabelProgName);
            this.metroTabPage4.Controls.Add(this.ConfigTable);
            this.metroTabPage4.Controls.Add(this.LabelConf);
            this.metroTabPage4.Controls.Add(this.ComboBoxProgName);
            this.metroTabPage4.Controls.Add(this.Delete);
            this.metroTabPage4.Controls.Add(this.WriteConf);
            this.metroTabPage4.Controls.Add(this.Create);
            this.metroTabPage4.HorizontalScrollbarBarColor = true;
            this.metroTabPage4.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage4.HorizontalScrollbarSize = 10;
            this.metroTabPage4.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage4.Name = "metroTabPage4";
            this.metroTabPage4.Size = new System.Drawing.Size(1497, 558);
            this.metroTabPage4.TabIndex = 1;
            this.metroTabPage4.Text = "Создание файла конфигурации";
            this.metroTabPage4.VerticalScrollbarBarColor = true;
            this.metroTabPage4.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage4.VerticalScrollbarSize = 10;
            // 
            // CreateDefault
            // 
            this.CreateDefault.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.CreateDefault.Location = new System.Drawing.Point(165, 3);
            this.CreateDefault.Name = "CreateDefault";
            this.CreateDefault.Size = new System.Drawing.Size(161, 27);
            this.CreateDefault.TabIndex = 34;
            this.CreateDefault.Text = "Создать по умолчанию";
            this.CreateDefault.UseSelectable = true;
            this.CreateDefault.Click += new System.EventHandler(this.CreateXMLDefault_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(546, 3);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(101, 19);
            this.metroLabel3.TabIndex = 33;
            this.metroLabel3.Text = "Расположение";
            // 
            // EditorTabControl
            // 
            this.EditorTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EditorTabControl.Controls.Add(this.metroTabPage1);
            this.EditorTabControl.Controls.Add(this.metroTabPage2);
            this.EditorTabControl.FontWeight = MetroFramework.MetroTabControlWeight.Regular;
            this.EditorTabControl.Location = new System.Drawing.Point(530, 55);
            this.EditorTabControl.Name = "EditorTabControl";
            this.EditorTabControl.SelectedIndex = 1;
            this.EditorTabControl.Size = new System.Drawing.Size(962, 523);
            this.EditorTabControl.TabIndex = 32;
            this.EditorTabControl.UseSelectable = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.TextBoxXML);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(954, 481);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Содержимое файла";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // TextBoxXML
            // 
            this.TextBoxXML.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.TextBoxXML.CustomButton.Image = null;
            this.TextBoxXML.CustomButton.Location = new System.Drawing.Point(483, 1);
            this.TextBoxXML.CustomButton.Name = "";
            this.TextBoxXML.CustomButton.Size = new System.Drawing.Size(453, 453);
            this.TextBoxXML.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxXML.CustomButton.TabIndex = 1;
            this.TextBoxXML.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxXML.CustomButton.UseSelectable = true;
            this.TextBoxXML.CustomButton.Visible = false;
            this.TextBoxXML.Lines = new string[0];
            this.TextBoxXML.Location = new System.Drawing.Point(10, 7);
            this.TextBoxXML.MaxLength = 32767;
            this.TextBoxXML.Multiline = true;
            this.TextBoxXML.Name = "TextBoxXML";
            this.TextBoxXML.PasswordChar = '\0';
            this.TextBoxXML.ReadOnly = true;
            this.TextBoxXML.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextBoxXML.SelectedText = "";
            this.TextBoxXML.SelectionLength = 0;
            this.TextBoxXML.SelectionStart = 0;
            this.TextBoxXML.ShortcutsEnabled = true;
            this.TextBoxXML.Size = new System.Drawing.Size(937, 455);
            this.TextBoxXML.TabIndex = 18;
            this.TextBoxXML.UseSelectable = true;
            this.TextBoxXML.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxXML.WaterMarkFont = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.SearchInfo);
            this.metroTabPage2.Controls.Add(this.TextBoxSearch);
            this.metroTabPage2.Controls.Add(this.LabelDecription);
            this.metroTabPage2.Controls.Add(this.metroLabel12);
            this.metroTabPage2.Controls.Add(this.metroLabel13);
            this.metroTabPage2.Controls.Add(this.ParNameTextBox);
            this.metroTabPage2.Controls.Add(this.InfoTable);
            this.metroTabPage2.Controls.Add(this.ValueTextBox);
            this.metroTabPage2.Controls.Add(this.AddLink);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(954, 481);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Редактирование";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            // 
            // SearchInfo
            // 
            this.SearchInfo.Location = new System.Drawing.Point(570, 22);
            this.SearchInfo.Name = "SearchInfo";
            this.SearchInfo.Size = new System.Drawing.Size(48, 30);
            this.SearchInfo.TabIndex = 44;
            this.SearchInfo.Text = "Поиск";
            this.SearchInfo.UseSelectable = true;
            this.SearchInfo.Click += new System.EventHandler(this.SearchInfo_Click);
            // 
            // TextBoxSearch
            // 
            // 
            // 
            // 
            this.TextBoxSearch.CustomButton.Image = null;
            this.TextBoxSearch.CustomButton.Location = new System.Drawing.Point(282, 2);
            this.TextBoxSearch.CustomButton.Name = "";
            this.TextBoxSearch.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.TextBoxSearch.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxSearch.CustomButton.TabIndex = 1;
            this.TextBoxSearch.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxSearch.CustomButton.UseSelectable = true;
            this.TextBoxSearch.CustomButton.Visible = false;
            this.TextBoxSearch.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.TextBoxSearch.Lines = new string[0];
            this.TextBoxSearch.Location = new System.Drawing.Point(615, 22);
            this.TextBoxSearch.MaxLength = 32767;
            this.TextBoxSearch.Name = "TextBoxSearch";
            this.TextBoxSearch.PasswordChar = '\0';
            this.TextBoxSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxSearch.SelectedText = "";
            this.TextBoxSearch.SelectionLength = 0;
            this.TextBoxSearch.SelectionStart = 0;
            this.TextBoxSearch.ShortcutsEnabled = true;
            this.TextBoxSearch.Size = new System.Drawing.Size(310, 30);
            this.TextBoxSearch.TabIndex = 43;
            this.TextBoxSearch.UseSelectable = true;
            this.TextBoxSearch.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxSearch.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // LabelDecription
            // 
            this.LabelDecription.AutoSize = true;
            this.LabelDecription.FontSize = MetroFramework.MetroLabelSize.Small;
            this.LabelDecription.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.LabelDecription.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LabelDecription.Location = new System.Drawing.Point(351, 55);
            this.LabelDecription.Name = "LabelDecription";
            this.LabelDecription.Size = new System.Drawing.Size(62, 15);
            this.LabelDecription.Style = MetroFramework.MetroColorStyle.Black;
            this.LabelDecription.TabIndex = 42;
            this.LabelDecription.Text = "Описание";
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel12.Location = new System.Drawing.Point(351, 0);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(144, 19);
            this.metroLabel12.Style = MetroFramework.MetroColorStyle.Black;
            this.metroLabel12.TabIndex = 39;
            this.metroLabel12.Text = "Выбранное значение";
            // 
            // metroLabel13
            // 
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel13.Location = new System.Drawing.Point(154, 0);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Size = new System.Drawing.Size(149, 19);
            this.metroLabel13.TabIndex = 38;
            this.metroLabel13.Text = "Выбранный параметр";
            // 
            // ParNameTextBox
            // 
            // 
            // 
            // 
            this.ParNameTextBox.CustomButton.Image = null;
            this.ParNameTextBox.CustomButton.Location = new System.Drawing.Point(159, 2);
            this.ParNameTextBox.CustomButton.Name = "";
            this.ParNameTextBox.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.ParNameTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ParNameTextBox.CustomButton.TabIndex = 1;
            this.ParNameTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ParNameTextBox.CustomButton.UseSelectable = true;
            this.ParNameTextBox.CustomButton.Visible = false;
            this.ParNameTextBox.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.ParNameTextBox.Lines = new string[0];
            this.ParNameTextBox.Location = new System.Drawing.Point(154, 22);
            this.ParNameTextBox.MaxLength = 32767;
            this.ParNameTextBox.Name = "ParNameTextBox";
            this.ParNameTextBox.PasswordChar = '\0';
            this.ParNameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ParNameTextBox.SelectedText = "";
            this.ParNameTextBox.SelectionLength = 0;
            this.ParNameTextBox.SelectionStart = 0;
            this.ParNameTextBox.ShortcutsEnabled = true;
            this.ParNameTextBox.Size = new System.Drawing.Size(187, 30);
            this.ParNameTextBox.TabIndex = 37;
            this.ParNameTextBox.UseSelectable = true;
            this.ParNameTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ParNameTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // InfoTable
            // 
            this.InfoTable.AllowUserToResizeRows = false;
            this.InfoTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InfoTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.InfoTable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.InfoTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InfoTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.InfoTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InfoTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.InfoTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InfoTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.InfoTable.DefaultCellStyle = dataGridViewCellStyle11;
            this.InfoTable.EnableHeadersVisualStyles = false;
            this.InfoTable.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.InfoTable.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.InfoTable.Location = new System.Drawing.Point(3, 94);
            this.InfoTable.Name = "InfoTable";
            this.InfoTable.ReadOnly = true;
            this.InfoTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InfoTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.InfoTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.InfoTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.InfoTable.Size = new System.Drawing.Size(955, 368);
            this.InfoTable.TabIndex = 36;
            this.InfoTable.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.InfoTable_CellMouseClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Параметр";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 180;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Допустимое значение";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Значение по умолчанию";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Описание";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 400;
            // 
            // ValueTextBox
            // 
            // 
            // 
            // 
            this.ValueTextBox.CustomButton.Image = null;
            this.ValueTextBox.CustomButton.Location = new System.Drawing.Point(146, 2);
            this.ValueTextBox.CustomButton.Name = "";
            this.ValueTextBox.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.ValueTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ValueTextBox.CustomButton.TabIndex = 1;
            this.ValueTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ValueTextBox.CustomButton.UseSelectable = true;
            this.ValueTextBox.CustomButton.Visible = false;
            this.ValueTextBox.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.ValueTextBox.Lines = new string[0];
            this.ValueTextBox.Location = new System.Drawing.Point(351, 22);
            this.ValueTextBox.MaxLength = 32767;
            this.ValueTextBox.Name = "ValueTextBox";
            this.ValueTextBox.PasswordChar = '\0';
            this.ValueTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ValueTextBox.SelectedText = "";
            this.ValueTextBox.SelectionLength = 0;
            this.ValueTextBox.SelectionStart = 0;
            this.ValueTextBox.ShortcutsEnabled = true;
            this.ValueTextBox.Size = new System.Drawing.Size(174, 30);
            this.ValueTextBox.TabIndex = 35;
            this.ValueTextBox.UseSelectable = true;
            this.ValueTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ValueTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // AddLink
            // 
            this.AddLink.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.AddLink.Location = new System.Drawing.Point(3, 22);
            this.AddLink.Name = "AddLink";
            this.AddLink.Size = new System.Drawing.Size(145, 30);
            this.AddLink.TabIndex = 34;
            this.AddLink.Text = "Добавить";
            this.AddLink.UseSelectable = true;
            this.AddLink.Click += new System.EventHandler(this.AddLink_Click);
            // 
            // TextBoxPath
            // 
            // 
            // 
            // 
            this.TextBoxPath.CustomButton.Image = null;
            this.TextBoxPath.CustomButton.Location = new System.Drawing.Point(453, 1);
            this.TextBoxPath.CustomButton.Name = "";
            this.TextBoxPath.CustomButton.Size = new System.Drawing.Size(45, 45);
            this.TextBoxPath.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxPath.CustomButton.TabIndex = 1;
            this.TextBoxPath.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxPath.CustomButton.UseSelectable = true;
            this.TextBoxPath.CustomButton.Visible = false;
            this.TextBoxPath.Lines = new string[0];
            this.TextBoxPath.Location = new System.Drawing.Point(653, 3);
            this.TextBoxPath.MaxLength = 32767;
            this.TextBoxPath.Multiline = true;
            this.TextBoxPath.Name = "TextBoxPath";
            this.TextBoxPath.PasswordChar = '\0';
            this.TextBoxPath.ReadOnly = true;
            this.TextBoxPath.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextBoxPath.SelectedText = "";
            this.TextBoxPath.SelectionLength = 0;
            this.TextBoxPath.SelectionStart = 0;
            this.TextBoxPath.ShortcutsEnabled = true;
            this.TextBoxPath.Size = new System.Drawing.Size(499, 47);
            this.TextBoxPath.TabIndex = 30;
            this.TextBoxPath.UseSelectable = true;
            this.TextBoxPath.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxPath.WaterMarkFont = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // ConfigTable
            // 
            this.ConfigTable.AllowUserToResizeRows = false;
            this.ConfigTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfigTable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ConfigTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ConfigTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.ConfigTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ConfigTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.ConfigTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ConfigTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Key,
            this.par});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ConfigTable.DefaultCellStyle = dataGridViewCellStyle8;
            this.ConfigTable.EnableHeadersVisualStyles = false;
            this.ConfigTable.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ConfigTable.GridColor = System.Drawing.Color.White;
            this.ConfigTable.Location = new System.Drawing.Point(3, 96);
            this.ConfigTable.Name = "ConfigTable";
            this.ConfigTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ConfigTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.ConfigTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ConfigTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ConfigTable.Size = new System.Drawing.Size(754, 459);
            this.ConfigTable.TabIndex = 29;
            // 
            // Key
            // 
            this.Key.HeaderText = "Параметр";
            this.Key.Name = "Key";
            this.Key.Width = 250;
            // 
            // par
            // 
            this.par.HeaderText = "Значение";
            this.par.Name = "par";
            this.par.Width = 230;
            // 
            // ComboBoxProgName
            // 
            this.ComboBoxProgName.FontWeight = MetroFramework.MetroComboBoxWeight.Bold;
            this.ComboBoxProgName.FormattingEnabled = true;
            this.ComboBoxProgName.ItemHeight = 23;
            this.ComboBoxProgName.Items.AddRange(new object[] {
            "examin.exe",
            "plotter.exe "});
            this.ComboBoxProgName.Location = new System.Drawing.Point(182, 51);
            this.ComboBoxProgName.Name = "ComboBoxProgName";
            this.ComboBoxProgName.Size = new System.Drawing.Size(127, 29);
            this.ComboBoxProgName.TabIndex = 28;
            this.ComboBoxProgName.UseSelectable = true;
            this.ComboBoxProgName.SelectedIndexChanged += new System.EventHandler(this.ComboBoxProgName_SelectedIndexChanged);
            // 
            // Delete
            // 
            this.Delete.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.Delete.Location = new System.Drawing.Point(341, 3);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(64, 27);
            this.Delete.TabIndex = 27;
            this.Delete.Text = "Удалить";
            this.Delete.UseSelectable = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // WriteConf
            // 
            this.WriteConf.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.WriteConf.Location = new System.Drawing.Point(341, 51);
            this.WriteConf.Name = "WriteConf";
            this.WriteConf.Size = new System.Drawing.Size(183, 37);
            this.WriteConf.TabIndex = 26;
            this.WriteConf.Text = "Применить конфигурацию";
            this.WriteConf.UseSelectable = true;
            this.WriteConf.Click += new System.EventHandler(this.WriteConf_Click);
            // 
            // Create
            // 
            this.Create.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.Create.Location = new System.Drawing.Point(81, 3);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(59, 27);
            this.Create.TabIndex = 25;
            this.Create.Text = "Создать";
            this.Create.UseSelectable = true;
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // MainClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1542, 686);
            this.Controls.Add(this.MainTabControl);
            this.Name = "MainClass";
            this.MainTabControl.ResumeLayout(false);
            this.metroTabPage3.ResumeLayout(false);
            this.metroTabPage4.ResumeLayout(false);
            this.metroTabPage4.PerformLayout();
            this.EditorTabControl.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InfoTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConfigTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroLabel LabelConf;
        private MetroFramework.Controls.MetroLabel LabelProgName;
        private MetroFramework.Controls.MetroButton OpenXMLbutton;
        private MetroFramework.Controls.MetroButton Run;
        private MetroFramework.Controls.MetroTabControl MainTabControl;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private MetroFramework.Controls.MetroTabPage metroTabPage4;
        private MetroFramework.Controls.MetroTabControl EditorTabControl;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTextBox TextBoxXML;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroButton SearchInfo;
        private MetroFramework.Controls.MetroTextBox TextBoxSearch;
        private MetroFramework.Controls.MetroLabel LabelDecription;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroLabel metroLabel13;
        private MetroFramework.Controls.MetroTextBox ParNameTextBox;
        private MetroFramework.Controls.MetroGrid InfoTable;
        private MetroFramework.Controls.MetroTextBox ValueTextBox;
        private MetroFramework.Controls.MetroButton AddLink;
        private MetroFramework.Controls.MetroTextBox TextBoxPath;
        public MetroFramework.Controls.MetroGrid ConfigTable;
        private MetroFramework.Controls.MetroComboBox ComboBoxProgName;
        private MetroFramework.Controls.MetroButton Delete;
        private MetroFramework.Controls.MetroButton WriteConf;
        private MetroFramework.Controls.MetroButton Create;
        private System.Windows.Forms.DataGridViewTextBoxColumn Key;
        private System.Windows.Forms.DataGridViewTextBoxColumn par;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroButton ButtonChoseTargetXML;
        private MetroFramework.Controls.MetroTextBox TextBoxChosenXML;
        private MetroFramework.Controls.MetroButton ButtonChoseProgram;
        private MetroFramework.Controls.MetroTextBox TextBoxChosenProgram;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private MetroFramework.Controls.MetroTextBox TextBoxOutLog;
        private MetroFramework.Controls.MetroButton CreateDefault;
    }
}
