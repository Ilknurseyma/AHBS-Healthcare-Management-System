
namespace ahbs
{
    partial class Form1
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
            this.btnHastaGirisi = new MaterialSkin.Controls.MaterialButton();
            this.btnDoktorGirisi = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // btnHastaGirisi
            // 
            this.btnHastaGirisi.AutoSize = false;
            this.btnHastaGirisi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnHastaGirisi.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnHastaGirisi.Depth = 0;
            this.btnHastaGirisi.HighEmphasis = true;
            this.btnHastaGirisi.Icon = null;
            this.btnHastaGirisi.Location = new System.Drawing.Point(73, 97);
            this.btnHastaGirisi.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnHastaGirisi.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnHastaGirisi.Name = "btnHastaGirisi";
            this.btnHastaGirisi.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnHastaGirisi.Size = new System.Drawing.Size(265, 66);
            this.btnHastaGirisi.TabIndex = 0;
            this.btnHastaGirisi.Text = "hasta girişi";
            this.btnHastaGirisi.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnHastaGirisi.UseAccentColor = false;
            this.btnHastaGirisi.UseVisualStyleBackColor = true;
            this.btnHastaGirisi.Click += new System.EventHandler(this.btnHastaGirisi_Click);
            // 
            // btnDoktorGirisi
            // 
            this.btnDoktorGirisi.AutoSize = false;
            this.btnDoktorGirisi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDoktorGirisi.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnDoktorGirisi.Depth = 0;
            this.btnDoktorGirisi.HighEmphasis = true;
            this.btnDoktorGirisi.Icon = null;
            this.btnDoktorGirisi.Image = global::ahbs.Properties.Resources.pngtree_search_icon_image_13444471;
            this.btnDoktorGirisi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDoktorGirisi.Location = new System.Drawing.Point(73, 175);
            this.btnDoktorGirisi.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDoktorGirisi.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDoktorGirisi.Name = "btnDoktorGirisi";
            this.btnDoktorGirisi.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnDoktorGirisi.Size = new System.Drawing.Size(265, 59);
            this.btnDoktorGirisi.TabIndex = 1;
            this.btnDoktorGirisi.Text = "aile hekimi girişi";
            this.btnDoktorGirisi.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnDoktorGirisi.UseAccentColor = false;
            this.btnDoktorGirisi.UseVisualStyleBackColor = true;
            this.btnDoktorGirisi.Click += new System.EventHandler(this.btnDoktorGirisi_Click);
            this.btnDoktorGirisi.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnDoktorGirisi_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 270);
            this.Controls.Add(this.btnDoktorGirisi);
            this.Controls.Add(this.btnHastaGirisi);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton btnHastaGirisi;
        private MaterialSkin.Controls.MaterialButton btnDoktorGirisi;
    }
}

