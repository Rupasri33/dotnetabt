namespace AUI_Test
{
    partial class RadRibbonForm1
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
            this.radRibbonBar1 = new Telerik.WinControls.UI.RadRibbonBar();
            this.radStatusStrip1 = new Telerik.WinControls.UI.RadStatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.radRibbonBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radRibbonBar1
            // 
            this.radRibbonBar1.AutoSize = true;
            // 
            // 
            // 
            this.radRibbonBar1.ExitButton.AccessibleDescription = "Exit";
            this.radRibbonBar1.ExitButton.AccessibleName = "Exit";
            // 
            // 
            // 
            this.radRibbonBar1.ExitButton.ButtonElement.AccessibleDescription = "Exit";
            this.radRibbonBar1.ExitButton.ButtonElement.AccessibleName = "Exit";
            this.radRibbonBar1.ExitButton.ButtonElement.Class = "RadMenuButtonElement";
            this.radRibbonBar1.ExitButton.ButtonElement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radRibbonBar1.ExitButton.Text = "Exit";
            this.radRibbonBar1.Location = new System.Drawing.Point(0, 0);
            this.radRibbonBar1.Name = "radRibbonBar1";
            // 
            // 
            // 
            this.radRibbonBar1.OptionsButton.AccessibleDescription = "Options";
            this.radRibbonBar1.OptionsButton.AccessibleName = "Options";
            // 
            // 
            // 
            this.radRibbonBar1.OptionsButton.ButtonElement.AccessibleDescription = "Options";
            this.radRibbonBar1.OptionsButton.ButtonElement.AccessibleName = "Options";
            this.radRibbonBar1.OptionsButton.ButtonElement.Class = "RadMenuButtonElement";
            this.radRibbonBar1.OptionsButton.ButtonElement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radRibbonBar1.OptionsButton.Text = "Options";
            // 
            // 
            // 
            this.radRibbonBar1.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.radRibbonBar1.Size = new System.Drawing.Size(474, 144);
            this.radRibbonBar1.StartButtonImage = null;
            this.radRibbonBar1.TabIndex = 0;
            this.radRibbonBar1.Text = "RadRibbonForm1";
            // 
            // radStatusStrip1
            // 
            this.radStatusStrip1.AutoSize = true;
            this.radStatusStrip1.LayoutStyle = Telerik.WinControls.UI.RadStatusBarLayoutStyle.Stack;
            this.radStatusStrip1.Location = new System.Drawing.Point(0, 401);
            this.radStatusStrip1.Name = "radStatusStrip1";
            this.radStatusStrip1.Size = new System.Drawing.Size(474, 24);
            this.radStatusStrip1.SizingGrip = false;
            this.radStatusStrip1.TabIndex = 1;
            this.radStatusStrip1.Text = "radStatusStrip1";
            this.radStatusStrip1.StatusBarClick += new Telerik.WinControls.UI.RadStatusStrip.RadStatusBarClickEvenHandler(this.radStatusStrip1_StatusBarClick);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 144);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(474, 257);
            this.panel1.TabIndex = 2;
            // 
            // RadRibbonForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 425);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.radStatusStrip1);
            this.Controls.Add(this.radRibbonBar1);
            this.Name = "RadRibbonForm1";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "RadRibbonForm1";
            ((System.ComponentModel.ISupportInitialize)(this.radRibbonBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadRibbonBar radRibbonBar1;
        private Telerik.WinControls.UI.RadStatusStrip radStatusStrip1;
        private System.Windows.Forms.Panel panel1;
    }
}
