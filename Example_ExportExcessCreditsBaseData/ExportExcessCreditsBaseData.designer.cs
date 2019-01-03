namespace ExportExcessCreditsBaseData
{
    partial class ExportExcessCreditsBaseData
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
            this.btnExport = new DevComponents.DotNetBar.ButtonX();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.cboType1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.dgStudD1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.dgSel1cbo1 = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.dgSel1cbo2 = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.dgStudD2 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.dgSel2cbo1 = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.dgSel2cbo2 = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.cboType2 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboType3 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboType4 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboType5 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.cboType6 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.cboType7 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.integerInput1 = new DevComponents.Editors.IntegerInput();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.dgStudD1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgStudD2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExport
            // 
            this.btnExport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.AutoSize = true;
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExport.Location = new System.Drawing.Point(303, 491);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 25);
            this.btnExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExport.TabIndex = 8;
            this.btnExport.Text = "產生";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.AutoSize = true;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExit.Location = new System.Drawing.Point(389, 491);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "離開";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(21, 14);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(60, 21);
            this.labelX1.TabIndex = 3;
            this.labelX1.Text = "地區代碼";
            // 
            // labelX2
            // 
            this.labelX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(19, 381);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(60, 21);
            this.labelX2.TabIndex = 4;
            this.labelX2.Text = "低收入戶";
            // 
            // labelX3
            // 
            this.labelX3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelX3.AutoSize = true;
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(5, 414);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(74, 21);
            this.labelX3.TabIndex = 5;
            this.labelX3.Text = "中低收入戶";
            // 
            // labelX4
            // 
            this.labelX4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelX4.AutoSize = true;
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(19, 449);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(60, 21);
            this.labelX4.TabIndex = 6;
            this.labelX4.Text = "失業勞工";
            // 
            // labelX5
            // 
            this.labelX5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelX5.AutoSize = true;
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(20, 45);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(60, 21);
            this.labelX5.TabIndex = 7;
            this.labelX5.Text = "學生身分";
            // 
            // labelX6
            // 
            this.labelX6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelX6.AutoSize = true;
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.Class = "";
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(19, 209);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(60, 21);
            this.labelX6.TabIndex = 8;
            this.labelX6.Text = "身心障礙";
            // 
            // cboType1
            // 
            this.cboType1.DisplayMember = "Text";
            this.cboType1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboType1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType1.FormattingEnabled = true;
            this.cboType1.ItemHeight = 19;
            this.cboType1.Location = new System.Drawing.Point(89, 12);
            this.cboType1.Name = "cboType1";
            this.cboType1.Size = new System.Drawing.Size(165, 25);
            this.cboType1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboType1.TabIndex = 0;
            // 
            // dgStudD1
            // 
            this.dgStudD1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgStudD1.BackgroundColor = System.Drawing.Color.White;
            this.dgStudD1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStudD1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgSel1cbo1,
            this.dgSel1cbo2});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgStudD1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgStudD1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgStudD1.Location = new System.Drawing.Point(17, 72);
            this.dgStudD1.Name = "dgStudD1";
            this.dgStudD1.RowTemplate.Height = 24;
            this.dgStudD1.Size = new System.Drawing.Size(451, 131);
            this.dgStudD1.TabIndex = 1;
            this.dgStudD1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgStudD1_CellValueChanged);
            // 
            // dgSel1cbo1
            // 
            this.dgSel1cbo1.DisplayMember = "Text";
            this.dgSel1cbo1.DropDownHeight = 106;
            this.dgSel1cbo1.DropDownWidth = 121;
            this.dgSel1cbo1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgSel1cbo1.HeaderText = "類別名稱";
            this.dgSel1cbo1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgSel1cbo1.IntegralHeight = false;
            this.dgSel1cbo1.ItemHeight = 17;
            this.dgSel1cbo1.Name = "dgSel1cbo1";
            this.dgSel1cbo1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgSel1cbo1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgSel1cbo1.Width = 200;
            // 
            // dgSel1cbo2
            // 
            this.dgSel1cbo2.DisplayMember = "Text";
            this.dgSel1cbo2.DropDownHeight = 106;
            this.dgSel1cbo2.DropDownWidth = 121;
            this.dgSel1cbo2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgSel1cbo2.HeaderText = "對照內容";
            this.dgSel1cbo2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgSel1cbo2.IntegralHeight = false;
            this.dgSel1cbo2.ItemHeight = 17;
            this.dgSel1cbo2.Name = "dgSel1cbo2";
            this.dgSel1cbo2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgSel1cbo2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgSel1cbo2.Width = 200;
            // 
            // dgStudD2
            // 
            this.dgStudD2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgStudD2.BackgroundColor = System.Drawing.Color.White;
            this.dgStudD2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStudD2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgSel2cbo1,
            this.dgSel2cbo2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgStudD2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgStudD2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgStudD2.Location = new System.Drawing.Point(17, 236);
            this.dgStudD2.Name = "dgStudD2";
            this.dgStudD2.RowTemplate.Height = 24;
            this.dgStudD2.Size = new System.Drawing.Size(451, 131);
            this.dgStudD2.TabIndex = 2;
            this.dgStudD2.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgStudD2_CellValueChanged);
            // 
            // dgSel2cbo1
            // 
            this.dgSel2cbo1.DisplayMember = "Text";
            this.dgSel2cbo1.DropDownHeight = 106;
            this.dgSel2cbo1.DropDownWidth = 121;
            this.dgSel2cbo1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgSel2cbo1.HeaderText = "類別名稱";
            this.dgSel2cbo1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgSel2cbo1.IntegralHeight = false;
            this.dgSel2cbo1.ItemHeight = 17;
            this.dgSel2cbo1.Name = "dgSel2cbo1";
            this.dgSel2cbo1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgSel2cbo1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgSel2cbo1.Width = 200;
            // 
            // dgSel2cbo2
            // 
            this.dgSel2cbo2.DisplayMember = "Text";
            this.dgSel2cbo2.DropDownHeight = 106;
            this.dgSel2cbo2.DropDownWidth = 121;
            this.dgSel2cbo2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgSel2cbo2.HeaderText = "對照內容";
            this.dgSel2cbo2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgSel2cbo2.IntegralHeight = false;
            this.dgSel2cbo2.ItemHeight = 17;
            this.dgSel2cbo2.Name = "dgSel2cbo2";
            this.dgSel2cbo2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgSel2cbo2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgSel2cbo2.Width = 200;
            // 
            // cboType2
            // 
            this.cboType2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboType2.DisplayMember = "Text";
            this.cboType2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboType2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType2.FormattingEnabled = true;
            this.cboType2.ItemHeight = 19;
            this.cboType2.Location = new System.Drawing.Point(87, 379);
            this.cboType2.Name = "cboType2";
            this.cboType2.Size = new System.Drawing.Size(165, 25);
            this.cboType2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboType2.TabIndex = 3;
            // 
            // cboType3
            // 
            this.cboType3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboType3.DisplayMember = "Text";
            this.cboType3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboType3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType3.FormattingEnabled = true;
            this.cboType3.ItemHeight = 19;
            this.cboType3.Location = new System.Drawing.Point(87, 412);
            this.cboType3.Name = "cboType3";
            this.cboType3.Size = new System.Drawing.Size(165, 25);
            this.cboType3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboType3.TabIndex = 4;
            // 
            // cboType4
            // 
            this.cboType4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboType4.DisplayMember = "Text";
            this.cboType4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboType4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType4.FormattingEnabled = true;
            this.cboType4.ItemHeight = 19;
            this.cboType4.Location = new System.Drawing.Point(87, 447);
            this.cboType4.Name = "cboType4";
            this.cboType4.Size = new System.Drawing.Size(165, 25);
            this.cboType4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboType4.TabIndex = 5;
            // 
            // cboType5
            // 
            this.cboType5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboType5.DisplayMember = "Text";
            this.cboType5.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboType5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType5.FormattingEnabled = true;
            this.cboType5.ItemHeight = 19;
            this.cboType5.Location = new System.Drawing.Point(303, 377);
            this.cboType5.Name = "cboType5";
            this.cboType5.Size = new System.Drawing.Size(165, 25);
            this.cboType5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboType5.TabIndex = 6;
            // 
            // labelX7
            // 
            this.labelX7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelX7.AutoSize = true;
            this.labelX7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.Class = "";
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(265, 379);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(34, 21);
            this.labelX7.TabIndex = 10;
            this.labelX7.Text = "地址";
            // 
            // cboType6
            // 
            this.cboType6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboType6.DisplayMember = "Text";
            this.cboType6.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboType6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType6.FormattingEnabled = true;
            this.cboType6.ItemHeight = 19;
            this.cboType6.Location = new System.Drawing.Point(303, 410);
            this.cboType6.Name = "cboType6";
            this.cboType6.Size = new System.Drawing.Size(165, 25);
            this.cboType6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboType6.TabIndex = 7;
            // 
            // labelX8
            // 
            this.labelX8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelX8.AutoSize = true;
            this.labelX8.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.Class = "";
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(265, 412);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(34, 21);
            this.labelX8.TabIndex = 12;
            this.labelX8.Text = "電話";
            // 
            // cboType7
            // 
            this.cboType7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboType7.DisplayMember = "Text";
            this.cboType7.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboType7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType7.FormattingEnabled = true;
            this.cboType7.ItemHeight = 19;
            this.cboType7.Location = new System.Drawing.Point(303, 446);
            this.cboType7.Name = "cboType7";
            this.cboType7.Size = new System.Drawing.Size(165, 25);
            this.cboType7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboType7.TabIndex = 13;
            // 
            // labelX9
            // 
            this.labelX9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelX9.AutoSize = true;
            this.labelX9.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.Class = "";
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(265, 447);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(34, 21);
            this.labelX9.TabIndex = 14;
            this.labelX9.Text = "家長";
            // 
            // integerInput1
            // 
            this.integerInput1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.integerInput1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.integerInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.integerInput1.ButtonFreeText.Checked = true;
            this.integerInput1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.integerInput1.FreeTextEntryMode = true;
            this.integerInput1.Location = new System.Drawing.Point(350, 12);
            this.integerInput1.MaxValue = 999;
            this.integerInput1.MinValue = 90;
            this.integerInput1.Name = "integerInput1";
            this.integerInput1.ShowUpDown = true;
            this.integerInput1.Size = new System.Drawing.Size(80, 25);
            this.integerInput1.TabIndex = 15;
            this.integerInput1.Value = 90;
            // 
            // labelX10
            // 
            this.labelX10.AutoSize = true;
            this.labelX10.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.Class = "";
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(297, 14);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(47, 21);
            this.labelX10.TabIndex = 16;
            this.labelX10.Text = "畢業年";
            // 
            // ExportExcessCreditsBaseData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 528);
            this.Controls.Add(this.labelX10);
            this.Controls.Add(this.integerInput1);
            this.Controls.Add(this.cboType7);
            this.Controls.Add(this.labelX9);
            this.Controls.Add(this.cboType6);
            this.Controls.Add(this.labelX8);
            this.Controls.Add(this.cboType5);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.cboType4);
            this.Controls.Add(this.cboType3);
            this.Controls.Add(this.cboType2);
            this.Controls.Add(this.dgStudD2);
            this.Controls.Add(this.dgStudD1);
            this.Controls.Add(this.cboType1);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnExport);
            this.DoubleBuffered = true;
            this.Name = "ExportExcessCreditsBaseData";
            this.Text = "學生會考報名檔";
            this.Load += new System.EventHandler(this.ExportExcessCreditsBaseData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgStudD1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgStudD2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnExport;
        private DevComponents.DotNetBar.ButtonX btnExit;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboType1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgStudD1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgStudD2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboType2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboType3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboType4;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn dgSel1cbo1;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn dgSel1cbo2;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn dgSel2cbo1;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn dgSel2cbo2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboType5;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboType6;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboType7;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.Editors.IntegerInput integerInput1;
        private DevComponents.DotNetBar.LabelX labelX10;
    }
}