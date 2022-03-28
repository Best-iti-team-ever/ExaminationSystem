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
    public partial class Loginform : Form
    {
        public String type { get; set; }
        public Loginform(string tuser)
        {
            InitializeComponent();
            type = tuser;
            label5.Text = type + " Login";
            if(tuser=="Admin" || tuser == "Instructor")
            {
                button2.Hide();
            }

        }
        private void label1_Click(object sender, EventArgs e)//HOME PAGE
        {
            this.DialogResult = DialogResult.Cancel;
            //UserSingleton user=UserSingleton.getinstance();
            this.Hide();
            //user.home.ShowDialog();

        }

        private void label4_Click(object sender, EventArgs e)//EXIT APPLICATION
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)//LOGIN BUTTON
        {
            this.DialogResult = DialogResult.OK;
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)//studentsignup
        {
            Std_Signup stdsignup = new Std_Signup();
            this.Hide();
            stdsignup.ShowDialog();
            this.Close();

        }

       
    }
}
