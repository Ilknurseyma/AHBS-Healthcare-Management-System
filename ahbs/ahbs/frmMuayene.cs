using System;
using MaterialSkin.Controls;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ahbs
{
    public partial class frmMuayene : MaterialForm
    {
        public frmMuayene(int randevuId)
        {
            InitializeComponent();
            this.randevuId = randevuId;
            Form1.changeFormToMaterialForm(this);
        }

        internal int randevuId;
        private void frmMuayene_Load(object sender, EventArgs e)
        {
            Form1.splashScreen.Show();
            Form1.connection.Open();
            SqlCommand comm = new SqlCommand("select * from muayeneler where id = @p1", Form1.connection);
            comm.Parameters.AddWithValue("@p1", this.randevuId);
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.Read())
            {
                txtHastaSikayeti.Text = reader["hastaSikayeti"].ToString();
            }
            Form1.connection.Close();
            Form1.splashScreen.Hide();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTani.Text))
                MessageBox.Show("Tanı Boş Bırakılamaz !");
            else
            {
                Form1.connection.Open();
                SqlCommand comm = new SqlCommand("insert into muayeneler(tani, rapor, tarih, randevuId, hastaSikayeti) values(@p1, @p2, getdate(), @p3, @p4)", Form1.connection);
                comm.Parameters.AddRange(new[]
                {
                    new SqlParameter("@p1", txtTani.Text),
                    new SqlParameter("@p2",txtRapor.Text),
                    new SqlParameter("@p3",this.randevuId),
                    new SqlParameter("@p4", txtHastaSikayeti.Text),
                });
                comm.ExecuteNonQuery();
                Form1.connection.Close();
                MessageBox.Show("Muayene Bilgileri Başarıyla Kaydedildi !");
            }
        }
    }
}
