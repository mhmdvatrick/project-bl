using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using UTSMudah1.View;

namespace UTSMudah1
{
    public partial class Formlogin : Form
    {
        public static string CurrentUserNoHP { get; set; }
        public Formlogin()
        {
            InitializeComponent();
           
        }

        public static class CurrentUser
        {
            public static int User_Id { get; set; }
            public static string Nama { get; set; }
            public static string Nohp { get; set; }
        }


        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            string username = this.username.Text;
            string password = this.password.Text;

            string mySqlConn = "server=127.0.0.1; database=db_billiard; user=root; password=";
            MySqlConnection mySqlConnection = new MySqlConnection(mySqlConn);

            try
            {
                string query = "SELECT `User_id`, `Nama`, `No hp` FROM user WHERE Nama = @Nama AND Password = @password";
                MySqlCommand cmd = new MySqlCommand(query, mySqlConnection);
                cmd.Parameters.AddWithValue("@nama", username);
                cmd.Parameters.AddWithValue("@password", password);

                mySqlConnection.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Simpan data user ke CurrentUser
                    CurrentUser.User_Id = reader.GetInt32("User_id");
                    CurrentUser.Nama = reader.GetString("Nama");
                    CurrentUser.Nohp = reader.GetString("No hp");

                    MessageBox.Show("Login berhasil!");
                    this.Hide();

                    // Navigasi ke Form berikutnya
                    Formdashboard Formdashboard = new Formdashboard();
                    Formdashboard.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Username atau password salah!");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}");
            }
            finally
            {
                mySqlConnection.Close();
            }
        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Formregister Form = new Formregister();
            Form.ShowDialog();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormFP Form = new FormFP();
            Form.ShowDialog();
        }
    }
}
