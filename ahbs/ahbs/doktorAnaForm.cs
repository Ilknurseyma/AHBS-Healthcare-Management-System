using System.Linq;
using System.Data;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;
using MaterialSkin.Controls;

namespace ahbs
{
    public partial class doktorAnaForm : MaterialForm
    {
        public doktorAnaForm()
        {
            InitializeComponent();
            Form1.changeFormToMaterialForm(this);
        }

        List<int> aileler = new List<int>();
        int secilenAileId = -1;
        bool butonEkle = true;
        private void doktorAnaForm_Load(object sender, EventArgs e)
        {
            hastalariGetir();
            cmbMedeniHali.SelectedIndex = cmbKanGrubu.SelectedIndex = 0;
            dtpDogumTarihi.MaxDate = DateTime.Now;
            Form1.datagridFormatla(gridRandevular);
        }

        void aileleriGetir()        // Yeni aile ekleme sayfasında Yeni butonuna basınca kayıtlı aileleri combobox'a ekler
        {
            Form1.splashScreen.Show();
            Form1.connection.Open();
            SqlCommand comm = new SqlCommand("select id, aileAdi from aileler where aileHekimiId = @p1", Form1.connection);
            comm.Parameters.AddWithValue("@p1", doktorGirisi.Doktor.id);
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                cmbAile.Items.Add(reader["aileAdi"].ToString());
                aileler.Add(Convert.ToInt32(reader["id"]));
            }
            Form1.connection.Close();
            Form1.splashScreen.Hide();
        }

        void aileleriGoster()       // Aileler sayfasındaki bilgiler
        {
            Form1.splashScreen.Show();
            Form1.connection.Open();
            SqlCommand comm = new SqlCommand("select id as 'Sıra No', aileAdi as 'Aile Adı' from aileler where aileHekimiId = @p1", Form1.connection);
            comm.Parameters.AddWithValue("@p1", doktorGirisi.Doktor.id);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridAileler.DataSource = dt;
            Form1.connection.Close();
            Form1.datagridFormatla(gridAileler);
            Form1.splashScreen.Hide();
        }

        void randevulariGetir()     // Randevular sayfasındaki bilgiler
        {
            Form1.splashScreen.Show();
            Form1.connection.Open();
            SqlCommand comm = new SqlCommand(
                string.Format("select ad as 'Adı', soyad as 'Soyadı', convert(char(10), tarih, 104) + ' ' + convert(char(5), tarih, 114) as Tarih from randevular join hastalar on hastaId = hastalar.id join aileler on aileId = aileler.id where aileHekimiId = @p1 and tarih >= convert(datetime, '{0}', 120)", DateTime.Now.ToString("yyyy-MM-dd 09:00:00")), Form1.connection);
            comm.Parameters.AddWithValue("@p1", doktorGirisi.Doktor.id);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridRandevular.DataSource = dt;

            if (butonEkle)
            {
                gridRandevular.Columns.Add(new DataGridViewButtonColumn
                {
                    Text = "Muayene Et",
                    UseColumnTextForButtonValue = true,
                });
                butonEkle = false;
            }
            Form1.datagridFormatla(gridRandevular);
            Form1.connection.Close();
            Form1.splashScreen.Hide();
        }

        void hastalariGetir(string filtre = "")
        {
            Form1.splashScreen.Show();
            Form1.connection.Open();
            SqlCommand comm = new SqlCommand("select ad + ' ' + soyad as 'Hasta Adı', kimlikNo as 'Kimlik No', dogumTarihi as 'Doğum Tarihi', iif(cinsiyet = 1, 'Erkek', 'Kadın') as Cinsiyet, aileAdi as 'Aile Adı' from hastalar join aileler on aileId = aileler.id where aileHekimiId = @p1 " + filtre, Form1.connection);
            comm.Parameters.AddWithValue("@p1", doktorGirisi.Doktor.id);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridHastalar.DataSource = dt;
            Form1.datagridFormatla(gridHastalar);
            Form1.connection.Close();
            Form1.splashScreen.Hide();
        }

        private void btnYeniAile_Click(object sender, EventArgs e)
        {
            new yeniAileEkle().ShowDialog();
            aileleriGetir();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (materialTabControl1.SelectedIndex == 0)
                hastalariGetir();
            else if (materialTabControl1.SelectedIndex == 1)
                randevulariGetir();
            else if (materialTabControl1.SelectedIndex == 2)
                aileleriGetir();
            else if (materialTabControl1.SelectedIndex == 3)
                aileleriGoster();
        }

