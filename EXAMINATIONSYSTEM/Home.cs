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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {
            StudentLogin stdlg = new StudentLogin();
            this.Hide();
            stdlg.ShowDialog();
            this.Close();
        }

        private void Instructor_Click(object sender, EventArgs e)
        {
            Instructorlogin Inslg = new Instructorlogin();
            this.Hide();
            Inslg.ShowDialog();
            this.Close();
        }
    }
}
