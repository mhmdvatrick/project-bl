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
    public partial class SubForm3 : Form
    {
        public SubForm3()
        {
            InitializeComponent();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Formlogin Form = new Formlogin();
            Form.ShowDialog();
        }

        private void guna2PictureBox3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form8 Form = new Form8();
            Form.ShowDialog();
        }
    }
}
