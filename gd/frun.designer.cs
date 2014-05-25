namespace gd
{
    partial class frun
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._btRun = new System.Windows.Forms.Button();
            this._cboData = new System.Windows.Forms.ComboBox();
            this._txtScript = new System.Windows.Forms.TextBox();
            this._btCancel = new System.Windows.Forms.Button();
            this.lbTieuDe = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-60, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 54;
            this.label3.Text = "Data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-60, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "Browser";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-60, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "Script";
            // 
            // _btRun
            // 
            this._btRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this._btRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btRun.Location = new System.Drawing.Point(133, 184);
            this._btRun.Name = "_btRun";
            this._btRun.Size = new System.Drawing.Size(100, 44);
            this._btRun.TabIndex = 44;
            this._btRun.Text = "Run";
            this._btRun.UseVisualStyleBackColor = false;
            // 
            // _cboData
            // 
            this._cboData.FormattingEnabled = true;
            this._cboData.Location = new System.Drawing.Point(78, 142);
            this._cboData.Name = "_cboData";
            this._cboData.Size = new System.Drawing.Size(332, 21);
            this._cboData.TabIndex = 57;
            // 
            // _txtScript
            // 
            this._txtScript.BackColor = System.Drawing.SystemColors.Window;
            this._txtScript.Enabled = false;
            this._txtScript.Location = new System.Drawing.Point(78, 98);
            this._txtScript.Name = "_txtScript";
            this._txtScript.Size = new System.Drawing.Size(332, 20);
            this._txtScript.TabIndex = 55;
            // 
            // _btCancel
            // 
            this._btCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this._btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btCancel.Location = new System.Drawing.Point(264, 184);
            this._btCancel.Name = "_btCancel";
            this._btCancel.Size = new System.Drawing.Size(95, 44);
            this._btCancel.TabIndex = 48;
            this._btCancel.Text = "Cancel";
            this._btCancel.UseVisualStyleBackColor = false;
            this._btCancel.Click += new System.EventHandler(this._btCancel_Click_1);
            // 
            // lbTieuDe
            // 
            this.lbTieuDe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lbTieuDe.BackgroundStyle.Class = "";
            this.lbTieuDe.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTieuDe.Font = new System.Drawing.Font("Lucida Sans Typewriter", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTieuDe.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbTieuDe.Location = new System.Drawing.Point(5, 1);
            this.lbTieuDe.Margin = new System.Windows.Forms.Padding(4);
            this.lbTieuDe.Name = "lbTieuDe";
            this.lbTieuDe.Size = new System.Drawing.Size(483, 51);
            this.lbTieuDe.TabIndex = 51;
            this.lbTieuDe.Text = "<div align=\"center\">Run Test</div>";
            // 
            // frun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 238);
            this.Controls.Add(this._btCancel);
            this.Controls.Add(this._btRun);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbTieuDe);
            this.Controls.Add(this._cboData);
            this.Controls.Add(this._txtScript);
            this.Name = "frun";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frun";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _btRun;
        public System.Windows.Forms.ComboBox _cboData;
        public System.Windows.Forms.TextBox _txtScript;
        private System.Windows.Forms.Button _btCancel;
        private DevComponents.DotNetBar.Controls.ReflectionLabel lbTieuDe;
    }
}