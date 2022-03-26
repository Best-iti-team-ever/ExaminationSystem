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
    public partial class AdminHomeForm : Form
    {
        public AdminHomeForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            var adminCtrlAdmins = new AdminControlAdmin();
            adminCtrlAdmins.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            AdminControlStud ad = new AdminControlStud();
            ad.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            UpdateDepartmentForm up = new UpdateDepartmentForm(3);
            up.ShowDialog();
        }

        private void Instructor_Click(object sender, EventArgs e)
        {
            AdminControlIns ins = new AdminControlIns();
            ins.ShowDialog();

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
