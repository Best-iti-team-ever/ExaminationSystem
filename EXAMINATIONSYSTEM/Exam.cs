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
    
    public partial class Exam : Form
    {
        int sid;
        int cid;
        int q=0;
        int row =0;//to iterate on table to get question
        int ans = 0;//to iterate on table to get possible answers
        DataTable dt;
   
        public Exam(int stdid,int CrsID)
        {
            InitializeComponent();
            sid = stdid;
            cid = CrsID;

        }
     

        private void Exam_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            dt = new DataTable();
            string connetionString = "Data Source=tcp:sqlproject.database.windows.net,1433;Initial Catalog = sqlproject;User ID =sqlproject; Password =Project2022;  Persist Security Info = False; MultipleActiveResultSets = False";
            SqlConnection con = new SqlConnection(connetionString);
            cmd = new SqlCommand("Get_Generate_exam", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param;



            param = cmd.Parameters.Add("@std_id", SqlDbType.Int);
            param.Value = sid;
            //MessageBox.Show(sid.ToString() + cid.ToString());


            param = cmd.Parameters.Add("@crs_id", SqlDbType.Int);
            param.Value = cid;
            da.SelectCommand = cmd;
            da.Fill(dt);
            label1.Text = dt.Rows[row][1].ToString();
            //To check if question is mcq or not
            if (dt.Rows[row][3].ToString() == "True" || dt.Rows[row][3].ToString() == "False")
            {
                radioButton3.Hide();
                radioButton4.Hide();
                radioButton1.Text = dt.Rows[ans][3].ToString();
                ans++;
                radioButton2.Text = dt.Rows[ans][3].ToString();
                ans++;
                row = row + 2;
            }
            else
            {
                radioButton3.Show();
                radioButton4.Show();
                radioButton1.Text = dt.Rows[ans][3].ToString();
                ans++;
                radioButton2.Text = dt.Rows[ans][3].ToString();
                ans++;
                radioButton3.Text = dt.Rows[ans][3].ToString();
                ans++;
                radioButton4.Text = dt.Rows[ans][3].ToString();
                ans++;
                row = row + 4;
                ans++;
            }
            ////////////////
            q++;
            groupBox1.Text = "Q" + q;
          
           

        }

        private void button1_Click(object sender, EventArgs e)//Next
        {
           
            label1.Text = String.Empty;
            label1.Text = dt.Rows[row][1].ToString();
           
            //To check if question is mcq or not
            if (dt.Rows[row][3].ToString()=="True" || dt.Rows[row][3].ToString() == "False")
            {
                radioButton3.Hide();
                radioButton4.Hide();
                radioButton1.Text = dt.Rows[ans][3].ToString();
                ans++;
                radioButton2.Text = dt.Rows[ans][3].ToString();
                ans++;
                row = row + 2;
            }
            else
            {
                radioButton3.Show();
                radioButton4.Show();
                radioButton1.Text = dt.Rows[ans][3].ToString();
                ans++;
                radioButton2.Text = dt.Rows[ans][3].ToString();
                ans++;
                radioButton3.Text = dt.Rows[ans][3].ToString();
                ans++;
                radioButton4.Text = dt.Rows[ans][3].ToString();
                ans++;
                row = row + 4;

            }
            /////////////////

            //Detect Question number and visiability of Submit Button
           
            if (q < 10)
            { 
                q++;
                groupBox1.Text = "Q" + q;
                if (q == 10)
                {
                    button3.Show();   
                }
                else
                {
                    button3.Hide();
                }

            }else
            {
                MessageBox.Show("If you Finish Your Exam Click on Submit Button!");
            }

        }

        private void button2_Click(object sender, EventArgs e)//Back
        {
            //label1.Text = String.Empty;
            label1.Text = string.Empty;
            label1.Text = dt.Rows[row-1][1].ToString();
          
            //row--;
            //label1.Text = dt.Rows[row][1].ToString();

            //To check if question is mcq or not
            if (dt.Rows[row-1][3].ToString() == "True" || dt.Rows[row-1][3].ToString() == "False")
            {
                row = row - 2;
                ans = ans - 2;
                label1.Text = string.Empty;
                label1.Text = dt.Rows[row][1].ToString();


                radioButton3.Hide();
                radioButton4.Hide();

                
                radioButton1.Text = dt.Rows[ans][3].ToString();
                ans++;
                radioButton2.Text = dt.Rows[ans][3].ToString();
                ans++;

                
            }
            else
            {
                row = row - 4;
                ans = ans - 4;
               
            

                radioButton3.Show();
                radioButton4.Show();
                
                radioButton1.Text = dt.Rows[ans][3].ToString();
                ans++;
                radioButton2.Text = dt.Rows[ans][3].ToString();
                ans++;
                radioButton3.Text = dt.Rows[ans][3].ToString();
                ans++;
                radioButton4.Text = dt.Rows[ans][3].ToString();
                ans++;

                


            }
            //Detect Question number and visiability of Submit Button
            if (q > 1)
            {
                q--;
                groupBox1.Text = "Q" + q;
                if (q == 10)
                {
                    button3.Show();
                }
                else
                {
                    button3.Hide();
                }

            }
            else
            {
                MessageBox.Show("There is no a -ve 1 Question Number!");
            }

        }

        private void button3_Click(object sender, EventArgs e)//Submit Exam
        {
            //sqlReader.Close();
            //cmd.Dispose();
            //con.Close();

        }
    }
}
