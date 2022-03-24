using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EXAMINATIONSYSTEM
{
    public partial class ChooseExam : Form
    {
        int sid;
        int cid;
        public ChooseExam(int stdid)
        {
            InitializeComponent();
            sid = stdid;
        }



        private void button1_Click(object sender, EventArgs e)//Start Exam
        {
            Exam ex = new Exam(sid,cid);
            this.Hide();
            ex.ShowDialog();
            this.Close();
        }

        private void ChooseExam_Load(object sender, EventArgs e)//on page load
        {
            string querystring = "Select Std_ID,Crs_Name,Crs_ID from dbo.Student as s,dbo.Course as c Where s.Dept_Id= c.Dept_ID and s.Std_ID="+sid;
            SqlCommand cmd = new SqlCommand(querystring, sqlConnection1);

            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader sqlReader = cmd.ExecuteReader();
            while (sqlReader.Read())
            {
                comboBox2.Items.Add(sqlReader.GetValue(1));
                //MessageBox.Show(sqlReader.GetValue(0) + " - " + sqlReader.GetValue(1));
            }
            sqlReader.Close();
            cmd.Dispose();
            sqlConnection1.Close();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)//GET COURSEID TO PASSIT TO GENERATE EXAM PROCEDURE
        {
            //MessageBox.Show("Select Crs_ID from Course where Crs_Name=" + comboBox2.Text);
            string querystring = "Select Crs_ID from Course where Crs_Name='"+comboBox2.Text+"'";
            SqlCommand cmd = new SqlCommand(querystring, sqlConnection1);

            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader sqlReader = cmd.ExecuteReader();
            while (sqlReader.Read())
            {
                cid = sqlReader.GetInt32(0);
            }
            sqlReader.Close();
            cmd.Dispose();
            sqlConnection1.Close();

        }
    }
   }