        private void doktorAnaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            new doktorGirisi().Show();
        }

        private void gridRandevular_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            new frmHastaBilgi(gridRandevular.Rows[e.RowIndex].Cells[0].Value.ToString(), gridRandevular.Rows[e.RowIndex].Cells[1].Value.ToString()).ShowDialog();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            List<string> filtre = new List<string>();
            if (!string.IsNullOrWhiteSpace(txtKimlikNumarasi.Text))
                filtre.Add("kimlikNo like '%" + txtKimlikNumarasi.Text + "%'");
            if (!string.IsNullOrWhiteSpace(txtHastaAdi.Text))
                filtre.Add("ad+soyad like '%" + txtHastaAdi.Text + "%'");
            hastalariGetir((filtre.Count > 0 ? "and " : "") + string.Join(" and ", filtre));
        }

        private void btnSifirla_Click(object sender, EventArgs e)
        {
            txtKimlikNumarasi.Text = txtHastaAdi.Text = "";
            hastalariGetir();
        }

        private void gridAileler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            new frmAileUyeleri(gridAileler.Rows[e.RowIndex].Cells[0].Value.ToString()).ShowDialog();
        }

        private void btnAileSil_Click(object sender, EventArgs e)
        {
            if (secilenAileId != -1 && MessageBox.Show("Bu Aileyi Silmek İstediğinize Emin Misiniz", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Form1.splashScreen.Show();
                Form1.connection.Open();
                SqlCommand comm = new SqlCommand("delete from aileler where id = @p1", Form1.connection);
                comm.Parameters.AddWithValue("@p1", secilenAileId);
                comm.ExecuteNonQuery();
                Form1.splashScreen.Hide();
                MessageBox.Show("Aile Başarıyla Silindi !");
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Hide();
            new Form1().ShowDialog();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAdSoyad.Text))
                MessageBox.Show("Ad Soyad Boş Bırakılamaz !");
            else if (string.IsNullOrWhiteSpace(txtKimlikNo.Text))
                MessageBox.Show("Kimlik Numarası Boş Bırakılamaz !");
            else if (string.IsNullOrWhiteSpace(dtpDogumTarihi.Text))
                MessageBox.Show("Doğum Tarihi Boş Bırakılamaz !");
            else if (cmbAile.SelectedIndex == -1)
                MessageBox.Show("Aile Boş Bırakılamaz !");
            else
            {
                string[] dizi = txtAdSoyad.Text.Trim().Split(' ');
                string ad = "";
                for (int i = 0; i < dizi.Length - 1; i++)
                    ad += dizi[i] + " ";
                Form1.connection.Open();
                SqlCommand comm = new SqlCommand("" +
                    "insert into hastalar(" +
                        "kimlikNo, ad, soyad, dogumTarihi, cinsiyet, anneAdi, babaAdi, medeniHali, adres, telefon, kilo, boy, basCevresi, boyunCevresi, kolCevresi, kanGrubu," +
                        "gogusCevresi, hastaligi, aileId" +
                     ") values(@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13, @p14, @p15, @p16, @p17, @p18, @p19)", Form1.connection);
                comm.Parameters.AddRange(new[] {
                    new SqlParameter("@p1", txtKimlikNo.Text),
                    new SqlParameter("@p2", ad),
                    new SqlParameter("@p3", dizi[dizi.Length-1]),
                    new SqlParameter("@p4", dtpDogumTarihi.Text),
                    new SqlParameter("@p5", cmbCinsiyet.SelectedIndex == 0),
                    new SqlParameter("@p6", txtAnneAdi.Text),
                    new SqlParameter("@p7", txtBabaAdi.Text),
                    new SqlParameter("@p8", cmbMedeniHali.SelectedIndex),
                    new SqlParameter("@p9", txtAdres.Text),
                    new SqlParameter("@p10", txtTelefon.Text),
                    new SqlParameter("@p11", txtKilo.Text),
                    new SqlParameter("@p12", txtBoy.Text),
                    new SqlParameter("@p13", txtBasCevresi.Text),
                    new SqlParameter("@p14", txtBoyunCevresi.Text),
                    new SqlParameter("@p15", txtKolCevresi.Text),
                    new SqlParameter("@p16", cmbKanGrubu.Text),
                    new SqlParameter("@p17", txtGogusCevresi.Text),
                    new SqlParameter("@p18", txtDaimiHastaligi.Text),
                    new SqlParameter("@p19", aileler[cmbAile.SelectedIndex]),
                });
                comm.ExecuteNonQuery();
                Form1.connection.Close();
                foreach (Control control in Controls)
                {
                    if (control is MaterialTextBox2)
                        (control as MaterialTextBox2).Text = "";
                    if (control is MaterialComboBox)
                        (control as MaterialComboBox).SelectedIndex = 0;
                }
                MessageBox.Show("Hasta Başarıyla Kaydedildi !");
            }
        }

        private void doktorAnaForm_Resize(object sender, EventArgs e)
        {
            panel4.Location = new System.Drawing.Point((Width - panel4.Width) / 2, (Height - panel4.Height) / 2);
        }

        private void materialTabSelector1_Click(object sender, EventArgs e)
        {

        }

        private void txtKimlikNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            randevulariGetir();
        }

        private void gridRandevular_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gridRandevular.ColumnCount - 1)
            {
                Form1.splashScreen.Show();
                Form1.connection.Open();
                SqlCommand comm = new SqlCommand("select randevular.id from randevular join hastalar on hastaId = hastalar.id where doktorId = @p1 and ad = @p2 and soyad = @p3", Form1.connection);
                comm.Parameters.AddRange(new[]
                {
                    new SqlParameter("@p1", doktorGirisi.Doktor.id),
                    new SqlParameter("@p2", gridRandevular.Rows[e.RowIndex].Cells[0].Value),
                    new SqlParameter("@p3", gridRandevular.Rows[e.RowIndex].Cells[1].Value)
                });
                SqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                int index = Convert.ToInt32(reader["id"]);
                Form1.connection.Close();
                Form1.splashScreen.Hide();
                new frmMuayene(index).ShowDialog();
            }
        }

        private void gridAileler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            secilenAileId = Convert.ToInt32(gridAileler.Rows[e.RowIndex].Cells[0].Value);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnYeniAileEkle_Click(object sender, EventArgs e)
        {
            new yeniAileEkle().ShowDialog();
            aileleriGoster();
        }
    }
}
