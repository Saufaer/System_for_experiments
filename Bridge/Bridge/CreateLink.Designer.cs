namespace Bridge
{
    partial class CreateLink
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.ValueTextBox = new MetroFramework.Controls.MetroTextBox();
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.InfoTable = new MetroFramework.Controls.MetroGrid();
            this.ParNameTextBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.Par = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valid_Values = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Default_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.InfoTable)).BeginInit();
            this.SuspendLayout();
            // 
            // metroButton1
            // 
            this.metroButton1.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton1.Location = new System.Drawing.Point(23, 63);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(180, 30);
            this.metroButton1.TabIndex = 10;
            this.metroButton1.Text = "Add link";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // ValueTextBox
            // 
            // 
            // 
            // 
            this.ValueTextBox.CustomButton.Image = null;
            this.ValueTextBox.CustomButton.Location = new System.Drawing.Point(152, 2);
            this.ValueTextBox.CustomButton.Name = "";
            this.ValueTextBox.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.ValueTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ValueTextBox.CustomButton.TabIndex = 1;
            this.ValueTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ValueTextBox.CustomButton.UseSelectable = true;
            this.ValueTextBox.CustomButton.Visible = false;
            this.ValueTextBox.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.ValueTextBox.Lines = new string[0];
            this.ValueTextBox.Location = new System.Drawing.Point(238, 163);
            this.ValueTextBox.MaxLength = 32767;
            this.ValueTextBox.Name = "ValueTextBox";
            this.ValueTextBox.PasswordChar = '\0';
            this.ValueTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ValueTextBox.SelectedText = "";
            this.ValueTextBox.SelectionLength = 0;
            this.ValueTextBox.SelectionStart = 0;
            this.ValueTextBox.ShortcutsEnabled = true;
            this.ValueTextBox.Size = new System.Drawing.Size(180, 30);
            this.ValueTextBox.TabIndex = 11;
            this.ValueTextBox.UseSelectable = true;
            this.ValueTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ValueTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroToolTip1
            // 
            this.metroToolTip1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroToolTip1.StyleManager = null;
            this.metroToolTip1.Theme = MetroFramework.MetroThemeStyle.Light;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InfoTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.InfoTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InfoTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Par,
            this.Valid_Values,
            this.Default_value,
            this.Description});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.InfoTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.InfoTable.EnableHeadersVisualStyles = false;
            this.InfoTable.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.InfoTable.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.InfoTable.Location = new System.Drawing.Point(23, 225);
            this.InfoTable.Name = "InfoTable";
            this.InfoTable.ReadOnly = true;
            this.InfoTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InfoTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.InfoTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.InfoTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.InfoTable.Size = new System.Drawing.Size(1031, 399);
            this.InfoTable.TabIndex = 14;
            this.InfoTable.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.InfoTable_CellMouseClick);
            // 
            // ParNameTextBox
            // 
            // 
            // 
            // 
            this.ParNameTextBox.CustomButton.Image = null;
            this.ParNameTextBox.CustomButton.Location = new System.Drawing.Point(152, 2);
            this.ParNameTextBox.CustomButton.Name = "";
            this.ParNameTextBox.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.ParNameTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ParNameTextBox.CustomButton.TabIndex = 1;
            this.ParNameTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ParNameTextBox.CustomButton.UseSelectable = true;
            this.ParNameTextBox.CustomButton.Visible = false;
            this.ParNameTextBox.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.ParNameTextBox.Lines = new string[0];
            this.ParNameTextBox.Location = new System.Drawing.Point(24, 163);
            this.ParNameTextBox.MaxLength = 32767;
            this.ParNameTextBox.Name = "ParNameTextBox";
            this.ParNameTextBox.PasswordChar = '\0';
            this.ParNameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ParNameTextBox.SelectedText = "";
            this.ParNameTextBox.SelectionLength = 0;
            this.ParNameTextBox.SelectionStart = 0;
            this.ParNameTextBox.ShortcutsEnabled = true;
            this.ParNameTextBox.Size = new System.Drawing.Size(180, 30);
            this.ParNameTextBox.TabIndex = 15;
            this.ParNameTextBox.UseSelectable = true;
            this.ParNameTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ParNameTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(24, 141);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(123, 19);
            this.metroLabel1.TabIndex = 16;
            this.metroLabel1.Text = "Current parameter";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(238, 141);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(92, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Black;
            this.metroLabel2.TabIndex = 17;
            this.metroLabel2.Text = "Current value";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(23, 203);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(187, 19);
            this.metroLabel3.TabIndex = 18;
            this.metroLabel3.Text = "Общие параметры системы";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(519, 12);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(129, 19);
            this.metroLabel4.TabIndex = 19;
            this.metroLabel4.Text = "Current Description";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.metroLabel5.Location = new System.Drawing.Point(519, 31);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(72, 19);
            this.metroLabel5.Style = MetroFramework.MetroColorStyle.Black;
            this.metroLabel5.TabIndex = 20;
            this.metroLabel5.Text = "Описание";
            // 
            // metroTextBox1
            // 
            // 
            // 
            // 
            this.metroTextBox1.CustomButton.Image = null;
            this.metroTextBox1.CustomButton.Location = new System.Drawing.Point(152, 2);
            this.metroTextBox1.CustomButton.Name = "";
            this.metroTextBox1.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.metroTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox1.CustomButton.TabIndex = 1;
            this.metroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox1.CustomButton.UseSelectable = true;
            this.metroTextBox1.CustomButton.Visible = false;
            this.metroTextBox1.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.metroTextBox1.Lines = new string[0];
            this.metroTextBox1.Location = new System.Drawing.Point(333, 12);
            this.metroTextBox1.MaxLength = 32767;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.PasswordChar = '\0';
            this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox1.SelectedText = "";
            this.metroTextBox1.SelectionLength = 0;
            this.metroTextBox1.SelectionStart = 0;
            this.metroTextBox1.ShortcutsEnabled = true;
            this.metroTextBox1.Size = new System.Drawing.Size(180, 30);
            this.metroTextBox1.TabIndex = 21;
            this.metroTextBox1.UseSelectable = true;
            this.metroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroButton2
            // 
            this.metroButton2.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton2.Location = new System.Drawing.Point(238, 12);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(92, 30);
            this.metroButton2.TabIndex = 22;
            this.metroButton2.Text = "Search";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // Par
            // 
            this.Par.HeaderText = "Parameter";
            this.Par.Name = "Par";
            this.Par.ReadOnly = true;
            this.Par.Width = 180;
            // 
            // Valid_Values
            // 
            this.Valid_Values.HeaderText = "Valid Values";
            this.Valid_Values.Name = "Valid_Values";
            this.Valid_Values.ReadOnly = true;
            this.Valid_Values.Width = 150;
            // 
            // Default_value
            // 
            this.Default_value.HeaderText = "Default value";
            this.Default_value.Name = "Default_value";
            this.Default_value.ReadOnly = true;
            this.Default_value.Width = 150;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 500;
            // 
            // CreateLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 647);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroTextBox1);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.ParNameTextBox);
            this.Controls.Add(this.InfoTable);
            this.Controls.Add(this.ValueTextBox);
            this.Controls.Add(this.metroButton1);
            this.Name = "CreateLink";
            this.Text = "Link creator";
            ((System.ComponentModel.ISupportInitialize)(this.InfoTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroTextBox ValueTextBox;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private MetroFramework.Controls.MetroGrid InfoTable;
        private MetroFramework.Controls.MetroTextBox ParNameTextBox;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Par;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valid_Values;
        private System.Windows.Forms.DataGridViewTextBoxColumn Default_value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
    }
}