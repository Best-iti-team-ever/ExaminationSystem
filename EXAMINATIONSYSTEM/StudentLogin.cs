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
    public partial class StudentLogin : Form
    {
        public StudentLogin()
        {
            InitializeComponent();
            sqlConnection2.Open();
            sqlDataAdapter1.Fill(dataSet1);
            sqlConnection2.Close();

        }

        private void label1_Click(object sender, EventArgs e)//HOME PAGE
        {
            Home HOME = new Home();
            this.Hide();
            HOME.ShowDialog();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)//EXIT APPLICATION
        {
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)//LOGIN BUTTON
        {
            //int stdid;
            //dataSet1.Tables[0].PrimaryKey = new DataColumn[] { dataSet1.Tables[0].Columns["Std_ID"] };
            //int iD = int.Parse(textBox1.Text);
            //var pass = textBox2.Text;
            //DataRow dr = dataSet1.Tables[0].Rows.Find(iD);
            //if(dr != null && dr["Std_Password"].ToString() == pass)
            //{
            //    stdid = int.Parse(textBox1.Text);
            //    ChooseExam CH = new ChooseExam(stdid);
            //    this.Hide();
            //    CH.ShowDialog();
            //    this.Close();

            //}
            //else
            //{
            //    MessageBox.Show("Sorry!You Entered a wrong ID or Password");
            //    textBox1.Text = textBox2.Text = string.Empty;
            //}
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
