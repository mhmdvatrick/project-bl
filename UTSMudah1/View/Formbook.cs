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
    public partial class Formbook : Form
    {
        public Formbook()
        {
            InitializeComponent();
        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Formdashboard Form = new Formdashboard();
            Form.ShowDialog();
        }

        private void guna2PictureBox14_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 Form = new Form6();
            Form.ShowDialog();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 Form = new Form8();
            Form.ShowDialog();
        }
    }
}
