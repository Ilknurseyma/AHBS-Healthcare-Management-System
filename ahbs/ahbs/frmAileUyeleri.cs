using System;
using System.Data;
using System.Data.SqlClient;
using MaterialSkin.Controls;
using System.Windows.Forms;

namespace ahbs
{
    public partial class frmAileUyeleri : MaterialForm
    {
        string aileAdi;
        public frmAileUyeleri(string aileAdi)
        {
            this.aileAdi = aileAdi;
            InitializeComponent();
            Form1.changeFormToMaterialForm(this);
        }

        private void frmAileUyeleri_Load(object sender, EventArgs e)
        {
            this.Text = this.aileAdi + " Üyeleri";
            Form1.connection.Open();
            SqlCommand comm = new SqlCommand("select kimlikNo as 'Kimlik No', ad + ' ' + soyad as 'Ad Soyad', dogumTarihi as 'Doğum Tarihi' from hastalar join aileler on aileId = aileler.id where aileAdi = @p1", Form1.connection);
            comm.Parameters.AddWithValue("@p1", this.aileAdi);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridAileUyeleri.DataSource = dt;
            Form1.datagridFormatla(gridAileUyeleri);
        }
    }
}
