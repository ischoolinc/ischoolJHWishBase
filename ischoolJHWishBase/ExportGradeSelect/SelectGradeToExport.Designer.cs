namespace ischoolJHWishBase.ExportGradeSelect
{
    partial class SelectGradeToExport
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
            this.comboGrade = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.btnExport = new DevComponents.DotNetBar.ButtonX();
            this.labNote = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // comboGrade
            // 
            this.comboGrade.DisplayMember = "Text";
            this.comboGrade.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGrade.FormattingEnabled = true;
            this.comboGrade.ItemHeight = 19;
            this.comboGrade.Location = new System.Drawing.Point(113, 51);
            this.comboGrade.Name = "comboGrade";
            this.comboGrade.Size = new System.Drawing.Size(87, 25);
            this.comboGrade.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboGrade.TabIndex = 0;
            this.comboGrade.SelectedIndexChanged += new System.EventHandler(this.comboGrade_SelectedIndexChanged);
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(60, 52);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(48, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "年級：";
            // 
            // btnExport
            // 
            this.btnExport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExport.Location = new System.Drawing.Point(180, 126);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "產出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // labNote
            // 
            this.labNote.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labNote.Location = new System.Drawing.Point(35, 89);
            this.labNote.Name = "labNote";
            this.labNote.Size = new System.Drawing.Size(210, 23);
            this.labNote.TabIndex = 3;
            this.labNote.Text = "產出前請確認已「計算比序積分」";
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(12, 12);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(92, 23);
            this.labelX2.TabIndex = 4;
            this.labelX2.Text = "請選擇年級：";
            // 
            // SelectGradeToExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 161);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labNote);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.comboGrade);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(283, 200);
            this.MinimumSize = new System.Drawing.Size(283, 200);
            this.Name = "SelectGradeToExport";
            this.Text = "產生志願比序資料";
            this.Load += new System.EventHandler(this.SelectGradeToExport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ComboBoxEx comboGrade;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX btnExport;
        private DevComponents.DotNetBar.LabelX labNote;
        private DevComponents.DotNetBar.LabelX labelX2;
    }
}