
namespace ahbs
{
    partial class yeniAileEkle
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
            this.txtAileAdi = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.btnKaydet = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // txtAileAdi
            // 
            this.txtAileAdi.AnimateReadOnly = false;
            this.txtAileAdi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtAileAdi.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAileAdi.Depth = 0;
            this.txtAileAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtAileAdi.HideSelection = true;
            this.txtAileAdi.LeadingIcon = null;
            this.txtAileAdi.LeaveOnEnterKey = true;
            this.txtAileAdi.Location = new System.Drawing.Point(232, 108);
            this.txtAileAdi.MaxLength = 32767;
            this.txtAileAdi.MouseState = MaterialSkin.MouseState.OUT;
            this.txtAileAdi.Name = "txtAileAdi";
            this.txtAileAdi.PasswordChar = '\0';
            this.txtAileAdi.PrefixSuffixText = null;
            this.txtAileAdi.ReadOnly = false;
            this.txtAileAdi.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAileAdi.SelectedText = "";
            this.txtAileAdi.SelectionLength = 0;
            this.txtAileAdi.SelectionStart = 0;
            this.txtAileAdi.ShortcutsEnabled = true;
            this.txtAileAdi.Size = new System.Drawing.Size(291, 36);
            this.txtAileAdi.TabIndex = 12;
            this.txtAileAdi.TabStop = false;
            this.txtAileAdi.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtAileAdi.TrailingIcon = null;
            this.txtAileAdi.UseSystemPasswordChar = false;
            this.txtAileAdi.UseTallSize = false;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(51, 125);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(68, 24);
            this.materialLabel3.TabIndex = 11;
            this.materialLabel3.Text = "Aile Adı";
            // 
            // btnKaydet
            // 
            this.btnKaydet.AutoSize = false;
            this.btnKaydet.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnKaydet.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnKaydet.Depth = 0;
            this.btnKaydet.HighEmphasis = true;
            this.btnKaydet.Icon = null;
            this.btnKaydet.Location = new System.Drawing.Point(355, 188);
            this.btnKaydet.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnKaydet.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnKaydet.Size = new System.Drawing.Size(168, 45);
            this.btnKaydet.TabIndex = 38;
            this.btnKaydet.Text = "kaydet";
            this.btnKaydet.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnKaydet.UseAccentColor = false;
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // yeniAileEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 283);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtAileAdi);
            this.Controls.Add(this.materialLabel3);
            this.MaximizeBox = false;
            this.Name = "yeniAileEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yeni Aile";
            this.Load += new System.EventHandler(this.yeniAileEkle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox2 txtAileAdi;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialButton btnKaydet;
    }
}