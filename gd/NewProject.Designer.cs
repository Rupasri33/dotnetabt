namespace gd
{
    partial class NewProject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewProject));
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtName = new Telerik.WinControls.UI.RadTextBox();
            this.txtBrowse = new Telerik.WinControls.UI.RadTextBox();
            this.btRun = new Telerik.WinControls.UI.RadButton();
            this.btCancel = new Telerik.WinControls.UI.RadButton();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBrowse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btRun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
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
            this.labelX1.Location = new System.Drawing.Point(39, 36);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "Name Project";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(39, 83);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 3;
            this.labelX2.Text = "Location";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(144, 39);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(213, 20);
            this.txtName.TabIndex = 4;
            this.txtName.TabStop = false;
            // 
            // txtBrowse
            // 
            this.txtBrowse.Location = new System.Drawing.Point(144, 83);
            this.txtBrowse.Name = "txtBrowse";
            this.txtBrowse.NullText = "Choose Location...";
            this.txtBrowse.Size = new System.Drawing.Size(213, 20);
            this.txtBrowse.TabIndex = 4;
            this.txtBrowse.TabStop = false;
            // 
            // btRun
            // 
            this.btRun.Image = ((System.Drawing.Image)(resources.GetObject("btRun.Image")));
            this.btRun.Location = new System.Drawing.Point(144, 140);
            this.btRun.Name = "btRun";
            this.btRun.Size = new System.Drawing.Size(91, 24);
            this.btRun.TabIndex = 6;
            this.btRun.Text = "OK";
            this.btRun.ThemeName = "ControlDefault";
            this.btRun.Click += new System.EventHandler(this.btRun_Click);
            // 
            // btCancel
            // 
            this.btCancel.Image = ((System.Drawing.Image)(resources.GetObject("btCancel.Image")));
            this.btCancel.Location = new System.Drawing.Point(261, 140);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(96, 24);
            this.btCancel.TabIndex = 7;
            this.btCancel.Text = "Cancel";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // radButton1
            // 
            this.radButton1.Image = ((System.Drawing.Image)(resources.GetObject("radButton1.Image")));
            this.radButton1.Location = new System.Drawing.Point(379, 82);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(91, 24);
            this.radButton1.TabIndex = 8;
            this.radButton1.Text = "Browse...";
            this.radButton1.ThemeName = "ControlDefault";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // NewProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 205);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btRun);
            this.Controls.Add(this.txtBrowse);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Name = "NewProject";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Project";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.NewProject_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBrowse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btRun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        public Telerik.WinControls.UI.RadTextBox txtName;
        public Telerik.WinControls.UI.RadTextBox txtBrowse;
        private Telerik.WinControls.UI.RadButton btRun;
        private Telerik.WinControls.UI.RadButton btCancel;
        private Telerik.WinControls.UI.RadButton radButton1;
    }
}
