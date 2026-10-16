
namespace ahbs
{
    partial class doktorGirisi
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
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.txtSifre = new MaterialSkin.Controls.MaterialTextBox2();
            this.btnGiris = new MaterialSkin.Controls.MaterialButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtKimlikNo = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(36, 266);
            this.materialLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(118, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Kimlik Numarası";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(36, 319);
            this.materialLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(34, 19);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "Şifre";
            // 
            // txtSifre
            // 
            this.txtSifre.AnimateReadOnly = false;
            this.txtSifre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtSifre.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSifre.Depth = 0;
            this.txtSifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtSifre.HideSelection = true;
            this.txtSifre.LeadingIcon = null;
            this.txtSifre.LeaveOnEnterKey = true;
            this.txtSifre.Location = new System.Drawing.Point(159, 310);
            this.txtSifre.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSifre.MaxLength = 32767;
            this.txtSifre.MouseState = MaterialSkin.MouseState.OUT;
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '*';
            this.txtSifre.PrefixSuffixText = null;
            this.txtSifre.ReadOnly = false;
            this.txtSifre.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSifre.SelectedText = "";
            this.txtSifre.SelectionLength = 0;
            this.txtSifre.SelectionStart = 0;
            this.txtSifre.ShortcutsEnabled = true;
            this.txtSifre.Size = new System.Drawing.Size(218, 36);
            this.txtSifre.TabIndex = 3;
            this.txtSifre.TabStop = false;
            this.txtSifre.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSifre.TrailingIcon = null;
            this.txtSifre.UseSystemPasswordChar = false;
            this.txtSifre.UseTallSize = false;
            this.txtSifre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSifre_KeyPress);
            // 
            // btnGiris
            // 
            this.btnGiris.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGiris.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnGiris.Depth = 0;
            this.btnGiris.HighEmphasis = true;
            this.btnGiris.Icon = null;
            this.btnGiris.Location = new System.Drawing.Point(322, 359);
            this.btnGiris.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnGiris.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnGiris.Size = new System.Drawing.Size(64, 36);
            this.btnGiris.TabIndex = 4;
            this.btnGiris.Text = "giriş";
            this.btnGiris.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnGiris.UseAccentColor = false;
            this.btnGiris.UseVisualStyleBackColor = true;
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ahbs.Properties.Resources.Doctor_PNG_Picture;
            this.pictureBox1.Location = new System.Drawing.Point(116, 72);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(191, 149);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // txtKimlikNo
            // 
            this.txtKimlikNo.AnimateReadOnly = false;
            this.txtKimlikNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtKimlikNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtKimlikNo.Depth = 0;
            this.txtKimlikNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtKimlikNo.HideSelection = true;
            this.txtKimlikNo.LeadingIcon = null;
            this.txtKimlikNo.LeaveOnEnterKey = true;
            this.txtKimlikNo.Location = new System.Drawing.Point(159, 257);
            this.txtKimlikNo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtKimlikNo.MaxLength = 11;
            this.txtKimlikNo.MouseState = MaterialSkin.MouseState.OUT;
            this.txtKimlikNo.Name = "txtKimlikNo";
            this.txtKimlikNo.PasswordChar = '\0';
            this.txtKimlikNo.PrefixSuffixText = null;
            this.txtKimlikNo.ReadOnly = false;
            this.txtKimlikNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtKimlikNo.SelectedText = "";
            this.txtKimlikNo.SelectionLength = 0;
            this.txtKimlikNo.SelectionStart = 0;
            this.txtKimlikNo.ShortcutsEnabled = true;
            this.txtKimlikNo.Size = new System.Drawing.Size(218, 36);
            this.txtKimlikNo.TabIndex = 2;
            this.txtKimlikNo.TabStop = false;
            this.txtKimlikNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtKimlikNo.TrailingIcon = null;
            this.txtKimlikNo.UseSystemPasswordChar = false;
            this.txtKimlikNo.UseTallSize = false;
            this.txtKimlikNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKimlikNo_KeyPress);
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(28, 359);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(64, 36);
            this.materialButton1.TabIndex = 6;
            this.materialButton1.Text = "GERİ";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // doktorGirisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 414);
            this.Controls.Add(this.materialButton1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnGiris);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.txtKimlikNo);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "doktorGirisi";
            this.Padding = new System.Windows.Forms.Padding(2, 52, 2, 2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Doktor Girişi";
            this.Load += new System.EventHandler(this.doktorGirisi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialTextBox2 txtKimlikNo;
        private MaterialSkin.Controls.MaterialTextBox2 txtSifre;
        private MaterialSkin.Controls.MaterialButton btnGiris;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialButton materialButton1;
    }
}