using System;
using MaterialSkin.Controls;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ahbs
{
    public partial class yeniAileEkle : MaterialForm
    {
        public yeniAileEkle()
        {
            InitializeComponent();
            Form1.changeFormToMaterialForm(this);
        }

        private void yeniAileEkle_Load(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAileAdi.Text))
                MessageBox.Show("Aile Adı Boş Bırakılamaz !");
            else
            {
                Form1.connection.Open();
                SqlCommand comm = new SqlCommand("insert into aileler(aileAdi, aileHekimiId) values(@p1, @p2)", Form1.connection);
                comm.Parameters.AddRange(new[]
                {
                    new SqlParameter("@p1", txtAileAdi.Text),
                    new SqlParameter("@p2", doktorGirisi.Doktor.id),
                });
                comm.ExecuteNonQuery();
                Form1.connection.Close();
                MessageBox.Show("Aile Başarıyla Kaydedildi !");
            }
        }
    }
}
