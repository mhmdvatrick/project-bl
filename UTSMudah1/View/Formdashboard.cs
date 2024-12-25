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
    public partial class Formdashboard : Form
    {
        public Formdashboard()
        {
            InitializeComponent();
        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox8_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAT Form = new FormAT();
            Form.ShowDialog();
        }

        private void guna2PictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Formbook Form = new Formbook();
            Form.ShowDialog();
        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
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
