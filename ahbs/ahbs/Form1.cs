using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace ahbs
{
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();
            changeFormToMaterialForm(this);
        }

        internal static SqlConnection connection;
        internal static SplashScreen splashScreen = new SplashScreen();
        private void btnHastaGirisi_Click(object sender, EventArgs e)
        {
            Hide();
            new hastaGiris().ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection("Server=DESKTOP-FEB4OB7;Integrated security=SSPI;database=ahbs;Uid=DESKTOP-FEB4OB7\\Zilan");
        }

        private void btnDoktorGirisi_Click(object sender, EventArgs e)
        {
            Hide();
            new doktorGirisi().ShowDialog();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        internal static void datagridFormatla(DataGridView view)
        {
            for (int i = 0; i < view.ColumnCount; i++)
            {
                view.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        internal static void changeFormToMaterialForm(MaterialForm form)
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(form);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green800, Primary.Green900, Primary.BlueGrey500, Accent.DeepPurple700, TextShade.WHITE);
        }

        private void btnDoktorGirisi_MouseMove(object sender, MouseEventArgs e)
        {
            btnDoktorGirisi.BackColor = System.Drawing.Color.Red;
        }
    }
}
