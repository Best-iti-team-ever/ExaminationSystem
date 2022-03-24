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
    public partial class Instructorlogin : Form
    {
        public Instructorlogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)//HOME PAGE
        {
            Form1 HOME = new Form1();
            this.Hide();
            HOME.ShowDialog();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
