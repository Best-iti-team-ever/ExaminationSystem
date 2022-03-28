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
    public partial class StudentHomeForm : Form
    {
        
        public StudentHomeForm()
        {
            InitializeComponent();
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.ShowDialog();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            StudentControlCourse studcourse = new StudentControlCourse();
            studcourse.ShowDialog();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            StudentControlData stdata = new StudentControlData();
            stdata.ShowDialog();
            this.Hide();
        }
    }
}
