using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UTSMudah1
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Formbook Form = new Formbook();
            Form.ShowDialog();
        }

        private void guna2PictureBox10_Click(object sender, EventArgs e)
        {
            Form formBackground = new Form();
            try
            {
                using (SubForm uu = new SubForm())
                {
                    formBackground.StartPosition = FormStartPosition.CenterParent;
                    formBackground.FormBorderStyle = FormBorderStyle.None;
                    formBackground.Opacity = .10d;
                    formBackground.BackColor = Color.Black; // Set warna yang cocok untuk TransparencyKey
                    formBackground.TransparencyKey = formBackground.BackColor; // Set TransparencyKey sama dengan BackColor
                    formBackground.TopMost = true;
                    formBackground.Location = this.Location;
                    formBackground.ShowInTaskbar = false;
                    formBackground.Show();

                    uu.Owner = formBackground;
                    uu.ShowDialog();

                    formBackground.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                formBackground.Dispose();
            }
        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 Form = new Form8();
            Form.ShowDialog();
        }
    }
}
