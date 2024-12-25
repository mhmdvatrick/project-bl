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
    public partial class SubForm : Form
    {
        public static SubForm Instance;
        public static TextBox tb2;
        public SubForm()
        {
            InitializeComponent();
            Instance = this;
            tb2 = new TextBox();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            Close();
            this.Hide();
            FormNewdashboard Form = new FormNewdashboard();
            Form.ShowDialog();
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 Form = new Form6();
            Form.ShowDialog();
        }

        private void SubForm_Load(object sender, EventArgs e)
        {

        }
    }
}
