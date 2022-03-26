using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXAMINATIONSYSTEM
{
    public partial class Home : Form
    {
        public int user { get; set; }
        public Home()
        {
            InitializeComponent();
            //textBox1.Text = "123".ToHash();
        }

        private void label1_Click(object sender, EventArgs e)//student
        {
            user = 1;
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void Instructor_Click(object sender, EventArgs e)
        {
            user = 2;
            this.DialogResult = DialogResult.OK;
            this.Hide();  
        }

        private void label2_Click(object sender, EventArgs e)//Admin
        {
            user = 3;
            this.DialogResult = DialogResult.OK;
            this.Hide();

        }
    }
}
