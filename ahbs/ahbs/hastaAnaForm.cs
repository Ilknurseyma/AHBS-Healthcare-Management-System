using System;
using System.Data;
using MaterialSkin.Controls;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ahbs
{
    public partial class hastaAnaForm : MaterialForm
    {
        public hastaAnaForm()
        {
            InitializeComponent();
            Form1.changeFormToMaterialForm(this);
        }

        bool iptalEkle = true;
        int secilenRandevuId = -1;
        private void hastaAnaForm_Load(object sender, EventArgs e)
        {
            hastaBilgileriniYerlestir();
        }

        void randevuSaatleriniAyarla()
        {
            List<TimeSpan> doluRandevular = new List<TimeSpan>();

            if (cmbTarih.Items.Count == 0)  // Bugünden itibaren 15 gün sonrasına kadar her günü tarih alanına ekler.
            {
                // Günleri Doldurma
                DateTime baslangicGun = DateTime.Now;
                DateTime bitisGun = DateTime.Now.AddDays(15);
                while (baslangicGun <= bitisGun)
                {
                    cmbTarih.Items.Add(baslangicGun.ToString("dd.MM.yyyy dddd"));
                    baslangicGun = baslangicGun.AddDays(1);
                }

                cmbTarih.SelectedIndex = 0;
            }

            // Dolu Saatleri Getirme
            cmbSaat.Enabled = false;
            Form1.connection.Open();
            SqlCommand comm = new SqlCommand(
                string.Format(  // string içerisine değişken eklenmek istendiğinde {0}, {1} gibi sırasıyla yazılır ve eklenecek değişkenler parametre olarak verilir
                    "select tarih from randevular where tarih >= convert(datetime, '{0}', 120) and tarih <= convert(datetime, '{1}', 120)", // convert fonksiyonu sql'de tarih formatlamak için kullanılıyor. 120: yyyy-MM-dd HH:mm:ss demek
                    Convert.ToDateTime(cmbTarih.SelectedItem).ToString("yyyy-MM-dd 09:00:00"),  // Seçilen tarihin mesai başlangıcı
                    Convert.ToDateTime(cmbTarih.SelectedItem).ToString("yyyy-MM-dd 17:00:00")   // Seçilen tarihin mesai bitişi
                    ), Form1.connection);
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                string[] dizi = reader["tarih"].ToString().Split(' ');
                string[] dizi2 = dizi[1].Split(':');
                doluRandevular.Add(new TimeSpan(Convert.ToInt32(dizi2[0]), Convert.ToInt32(dizi2[1]), 0));
            }
            Form1.connection.Close();
            cmbSaat.Enabled = true;

            // Saatleri Doldurma
            TimeSpan baslangicSaat = new TimeSpan(9, 0, 0);
            TimeSpan bitisSaat = new TimeSpan(17, 0, 0);
            TimeSpan aralik = new TimeSpan(0, 15, 0);

            cmbSaat.Items.Clear();

            while (baslangicSaat <= bitisSaat)
            {
                if (!doluRandevular.Contains(baslangicSaat))
                    cmbSaat.Items.Add(baslangicSaat.ToString("hh\\:mm"));
                baslangicSaat = baslangicSaat.Add(aralik);
            }
            cmbSaat.SelectedIndex = 0;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)   // Tab değiştirildiğinde seçilen tab'a göre ilgili bilgileri getirir. Bi nevi sayfa yenileme yapar.
        {
            if (materialTabControl1.SelectedIndex == 1)
                randevuSaatleriniAyarla();
            else if (materialTabControl1.SelectedIndex == 2)
                randevulariGetir();
            else if (materialTabControl1.SelectedIndex == 3)
                receteleriGetir();
            else if (materialTabControl1.SelectedIndex == 4)
                muayeneleriGetir();
            else if (materialTabControl1.SelectedIndex == 5)
                tahlilleriGetir();
            else if (materialTabControl1.SelectedIndex == 6)
                aileUyeleriniGetir();
        }

        private void randevulariGetir()     // Randevular sayfasındaki bilgiler
        {
            Form1.connection.Open();
            SqlCommand comm = new SqlCommand("select randevular.id as 'Randevu Numarası', adSoyad as 'Doktor Adı', tarih as Tarih from randevular join doktorlar on doktorlar.id = doktorId where hastaId = @p1", Form1.connection);
            comm.Parameters.AddWithValue("@p1", hastaGiris.Hasta.id);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridRandevular.DataSource = dt;

            if (iptalEkle)
            {
                gridRandevular.Columns.Add(new DataGridViewButtonColumn
                {
                    Text = "İptal Et",
                    UseColumnTextForButtonValue = true,
                });
                iptalEkle = false;
            }

            Form1.datagridFormatla(gridRandevular);
            Form1.connection.Close();
        }

        void hastaBilgileriniYerlestir()        // Hasta girişi yapılınca hastanın bilgileri Hasta adlı struct'a dolduruluyordu. Burda da struct'tan formdaki ilgili yerlere yazılıyor.
        {
            labelAdSoyad.Text = hastaGiris.Hasta.ad + " " + hastaGiris.Hasta.soyad;
            labelKimlikNumarasi.Text = hastaGiris.Hasta.kimlikNo;
            labelDogumTarihi.Text = hastaGiris.Hasta.dogumTarihi ?? "-";
            labelCinsiyet.Text = hastaGiris.Hasta.cinsiyet ?? "-";
            labelAnneAdi.Text = hastaGiris.Hasta.anneAdi ?? "-";
            labelBabaAdi.Text = hastaGiris.Hasta.babaAdi ?? "-";
            labelMedeniHali.Text = hastaGiris.Hasta.medeniHali;
            labelTelefon.Text = hastaGiris.Hasta.telefonNumarasi;
            labelAdres.Text = hastaGiris.Hasta.adres;
            labelKilo.Text = hastaGiris.Hasta.kilo;
            labelBoy.Text = hastaGiris.Hasta.boy;
            labelKanGrubu.Text = hastaGiris.Hasta.kanGrubu;
        }

        void receteleriGetir()      // Reçeteler sayfasındaki bilgiler
        {
            Form1.connection.Open();
            SqlCommand comm = new SqlCommand("select receteNumarasi as 'Reçete Numarası', adSoyad as 'Doktor Adı', ilacAdi as 'İlaç Adı', tarih as Tarih from receteIlaclari join receteler on receteler.id = receteId join doktorlar on doktorlar.id = doktorId where hastaId = @p1", Form1.connection);
            comm.Parameters.AddWithValue("@p1", hastaGiris.Hasta.id);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridRecete.DataSource = dt;
            Form1.datagridFormatla(gridRecete);
            Form1.connection.Close();
        }

        void muayeneleriGetir() // Muayeneler sayfasındaki bilgiler
        {
            Form1.connection.Open();
            SqlCommand comm = new SqlCommand("select tani as 'Tanı', muayeneler.tarih as Tarih, adSoyad as 'Doktor Adı' from muayeneler join randevular on randevuId = randevular.id join doktorlar on doktorlar.id = doktorId where hastaId = @p1", Form1.connection);
            comm.Parameters.AddWithValue("@p1", hastaGiris.Hasta.id);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridMuayeneler.DataSource = dt;
            Form1.datagridFormatla(gridMuayeneler);
            Form1.connection.Close();
        }

        void tahlilleriGetir()  // Tahliller sayfasındaki bilgiler
        {
            Form1.connection.Open();
            SqlCommand comm = new SqlCommand("select adSoyad as 'Doktor Adı', tahlilAdi as 'Tahlil Adı', sonuc as Sonuç, tarih as Tarih from tahliller join doktorlar on doktorlar.id = doktorId where hastaId = @p1", Form1.connection);
            comm.Parameters.AddWithValue("@p1", hastaGiris.Hasta.id);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridTahliller.DataSource = dt;
            Form1.datagridFormatla(gridTahliller);
            Form1.connection.Close();
        }

        void aileUyeleriniGetir()   // Ailem sayfasındaki bilgiler
        {
            Form1.connection.Open();
            SqlCommand comm = new SqlCommand("select ad as Adı, soyad as Soyadı, dogumTarihi as 'Doğum Tarihi', telefon as Telefon from hastalar where aileId = @p1", Form1.connection);
            comm.Parameters.AddWithValue("@p1", hastaGiris.Hasta.aileId);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridAile.DataSource = dt;
            Form1.datagridFormatla(gridAile);
            Form1.connection.Close();
        }

        private void hastaAnaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            new Form1().ShowDialog();
        }

        private void cmbTarih_SelectedIndexChanged(object sender, EventArgs e)
        {
            randevuSaatleriniAyarla();      // Randevu alma ekranında tarih değiştirilirse o tarihteki boş randevu saatlerini saat alanına ekler
        }

        private void btnRandevuAl_Click(object sender, EventArgs e)     // Randevu bilgilerini kaydetme
        {
            Form1.connection.Open();
            SqlCommand comm = new SqlCommand("insert into randevular(hastaId, doktorId, tarih) values(@p1, @p2, convert(datetime, @p3, 120))", Form1.connection);
            comm.Parameters.AddRange(new[]
            {
                new SqlParameter("@p1", hastaGiris.Hasta.id),
                new SqlParameter("@p2", hastaGiris.Hasta.doktorId),
                new SqlParameter("@p3", Convert.ToDateTime(cmbTarih.SelectedItem + " " + cmbSaat.SelectedItem).ToString("yyyy-MM-dd HH:mm:ss")),
            });
            comm.ExecuteNonQuery();
            MessageBox.Show("Randevu Başarıyla Oluşturuldu !");
            Form1.connection.Close();
        }

        private void hastaAnaForm_Resize(object sender, EventArgs e)        // formun boyutu değiştirilirse randevu alma ekranındaki controllerin formun ortasında görünmesini sağlar.
        {
            panel1.Location = new System.Drawing.Point((Width - panel1.Width) / 2, (Height - panel1.Height) / 2);
        }

        private void gridRandevular_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            secilenRandevuId = Convert.ToInt32(gridRandevular.Rows[e.RowIndex].Cells[0].Value);
            if (e.ColumnIndex == gridRandevular.ColumnCount - 1 && secilenRandevuId != -1)
            {
                if (MessageBox.Show("Bu Randevuyu İptal Etmek İstediğinize Emin Misiniz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Form1.splashScreen.Show();
                    Form1.connection.Open();
                    SqlCommand comm = new SqlCommand("delete from randevular where id = @p1", Form1.connection);
                    comm.Parameters.AddWithValue("@p1", secilenRandevuId);
                    comm.ExecuteNonQuery();
                    Form1.connection.Close();
                    Form1.splashScreen.Hide();
                    MessageBox.Show("Randevu Başarıyla İptal Edildi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    randevulariGetir();
                }
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Hide();
            new Form1().ShowDialog();
        }
    }
}
