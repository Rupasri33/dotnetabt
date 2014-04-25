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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._btRun = new System.Windows.Forms.Button();
            this._txtScript = new System.Windows.Forms.TextBox();
            this._cboBrowser = new System.Windows.Forms.ComboBox();
            this._cboData = new System.Windows.Forms.ComboBox();
            this._btCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTieuDe
            // 
            // 
            // 
            // 
            this.lbTieuDe.BackgroundStyle.Class = "";
            this.lbTieuDe.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbTieuDe.Location = new System.Drawing.Point(158, 14);
            this.lbTieuDe.Margin = new System.Windows.Forms.Padding(4);
            this.lbTieuDe.Name = "lbTieuDe";
            this.lbTieuDe.Size = new System.Drawing.Size(166, 68);
            this.lbTieuDe.TabIndex = 40;
            this.lbTieuDe.Text = "<b><font size=\'26\' color=\'#00B7EF\'>Run Test</font></b>";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Script";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Browser";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Data";
            // 
            // _btRun
            // 
            this._btRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btRun.Location = new System.Drawing.Point(21, 19);
            this._btRun.Name = "_btRun";
            this._btRun.Size = new System.Drawing.Size(81, 27);
            this._btRun.TabIndex = 44;
            this._btRun.Text = "Run";
            this._btRun.UseVisualStyleBackColor = true;
            this._btRun.Click += new System.EventHandler(this._btRun_Click);
            // 
            // _txtScript
            // 
            this._txtScript.BackColor = System.Drawing.SystemColors.Window;
            this._txtScript.Enabled = false;
            this._txtScript.Location = new System.Drawing.Point(115, 113);
            this._txtScript.Name = "_txtScript";
            this._txtScript.Size = new System.Drawing.Size(204, 20);
            this._txtScript.TabIndex = 45;
            // 
            // _cboBrowser
            // 
            this._cboBrowser.FormattingEnabled = true;
            this._cboBrowser.Items.AddRange(new object[] {
            "FireFox",
            "Chrome",
            "Internet Explorer"});
            this._cboBrowser.Location = new System.Drawing.Point(115, 150);
            this._cboBrowser.Name = "_cboBrowser";
            this._cboBrowser.Size = new System.Drawing.Size(204, 21);
            this._cboBrowser.TabIndex = 46;
            // 
            // _cboData
            // 
            this._cboData.FormattingEnabled = true;
            this._cboData.Location = new System.Drawing.Point(115, 182);
            this._cboData.Name = "_cboData";
            this._cboData.Size = new System.Drawing.Size(204, 21);
            this._cboData.TabIndex = 47;
            // 
            // _btCancel
            // 
            this._btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btCancel.Location = new System.Drawing.Point(21, 50);
            this._btCancel.Name = "_btCancel";
            this._btCancel.Size = new System.Drawing.Size(81, 27);
            this._btCancel.TabIndex = 48;
            this._btCancel.Text = "Cancel";
            this._btCancel.UseVisualStyleBackColor = true;
            this._btCancel.Click += new System.EventHandler(this._btCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._btRun);
            this.groupBox1.Controls.Add(this._btCancel);
            this.groupBox1.Location = new System.Drawing.Point(347, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(116, 90);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Option";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(99, 87);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 50;
            this.pictureBox1.TabStop = false;
            // 
            // frmRun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(486, 219);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._cboData);
            this.Controls.Add(this._cboBrowser);
            this.Controls.Add(this._txtScript);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbTieuDe);
            this.Name = "frmRun";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRun";
            this.Load += new System.EventHandler(this.frmRun_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ReflectionLabel lbTieuDe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button _btRun;
        private System.Windows.Forms.Button _btCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.TextBox _txtScript;
        public System.Windows.Forms.ComboBox _cboBrowser;
        public System.Windows.Forms.ComboBox _cboData;
    }
}