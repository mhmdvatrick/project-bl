using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;

namespace UTSMudah1
{
    public partial class Formregister : Form
    {
        public static Formregister Instance;
        public static TextBox tb1;

        public Formregister()
        {
            InitializeComponent();
            Instance = this;
            tb1 = new TextBox();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {
            string nama = Nama.Text;
            string nohp = telpon.Text;
            string password = pass.Text;


          // Koneksi ke database
            string mySqlConn = "server=127.0.0.1; database=db_billiard; user=root; password=";
            MySqlConnection mySqlConnection = new MySqlConnection(mySqlConn);

            try
            {
                // Query untuk insert data
                string queryInsert = "INSERT INTO user (`Nama`, `No hp`, `Password`) VALUES (@nama, @nohp, @password)";
                MySqlCommand cmdInsert = new MySqlCommand(queryInsert, mySqlConnection);

                // Tambahkan parameter
                cmdInsert.Parameters.AddWithValue("@nama", nama);
                cmdInsert.Parameters.AddWithValue("@nohp", nohp);
                cmdInsert.Parameters.AddWithValue("@password", password);

                mySqlConnection.Open();
                cmdInsert.ExecuteNonQuery();
                mySqlConnection.Close();

                // Beri notifikasi sukses
                MessageBox.Show("Pendaftaran berhasil!");
            }
            catch (Exception ex)
            {
                // Tangani error
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}");
            }

            this.Hide();
            Formlogin Form = new Formlogin();
            Form.ShowDialog();
        }

        private void guna2PictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Formlogin Form = new Formlogin();
            Form.ShowDialog();
        }
    }
}
