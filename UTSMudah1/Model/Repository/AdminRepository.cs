using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using UTSMudah1.Model.Entity;
using UTSMudah1.Model.Context;
using System.Windows.Forms;
using System.Security.Policy;

namespace UTSMudah1.Model.Repository
{
    public class AdminRepository
    {
        private SQLiteConnection _conn;

        public AdminRepository(DbBilliard context)
        {
            _conn = context.Conn;
        }

        public int Create(Admin mhs)
        {
            int result = 0;
            // deklarasi perintah SQL
            string sql = @"insert into admin (username, password, notelpon) values (@username, @password, @notelpon)";
            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@username", mhs.Username);
                cmd.Parameters.AddWithValue("@password", mhs.Password);
                cmd.Parameters.AddWithValue("@notelpon", mhs.Notelp);
                try
                {
                    // jalankan perintah INSERT dan tampung hasilnya ke dalam variabel result
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                }
            }
            return result;
        }

        public int Delete(Admin mhs)
        {
            string sql = @"DELETE FROM admin WHERE username = @username";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@username", mhs.Username);
                return cmd.ExecuteNonQuery();
            }
        }

        public int Update(Admin mhs)
        {
            string sql = @"UPDATE admin 
                   SET password = @password, notelpon = @notelpon 
                   WHERE username = @username";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@username", mhs.Username);
                cmd.Parameters.AddWithValue("@password", mhs.Password);
                cmd.Parameters.AddWithValue("@notelpon", mhs.Notelp);
                return cmd.ExecuteNonQuery();
            }
        }

        public List<Admin> ReadAll()
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Admin> list = new List<Admin>();
            try
            {
                // deklarasi perintah SQL
                string sql = @"select username, password, notelpon from admin order by username";
                // membuat objek command menggunakan blok using
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT)
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        // panggil method Read untuk mendapatkan baris dari result set
                        while (dtr.Read())
                        {
                            // proses konversi dari row result set ke object

                            Admin mhs = new Admin();
                            mhs.Username = dtr["username"].ToString();
                            mhs.Password = dtr["password"].ToString();
                            mhs.Notelp = dtr["notelpon"].ToString();
                            // tambahkan objek mahasiswa ke dalam collection

                            list.Add(mhs);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadAll error: {0}", ex.Message);
            }
            return list;
        }

        public List<Admin> ReadByUsername(string username)
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Admin> list = new List<Admin>();
            try
            {
                // deklarasi perintah SQL
                string sql = @"select username, password, notelpon from admin where username like @usernameorder by username";

                // membuat objek command menggunakan blok using
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    // mendaftarkan parameter dan mengeset nilainya
                    cmd.Parameters.AddWithValue("@username", string.Format("%{0}%", username));
                    // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT)
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        // panggil method Read untuk mendapatkan baris dari result set
                        while (dtr.Read())
                        {
                            // proses konversi dari row result set ke object

                            Admin mhs = new Admin();
                            mhs.Username = dtr["username"].ToString();
                            mhs.Password = dtr["password"].ToString();
                            mhs.Notelp = dtr["notelpon"].ToString();
                            // tambahkan objek mahasiswa ke dalam collection

                            list.Add(mhs);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadByNama error: {0}", ex.Message);
            }
            return list;
        }
    }
}

