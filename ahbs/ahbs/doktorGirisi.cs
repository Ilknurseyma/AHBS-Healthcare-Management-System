using System.Drawing;
using System;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ahbs
{
    public partial class doktorGirisi : MaterialForm
    {
        internal static structs.Doktor Doktor;
        public doktorGirisi()
        {
            InitializeComponent();
            Form1.changeFormToMaterialForm(this);
        }

        private void doktorGirisi_Load(object sender, EventArgs e)
        {
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKimlikNo.Text))
            {
                MessageBox.Show("Kimlik Numarası Zorunludur!");
            }
            else if (string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Şifre Zorunludur !");
            }
            else
            {
                Form1.connection.Open();
                SqlCommand comm = new SqlCommand("select * from doktorlar where kimlikNo = @p1 and sifre = @p2", Form1.connection);
                comm.Parameters.AddRange(new[] {
                    new SqlParameter("@p1", txtKimlikNo.Text),
                    new SqlParameter("@p2", txtSifre.Text)
                });
                SqlDataReader reader = comm.ExecuteReader();
                if (!reader.Read())
                {
                    Form1.connection.Close();
                    MessageBox.Show("Kimlik Numarası Yada Şifre Hatalı !");
                }
                else
                {
                    Doktor = new structs.Doktor
                    {
                        id = Convert.ToInt32(reader["id"].ToString()),
                        kimlikNo = txtKimlikNo.Text,
                        adSoyad = reader["adSoyad"].ToString(),
                    };
                    Form1.connection.Close();
                    Hide();
                    new doktorAnaForm().ShowDialog();
                }
            }
        }

        private void txtSifre_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtKimlikNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void materialButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().ShowDialog();
        }
    }
}
