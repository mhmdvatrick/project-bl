using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;

namespace UTSMudah1.View
{
    public partial class FormFP : Form
    {
        public FormFP()
        {
            InitializeComponent();
        }

        private void guna2PictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Formlogin Form = new Formlogin();
            Form.ShowDialog();
        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {
            string nama = username.Text;
            string passwordBaru = pw.Text;

            // Koneksi ke database
            string mySqlConn = "server=127.0.0.1; database=db_billiard; user=root; password=";
            MySqlConnection mySqlConnection = new MySqlConnection(mySqlConn);

            try
            {
                // Validasi input
                if (string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(passwordBaru))
                {
                    MessageBox.Show("Semua kolom harus diisi!");
                    return;
                }

                // Query untuk mengupdate password
                string queryUpdatePassword = "UPDATE user SET Password = @passwordBaru WHERE Nama = @Nama";
                MySqlCommand cmdUpdate = new MySqlCommand(queryUpdatePassword, mySqlConnection);

                // Tambahkan parameter
                cmdUpdate.Parameters.AddWithValue("@passwordBaru", passwordBaru);
                cmdUpdate.Parameters.AddWithValue("@Nama", nama);

                mySqlConnection.Open();
                int rowsAffected = cmdUpdate.ExecuteNonQuery(); // Jalankan query

                mySqlConnection.Close();

                if (rowsAffected > 0)
                {
                    // Jika ada data yang diupdate
                    MessageBox.Show("Password berhasil diperbarui!");
                }
                else
                {
                    // Jika nomor HP tidak ditemukan
                    MessageBox.Show("username tidak ditemukan!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}");
            }
        }
    }
}
