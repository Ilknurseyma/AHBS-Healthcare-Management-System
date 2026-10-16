using System;
using MaterialSkin.Controls;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ahbs
{
    public partial class hastaGiris : MaterialForm
    {
        public hastaGiris()
        {
            InitializeComponent();
            Form1.changeFormToMaterialForm(this);
        }

        internal static structs.Hasta Hasta;

        private void hastaGiris_Load(object sender, EventArgs e)
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
                SqlCommand comm = new SqlCommand("select * from hastalar join aileler on aileId = aileler.id where kimlikNo = @p1 and sifre = @p2", Form1.connection);
                comm.Parameters.AddRange(new[] {
                    new SqlParameter("@p1", txtKimlikNo.Text),
                    new SqlParameter("@p2", txtSifre.Text )
                });
                SqlDataReader reader = comm.ExecuteReader();
                if (!reader.Read())
                {
                    Form1.connection.Close();
                    MessageBox.Show("Kimlik Numarası Yada Şifre Hatalı !");
                }
                else
                {
                    int medeniHal = Convert.ToInt32(reader["medeniHali"]);
                    Hasta = new structs.Hasta
                    {
                        id = Convert.ToInt32(reader["id"].ToString()),
                        kimlikNo = txtKimlikNo.Text,
                        ad = reader["ad"].ToString(),
                        soyad = reader["soyad"].ToString(),
                        dogumTarihi = reader["dogumTarihi"].ToString().Split(' ')[0],
                        cinsiyet = Convert.ToBoolean(reader["cinsiyet"]) == false ? "Kadın" : "Erkek",
                        anneAdi = reader["anneAdi"].ToString(),
                        babaAdi = reader["babaAdi"].ToString(),
                        medeniHali = medeniHal == 0 ? "Bekar" : medeniHal == 1 ? "Evli" : "Dul",
                        adres = reader["adres"].ToString(),
                        telefonNumarasi = reader["telefon"].ToString(),
                        kilo = reader["kilo"].ToString(),
                        boy = reader["boy"].ToString(),
                        basCevresi = reader["basCevresi"].ToString(),
                        boyunCevresi = reader["boyunCevresi"].ToString(),
                        kanGrubu = reader["kanGrubu"].ToString(),
                        gogusCevresi = reader["gogusCevresi"].ToString(),
                        hastaligi = reader["hastaligi"].ToString(),
                        aileId = reader["aileId"].ToString(),
                        doktorId = reader["aileHekimiId"].ToString(),
                    };
                    Form1.connection.Close();
                    Hide();
                    new hastaAnaForm().ShowDialog();
                }
            }
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
