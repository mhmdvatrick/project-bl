using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using UTSMudah1.Model.Entity;
using UTSMudah1.Model.Context;
using UTSMudah1.Model.Repository;
using System.Windows.Forms;
using System.Security.Policy;

namespace UTSMudah1.Controller
{
    public class AdminController
    {
        private AdminRepository _repository;

        public int Create(Admin mhs)
        {
            int result = 0;
            // cek npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(mhs.Username))
            {
                MessageBox.Show("Username harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(mhs.Password))
            {
                MessageBox.Show("Password harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek angkatan yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(mhs.Notelp))
            {
                MessageBox.Show("No.Telpon harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // membuat objek context menggunakan blok using
            using (DbBilliard context = new DbBilliard())
            {
                // membuat objek class repository
                _repository = new AdminRepository(context);
                // panggil method Create class repository untuk menambahkan data
                result = _repository.Create(mhs);
            }
            if (result > 0)
            {
                MessageBox.Show("Data admin berhasil disimpan !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data admin gagal disimpan !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return result;
        }

        public int Update(Admin mhs)
        {
            int result = 0;

            // Check if username is not empty
            if (string.IsNullOrEmpty(mhs.Username))
            {
                MessageBox.Show("Username harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Check if password is not empty
            if (string.IsNullOrEmpty(mhs.Password))
            {
                MessageBox.Show("Password harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Check if phone number is not empty
            if (string.IsNullOrEmpty(mhs.Notelp))
            {
                MessageBox.Show("No.Telpon harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            using (DbBilliard context = new DbBilliard())
            {
                _repository = new AdminRepository(context);
                result = _repository.Update(mhs);
            }

            if (result > 0)
            {
                MessageBox.Show("Data admin berhasil diupdate !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data admin gagal diupdate !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return result;
        }

        public int Delete(Admin mhs)
        {
            int result = 0;

            // Check if username is not empty
            if (string.IsNullOrEmpty(mhs.Username))
            {
                MessageBox.Show("Username harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            using (DbBilliard context = new DbBilliard())
            {
                _repository = new AdminRepository(context);
                result = _repository.Delete(mhs);
            }

            if (result > 0)
            {
                MessageBox.Show("Data admin berhasil dihapus !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data admin gagal dihapus !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return result;
        }
    }




}
