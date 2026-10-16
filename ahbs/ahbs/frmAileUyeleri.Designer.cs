namespace ahbs
{
    partial class frmAileUyeleri
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
            this.gridAileUyeleri = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridAileUyeleri)).BeginInit();
            this.SuspendLayout();
            // 
            // gridAileUyeleri
            // 
            this.gridAileUyeleri.AllowUserToAddRows = false;
            this.gridAileUyeleri.AllowUserToDeleteRows = false;
            this.gridAileUyeleri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAileUyeleri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAileUyeleri.Location = new System.Drawing.Point(3, 64);
            this.gridAileUyeleri.Name = "gridAileUyeleri";
            this.gridAileUyeleri.ReadOnly = true;
            this.gridAileUyeleri.RowHeadersWidth = 51;
            this.gridAileUyeleri.RowTemplate.Height = 24;
            this.gridAileUyeleri.Size = new System.Drawing.Size(796, 404);
            this.gridAileUyeleri.TabIndex = 0;
            // 
            // frmAileUyeleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 471);
            this.Controls.Add(this.gridAileUyeleri);
            this.Name = "frmAileUyeleri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aile Üyeleri";
            this.Load += new System.EventHandler(this.frmAileUyeleri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridAileUyeleri)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridAileUyeleri;
    }
}