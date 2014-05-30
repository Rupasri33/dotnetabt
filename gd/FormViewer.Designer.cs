namespace uia_gui.forms
{
    partial class FormViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormViewer));
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.windowsViewer1 = new uia_gui.components.WindowsViewer();
            this.splitContainerSub = new System.Windows.Forms.SplitContainer();
            this.propertiesViewer1 = new uia_gui.components.PropertiesViewer();
            this.matchesViewer1 = new uia_gui.components.MatchesViewer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolstripBtnRefresh = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSub)).BeginInit();
            this.splitContainerSub.Panel1.SuspendLayout();
            this.splitContainerSub.Panel2.SuspendLayout();
            this.splitContainerSub.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Location = new System.Drawing.Point(0, 27);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.windowsViewer1);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.splitContainerSub);
            this.splitContainerMain.Size = new System.Drawing.Size(804, 422);
            this.splitContainerMain.SplitterDistance = 245;
            this.splitContainerMain.TabIndex = 0;
            // 
            // windowsViewer1
            // 
            this.windowsViewer1.ActionManager = null;
            this.windowsViewer1.CurrentInterface = null;
            this.windowsViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowsViewer1.Location = new System.Drawing.Point(0, 0);
            this.windowsViewer1.Margin = new System.Windows.Forms.Padding(5);
            this.windowsViewer1.Name = "windowsViewer1";
            this.windowsViewer1.Padding = new System.Windows.Forms.Padding(5);
            this.windowsViewer1.Size = new System.Drawing.Size(245, 422);
            this.windowsViewer1.TabIndex = 0;
            this.windowsViewer1.SelectedItemChanged += new uia_gui.components.SelectedItemChangedHandler(this.windowsViewer1_SelectedItemChanged);
            // 
            // splitContainerSub
            // 
            this.splitContainerSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerSub.Location = new System.Drawing.Point(0, 0);
            this.splitContainerSub.Name = "splitContainerSub";
            // 
            // splitContainerSub.Panel1
            // 
            this.splitContainerSub.Panel1.Controls.Add(this.propertiesViewer1);
            // 
            // splitContainerSub.Panel2
            // 
            this.splitContainerSub.Panel2.Controls.Add(this.matchesViewer1);
            this.splitContainerSub.Size = new System.Drawing.Size(555, 422);
            this.splitContainerSub.SplitterDistance = 354;
            this.splitContainerSub.TabIndex = 0;
            // 
            // propertiesViewer1
            // 
            this.propertiesViewer1.ActionManager = null;
            this.propertiesViewer1.CurrentInterface = null;
            this.propertiesViewer1.CurrentName = null;
            this.propertiesViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertiesViewer1.Location = new System.Drawing.Point(0, 0);
            this.propertiesViewer1.Name = "propertiesViewer1";
            this.propertiesViewer1.Object = null;
            this.propertiesViewer1.Padding = new System.Windows.Forms.Padding(5);
            this.propertiesViewer1.Size = new System.Drawing.Size(354, 422);
            this.propertiesViewer1.TabIndex = 0;
            this.propertiesViewer1.InvalidItemSelected += new uia_gui.components.InvalidItemHandler(this.propertiesViewer1_InvalidItemSelected);
            // 
            // matchesViewer1
            // 
            this.matchesViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.matchesViewer1.Location = new System.Drawing.Point(0, 0);
            this.matchesViewer1.Name = "matchesViewer1";
            this.matchesViewer1.Padding = new System.Windows.Forms.Padding(5);
            this.matchesViewer1.Size = new System.Drawing.Size(197, 422);
            this.matchesViewer1.TabIndex = 0;
            this.matchesViewer1.ControlSelected += new uia_gui.components.ControlSelectedHandler(this.matchesViewer1_ControlSelected);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 452);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(804, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "Ready";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstripBtnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(804, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolstripBtnRefresh
            // 
            this.toolstripBtnRefresh.Enabled = false;
            this.toolstripBtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolstripBtnRefresh.Image")));
            this.toolstripBtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstripBtnRefresh.Name = "toolstripBtnRefresh";
            this.toolstripBtnRefresh.Size = new System.Drawing.Size(66, 22);
            this.toolstripBtnRefresh.Text = "Refresh";
            this.toolstripBtnRefresh.Click += new System.EventHandler(this.toolstripBtnRefresh_Click);
            // 
            // FormViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 474);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainerMain);
            this.Name = "FormViewer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Viewer";
            this.Load += new System.EventHandler(this.FormViewer_Load);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainerSub.Panel1.ResumeLayout(false);
            this.splitContainerSub.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSub)).EndInit();
            this.splitContainerSub.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainerSub;
        private uia_gui.components.WindowsViewer windowsViewer1;
        private uia_gui.components.PropertiesViewer propertiesViewer1;
        private uia_gui.components.MatchesViewer matchesViewer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolstripBtnRefresh;
    }
}