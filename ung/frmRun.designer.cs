namespace ung
{
    partial class frmRun
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRun));
            this.lbTieuDe = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this._txtScript = new System.Windows.Forms.TextBox();
            this._cboData = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radRadioFireFox = new Telerik.WinControls.UI.RadRadioButton();
            this.radRadioIE = new Telerik.WinControls.UI.RadRadioButton();
            this.radRadioChrome = new Telerik.WinControls.UI.RadRadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btRun = new Telerik.WinControls.UI.RadButton();
            this.btCancel = new Telerik.WinControls.UI.RadButton();
            this.radThemeManager1 = new Telerik.WinControls.RadThemeManager();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioFireFox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioIE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioChrome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btRun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTieuDe
            // 
            // 
            // 
            // 
            this.lbTieuDe.BackgroundStyle.Class = "";
            this.lbTieuDe.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbTieuDe.Location = new System.Drawing.Point(103, 13);
            this.lbTieuDe.Margin = new System.Windows.Forms.Padding(4);
            this.lbTieuDe.Name = "lbTieuDe";
            this.lbTieuDe.Size = new System.Drawing.Size(360, 68);
            this.lbTieuDe.TabIndex = 40;
            this.lbTieuDe.Text = "<b><font size=\'26\' color=\'#00B7EF\'>Run Test Automation\r\n</font></b>";
            // 
            // _txtScript
            // 
            this._txtScript.BackColor = System.Drawing.SystemColors.Window;
            this._txtScript.Enabled = false;
            this._txtScript.Location = new System.Drawing.Point(208, 121);
            this._txtScript.Name = "_txtScript";
            this._txtScript.Size = new System.Drawing.Size(139, 20);
            this._txtScript.TabIndex = 45;
            // 
            // _cboData
            // 
            this._cboData.FormattingEnabled = true;
            this._cboData.Items.AddRange(new object[] {
            "None"});
            this._cboData.Location = new System.Drawing.Point(208, 160);
            this._cboData.Name = "_cboData";
            this._cboData.Size = new System.Drawing.Size(139, 21);
            this._cboData.TabIndex = 47;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radRadioFireFox);
            this.groupBox1.Controls.Add(this.radRadioIE);
            this.groupBox1.Controls.Add(this.radRadioChrome);
            this.groupBox1.Location = new System.Drawing.Point(364, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 132);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose Browser";
            // 
            // radRadioFireFox
            // 
            this.radRadioFireFox.Image = ((System.Drawing.Image)(resources.GetObject("radRadioFireFox.Image")));
            this.radRadioFireFox.Location = new System.Drawing.Point(21, 54);
            this.radRadioFireFox.Name = "radRadioFireFox";
            this.radRadioFireFox.Size = new System.Drawing.Size(130, 36);
            this.radRadioFireFox.TabIndex = 1;
            this.radRadioFireFox.Text = "FireFox";
            this.radRadioFireFox.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radRadioFireFox.ThemeName = "Desert";
            // 
            // radRadioIE
            // 
            this.radRadioIE.Image = ((System.Drawing.Image)(resources.GetObject("radRadioIE.Image")));
            this.radRadioIE.Location = new System.Drawing.Point(21, 83);
            this.radRadioIE.Name = "radRadioIE";
            this.radRadioIE.Size = new System.Drawing.Size(172, 43);
            this.radRadioIE.TabIndex = 1;
            this.radRadioIE.Text = "Internet Explore";
            this.radRadioIE.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radRadioIE.ThemeName = "Desert";
            // 
            // radRadioChrome
            // 
            this.radRadioChrome.Image = ((System.Drawing.Image)(resources.GetObject("radRadioChrome.Image")));
            this.radRadioChrome.ImageScalingSize = new System.Drawing.Size(10, 10);
            this.radRadioChrome.Location = new System.Drawing.Point(21, 16);
            this.radRadioChrome.Name = "radRadioChrome";
            this.radRadioChrome.Size = new System.Drawing.Size(130, 34);
            this.radRadioChrome.TabIndex = 0;
            this.radRadioChrome.TabStop = true;
            this.radRadioChrome.Text = "Chrome";
            this.radRadioChrome.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radRadioChrome.ThemeName = "Desert";
            this.radRadioChrome.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 111);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(116, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 50;
            this.pictureBox1.TabStop = false;
            // 
            // btRun
            // 
            this.btRun.BackColor = System.Drawing.Color.Transparent;
            this.btRun.Image = ((System.Drawing.Image)(resources.GetObject("btRun.Image")));
            this.btRun.Location = new System.Drawing.Point(174, 213);
            this.btRun.Name = "btRun";
            this.btRun.Size = new System.Drawing.Size(75, 24);
            this.btRun.TabIndex = 51;
            this.btRun.Text = "Run";
            this.btRun.ThemeName = "Aqua";
            this.btRun.Click += new System.EventHandler(this.btRun_Click);
            // 
            // btCancel
            // 
            this.btCancel.Image = ((System.Drawing.Image)(resources.GetObject("btCancel.Image")));
            this.btCancel.Location = new System.Drawing.Point(265, 213);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(82, 24);
            this.btCancel.TabIndex = 52;
            this.btCancel.Text = "Cancel";
            this.btCancel.ThemeName = "Aqua";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(152, 121);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(35, 18);
            this.radLabel1.TabIndex = 53;
            this.radLabel1.Text = "Script";
            this.radLabel1.ThemeName = "ControlDefault";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(152, 160);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(33, 17);
            this.radLabel2.TabIndex = 54;
            this.radLabel2.Text = "Data";
            this.radLabel2.ThemeName = "Aqua";
            // 
            // frmRun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(582, 260);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btRun);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._cboData);
            this.Controls.Add(this._txtScript);
            this.Controls.Add(this.lbTieuDe);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRun";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Run";
            this.ThemeName = "Aqua";
            this.Load += new System.EventHandler(this.frmRun_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radRadioFireFox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioIE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioChrome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btRun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ReflectionLabel lbTieuDe;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.TextBox _txtScript;
        public System.Windows.Forms.ComboBox _cboData;
        private Telerik.WinControls.UI.RadButton btRun;
        private Telerik.WinControls.UI.RadButton btCancel;
        private Telerik.WinControls.RadThemeManager radThemeManager1;
        private Telerik.WinControls.UI.RadRadioButton radRadioFireFox;
        private Telerik.WinControls.UI.RadRadioButton radRadioIE;
        private Telerik.WinControls.UI.RadRadioButton radRadioChrome;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
    }
}