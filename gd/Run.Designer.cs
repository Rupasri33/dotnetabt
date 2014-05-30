namespace gd
{
    partial class Run
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Run));
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this._txtScript = new Telerik.WinControls.UI.RadTextBox();
            this._cboData = new System.Windows.Forms.ComboBox();
            this.btRun = new Telerik.WinControls.UI.RadButton();
            this.btCancel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this._txtScript)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btRun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(31, 28);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "Script";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(31, 77);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "Data";
            // 
            // _txtScript
            // 
            this._txtScript.Enabled = false;
            this._txtScript.Location = new System.Drawing.Point(96, 34);
            this._txtScript.Name = "_txtScript";
            this._txtScript.Size = new System.Drawing.Size(213, 20);
            this._txtScript.TabIndex = 3;
            this._txtScript.TabStop = false;
            // 
            // _cboData
            // 
            this._cboData.FormattingEnabled = true;
            this._cboData.Items.AddRange(new object[] {
            "xls"});
            this._cboData.Location = new System.Drawing.Point(96, 79);
            this._cboData.Name = "_cboData";
            this._cboData.Size = new System.Drawing.Size(213, 21);
            this._cboData.TabIndex = 4;
            // 
            // btRun
            // 
            this.btRun.Image = ((System.Drawing.Image)(resources.GetObject("btRun.Image")));
            this.btRun.Location = new System.Drawing.Point(111, 122);
            this.btRun.Name = "btRun";
            this.btRun.Size = new System.Drawing.Size(84, 24);
            this.btRun.TabIndex = 5;
            this.btRun.Text = "Run";
            this.btRun.ThemeName = "ControlDefault";
            this.btRun.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btCancel
            // 
            this.btCancel.Image = ((System.Drawing.Image)(resources.GetObject("btCancel.Image")));
            this.btCancel.Location = new System.Drawing.Point(217, 122);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(78, 24);
            this.btCancel.TabIndex = 6;
            this.btCancel.Text = "Cancel";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // Run
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 182);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btRun);
            this.Controls.Add(this._cboData);
            this.Controls.Add(this._txtScript);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Name = "Run";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Run";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this._txtScript)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btRun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        public Telerik.WinControls.UI.RadTextBox _txtScript;
        public System.Windows.Forms.ComboBox _cboData;
        private Telerik.WinControls.UI.RadButton btRun;
        private Telerik.WinControls.UI.RadButton btCancel;
    }
}
