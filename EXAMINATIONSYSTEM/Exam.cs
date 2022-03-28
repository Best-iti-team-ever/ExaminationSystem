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
        
        int cid;
        int q = 0;
        int row = 0;//to iterate on table to get question
        int ans = 0;//to iterate on table to get possible answers
        DataTable dt;
        SqlConnection con;

        public Exam(int CrsID)
        {
            InitializeComponent();
            cid = CrsID;

        }

        public void ShowQuestion()
        {
            groupBox1.Text = $"Q{q + 1}";
            label1.Text = String.Empty;

            label1.Text = dt.Rows[row][1].ToString();
            //To check if question is mcq or not
            if (! bool.Parse(dt.Rows[row][4].ToString()))
            {
                radioButton3.Hide();
                radioButton4.Hide();
                radioButton1.Name = dt.Rows[ans][2].ToString();
                radioButton1.Text = dt.Rows[ans][3].ToString();
                ans++;
                row++;
                radioButton2.Name = dt.Rows[ans][2].ToString();
                radioButton2.Text = dt.Rows[ans][3].ToString();
                ans++;
                row++;
            }
            else
            {
                radioButton3.Show();
                radioButton4.Show();
                radioButton1.Name = dt.Rows[ans][2].ToString();
                radioButton1.Text = dt.Rows[ans][3].ToString();
                ans++;
                row++;
                radioButton2.Name = dt.Rows[ans][2].ToString();
                radioButton2.Text = dt.Rows[ans][3].ToString();
                ans++;
                row++;
                radioButton3.Name = dt.Rows[ans][2].ToString();
                radioButton3.Text = dt.Rows[ans][3].ToString();
                ans++;
                row++;
                
                radioButton4.Name = dt.Rows[ans][2].ToString();
                radioButton4.Text = dt.Rows[ans][3].ToString();
                ans++;
                row++;
  
               
            }
            q++;
            foreach (RadioButton r in groupBox1.Controls.OfType<RadioButton>())
            {
                //MessageBox.Show(dt.Rows[i][6].ToString());
                r.Checked = false;
            }
            checkradiobutton(row-1);
        }


        private void Exam_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            dt = new DataTable();
            SqlConnection con = new SqlConnection(UserSingleton.getinstance().connectionString);
            cmd = new SqlCommand("Get_Generate_exam", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param;

            param = cmd.Parameters.Add("@std_id", SqlDbType.Int);
            param.Value = UserSingleton.getinstance().user.uid;
            //MessageBox.Show(sid.ToString() + cid.ToString());

            param = cmd.Parameters.Add("@crs_id", SqlDbType.Int);
            param.Value = cid;

            da.SelectCommand = cmd;
            da.Fill(dt);
            dt.Columns.Add(new DataColumn());
            dt.Columns.Add(new DataColumn());
            ShowQuestion();
        }


        private void button1_Click(object sender, EventArgs e)//Next
        {
            //get sudent answer
            RadioButton checkedbutton = SetDTgetChecked();
            if (checkedbutton!=null)
            {
                con = new SqlConnection(UserSingleton.getinstance().connectionString);
                SqlCommand cmd = new SqlCommand("submit_Answer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param;


                param = cmd.Parameters.Add("@std_id", SqlDbType.Int);
                param.Value = UserSingleton.getinstance().user.uid;

                param = cmd.Parameters.Add("@crs_id", SqlDbType.Int);
                param.Value = cid;

                param = cmd.Parameters.Add("@qust_id", SqlDbType.VarChar);
                param.Value = int.Parse(dt.Rows[row - 1][0].ToString());
                param = cmd.Parameters.Add("@answer_id", SqlDbType.Int);
                param.Value = int.Parse(checkedbutton.Name.ToString());
                dt.Rows[row - 1][6] = int.Parse(checkedbutton.Name.ToString());
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            if (q < 10)
            {
                button3.Hide();
                ShowQuestion();
            }
            else if (q == 10)
            {
                button3.Show();
                MessageBox.Show("If you Finish Your Exam Click on Submit Button!");
            }
          
        }
        private void button2_Click(object sender, EventArgs e)//Back
        {
            SetDTgetChecked();
            if (q > 1)
            {
                q -= 2;
                int k = 0;
                while (k < 2)
                {
                    row--;
                    ans--;
                    if (dt.Rows[row][3].ToString() == "True" || dt.Rows[row][3].ToString() == "False")
                    {
                        row -= 1;
                        ans -= 1;
                    }
                    else
                    {
                        row -= 3;
                        ans -= 3;
                    }
                    k++;
                }
                ShowQuestion();
            }
            else
            {
                MessageBox.Show("This is the First Question");
            }
        }
        private void checkradiobutton(int i)//assign the place of radio button
        {
            if (isassigned(i))
            {
                foreach (RadioButton r in groupBox1.Controls.OfType<RadioButton>())
                {
                    //MessageBox.Show(dt.Rows[i][6].ToString());
                    if (r.Name.toInt() ==dt.Rows[i][6].toInt())
                    {
                        r.Checked = true;
                    }

                }

            }
        }

        private RadioButton SetDTgetChecked()
        {
            RadioButton checkedbutton = null;

            foreach (RadioButton r in groupBox1.Controls.OfType<RadioButton>())
            {
                if (r.Checked == true)
                {
                    checkedbutton = r;
                }
            }
            if (checkedbutton != null)
                dt.Rows[row - 1][6] = int.Parse(checkedbutton.Name.ToString());
            return checkedbutton;
        }

        private bool isassigned(int i)
        {
            return dt.Rows[i][6] != null;
        }
      

        private void button3_Click(object sender, EventArgs e)//Submit Exam & show grade
        {
            SqlParameter param;
            SqlCommand cmd;
            con = new SqlConnection(UserSingleton.getinstance().connectionString);
            cmd = new SqlCommand("Calculate_Last_Grade", con);

            cmd.CommandType = CommandType.StoredProcedure;

            param = cmd.Parameters.Add("@std_id", SqlDbType.Int);
            param.Value = UserSingleton.getinstance().user.uid;

            param = cmd.Parameters.Add("@crs_id", SqlDbType.Int);
            param.Value = cid;

           
            SqlDataReader dreader;
            con.Open();
            SqlDataReader dReader = cmd.ExecuteReader();
            while (dReader.Read())
            {
                if(int.Parse(dReader[0].ToString())>59)
                    MessageBox.Show("Congratulations you passed! Your Grade is "+dReader[0].ToString());
                else
                    MessageBox.Show("You Failed! Your Grade is " + dReader[0].ToString());
            }
            con.Close();
            StudentControlCourse concrs = new StudentControlCourse();
            concrs.ShowDialog();
            this.Hide();
           

        }
    }
}
