namespace ung
{
    partial class _frmNewFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_frmNewFile));
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.lbTieuDe = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this._btAdd = new System.Windows.Forms.Button();
            this._btCancal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelX1.Location = new System.Drawing.Point(166, 109);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Name";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelX2.Location = new System.Drawing.Point(166, 141);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(62, 23);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "Type";
            // 
            // textBoxName
            // 
            this.textBoxName.AcceptsTab = true;
            this.textBoxName.Location = new System.Drawing.Point(232, 111);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(245, 20);
            this.textBoxName.TabIndex = 10;
            // 
            // comboBoxType
            // 
            this.comboBoxType.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.Enabled = false;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "xls",
            "txt"});
            this.comboBoxType.Location = new System.Drawing.Point(234, 143);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(126, 21);
            this.comboBoxType.TabIndex = 11;
            // 
            // lbTieuDe
            // 
            // 
            // 
            // 
            this.lbTieuDe.BackgroundStyle.Class = "";
            this.lbTieuDe.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbTieuDe.Location = new System.Drawing.Point(216, 14);
            this.lbTieuDe.Margin = new System.Windows.Forms.Padding(4);
            this.lbTieuDe.Name = "lbTieuDe";
            this.lbTieuDe.Size = new System.Drawing.Size(175, 68);
            this.lbTieuDe.TabIndex = 39;
            this.lbTieuDe.Text = "<b><font size=\'26\' color=\'#00B7EF\'>New File</font></b>";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(118, 121);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            // 
            // _btAdd
            // 
            this._btAdd.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this._btAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btAdd.ForeColor = System.Drawing.Color.White;
            this._btAdd.Location = new System.Drawing.Point(232, 172);
            this._btAdd.Name = "_btAdd";
            this._btAdd.Size = new System.Drawing.Size(127, 23);
            this._btAdd.TabIndex = 41;
            this._btAdd.Text = "Add";
            this._btAdd.UseVisualStyleBackColor = false;
            this._btAdd.Click += new System.EventHandler(this._btAdd_Click_1);
            // 
            // _btCancal
            // 
            this._btCancal.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this._btCancal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btCancal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btCancal.ForeColor = System.Drawing.Color.White;
            this._btCancal.Location = new System.Drawing.Point(365, 172);
            this._btCancal.Name = "_btCancal";
            this._btCancal.Size = new System.Drawing.Size(112, 23);
            this._btCancal.TabIndex = 42;
            this._btCancal.Text = "Cancel";
            this._btCancal.UseVisualStyleBackColor = false;
            this._btCancal.Click += new System.EventHandler(this._btCancal_Click);
            // 
            // _frmNewFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(502, 209);
            this.Controls.Add(this._btCancal);
            this.Controls.Add(this._btAdd);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbTieuDe);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "_frmNewFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this._frmNewFile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        public System.Windows.Forms.TextBox textBoxName;
        public System.Windows.Forms.ComboBox comboBoxType;
        private DevComponents.DotNetBar.Controls.ReflectionLabel lbTieuDe;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button _btAdd;
        private System.Windows.Forms.Button _btCancal;
    }
}