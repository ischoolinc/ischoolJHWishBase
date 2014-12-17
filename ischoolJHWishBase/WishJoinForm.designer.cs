namespace ischoolJHWishBase
{
    partial class WishJoinForm
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
            this.components = new System.ComponentModel.Container();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.tbStartDateTime = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tbEndDateTime = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F);
            this.btnSave.Location = new System.Drawing.Point(200, 85);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "儲存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F);
            this.btnClose.Location = new System.Drawing.Point(281, 85);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "離開";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.labelX1.Location = new System.Drawing.Point(22, 13);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(87, 21);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "開始輸入時間";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(199, 13);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(87, 21);
            this.labelX2.TabIndex = 3;
            this.labelX2.Text = "結束輸入時間";
            // 
            // tbStartDateTime
            // 
            // 
            // 
            // 
            this.tbStartDateTime.Border.Class = "TextBoxBorder";
            this.tbStartDateTime.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbStartDateTime.Location = new System.Drawing.Point(22, 44);
            this.tbStartDateTime.Name = "tbStartDateTime";
            this.tbStartDateTime.Size = new System.Drawing.Size(157, 25);
            this.tbStartDateTime.TabIndex = 2;
            this.tbStartDateTime.WatermarkText = "2012/8/11 19:00";
            this.tbStartDateTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbStartDateTime_KeyDown);
            this.tbStartDateTime.Validated += new System.EventHandler(this.tbStartDateTime_Validated);
            // 
            // tbEndDateTime
            // 
            // 
            // 
            // 
            this.tbEndDateTime.Border.Class = "TextBoxBorder";
            this.tbEndDateTime.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbEndDateTime.Location = new System.Drawing.Point(199, 44);
            this.tbEndDateTime.Name = "tbEndDateTime";
            this.tbEndDateTime.Size = new System.Drawing.Size(157, 25);
            this.tbEndDateTime.TabIndex = 4;
            this.tbEndDateTime.WatermarkText = "2012/8/15 23:00";
            this.tbEndDateTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbEndDateTime_KeyDown);
            this.tbEndDateTime.Validated += new System.EventHandler(this.tbEndDateTime_Validated);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // WishJoinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 120);
            this.Controls.Add(this.tbEndDateTime);
            this.Controls.Add(this.tbStartDateTime);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.DoubleBuffered = true;
            this.Name = "WishJoinForm";
            this.Text = "志願比序開放時間";
            this.Load += new System.EventHandler(this.RetakeJoinDateTime_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX tbStartDateTime;
        private DevComponents.DotNetBar.Controls.TextBoxX tbEndDateTime;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
    }
}