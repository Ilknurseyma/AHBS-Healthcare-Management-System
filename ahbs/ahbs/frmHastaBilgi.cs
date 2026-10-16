using System;
using System.Data;
using MaterialSkin.Controls;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ahbs
{
    public partial class frmHastaBilgi : MaterialForm
    {
        internal string hastaAdi;
        internal string hastaSoyadi;

        int hastaId;
        public frmHastaBilgi(string hastaAdi, string hastaSoyadi)
        {
            InitializeComponent();
            this.hastaAdi = hastaAdi;
            this.hastaSoyadi = hastaSoyadi;
            Form1.changeFormToMaterialForm(this);
        }

        private void frmHastaBilgi_Load(object sender, EventArgs e)
        {
            hastaBilgileriniGetir();
            tahlilleriGetir();
        }

        void hastaBilgileriniGetir()
        {
            Form1.splashScreen.Show();
            Form1.connection.Open();
            SqlCommand comm = new SqlCommand("select id from hastalar where ad = @p1 and soyad = @p2", Form1.connection);
            comm.Parameters.AddRange(new[]
            {
                new SqlParameter("@p1", this.hastaAdi),
                new SqlParameter("@p2", this.hastaSoyadi),
            });
            SqlDataReader reader = comm.ExecuteReader();
            
            if(reader.Read());
            this.hastaId = Convert.ToInt32(reader["id"]);
            Form1.connection.Close();
            Form1.splashScreen.Hide();
        }

        void tahlilleriGetir()
        {
            Form1.connection.Open();
            SqlCommand comm = new SqlCommand("select tahlilAdi as 'Tahlil Adı', sonuc as 'Sonuç', tarih as 'Tarih' from tahliller where hastaId = @p1", Form1.connection);
            comm.Parameters.Add(new SqlParameter("@p1", this.hastaId));
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comm);
            da.Fill(dt);
            gridTahliller.DataSource = dt;
            Form1.connection.Close();
            Form1.datagridFormatla(gridTahliller);
        }
        void asilariGetir()
        {
            Form1.splashScreen.Show();
            Form1.connection.Open();
            SqlCommand comm = new SqlCommand("select asiAdi as 'Aşı Adı', tarih as 'Tarih' from asilar where hastaId = @p1", Form1.connection);
            comm.Parameters.Add(new SqlParameter("@p1", this.hastaId));
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comm);
            da.Fill(dt);
            gridAsilar.DataSource = dt;
            Form1.connection.Close();
            Form1.datagridFormatla(gridAsilar);
            Form1.splashScreen.Hide();
        }

        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (materialTabControl1.SelectedIndex == 0)
                tahlilleriGetir();
            else
                asilariGetir();
        }
    }
}
