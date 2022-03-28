using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXAMINATIONSYSTEM
{
    public partial class ViewQuestionsInCourseForm : RepeatedFrom
    {
        SqlConnection con;
       
        public int courseID { get; set; }
        private int answer2, answer3, answer4;
        public ViewQuestionsInCourseForm(int course_id)
        {
            InitializeComponent();
            courseID = course_id;
            con = new SqlConnection(UserSingleton.getinstance().connectionString);
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);

            BindDatatoDataGrid("sp_select_all_Questions_per_course", courseID, "@crs_id");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bool isMCQ = bool.Parse(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
            SqlCommand cmd = new SqlCommand("sp_Select_Answers_Per_Qusetion", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            //ALTER proc [dbo].[sp_Select_Answers_Per_Qusetion] @quest_id int
            quesTB.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            gradeTB.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            param = cmd.Parameters.Add("@quest_ID", SqlDbType.Int);
            param.Value = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader dReader = cmd.ExecuteReader();
            int iter = 0;
            while (dReader.Read())
            {
                if (int.Parse(dReader[0].ToString()) == int.Parse(dReader[2].ToString()))
                {
                    ans1TB.Text = dReader[1].ToString();
                }
                else
                {
                    switch (iter)
                    {
                        case 0:
                            ans2TB.Text = dReader[1].ToString();
                            answer2 = dReader[0].toInt();
                            break;
                        case 1:
                            ans3TB.Text = dReader[1].ToString();
                            answer3 = dReader[0].toInt();
                            break;
                        case 2:
                            ans4TB.Text = dReader[1].ToString();
                            answer4 = dReader[0].toInt();
                            break;
                    }
                    iter++;
                }

            }
            dReader.Close();
            con.Close();
            if (!isMCQ)
            {
                ans3.Hide();
                ans4.Hide();
                ans3TB.Hide();
                ans4TB.Hide();
                ans3TB.Text = ans4TB.Text = string.Empty;
            }
            else
            {
                ans3.Show();
                ans4.Show();
                ans3TB.Show();
                ans4TB.Show();
            }


        }

        protected override void btnAdd_Click(object sender, EventArgs e)
        {
            //ALTER proc [dbo].[] @question varchar(max),@Question_Grade int,@crs_id int ,@correct_Ans varchar(300),@answer_2 varchar(300),@answer_3 varchar(300),@answer_4 varchar(300)

            SqlCommand cmd;
            SqlParameter param;
            if (ans3TB.Text != string.Empty)
            {
                cmd = new SqlCommand("insert_MCQ_Question_Answer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                param = cmd.Parameters.Add("@answer_3", SqlDbType.VarChar, 300);
                param.Value = ans3TB.Text;

                param = cmd.Parameters.Add("@answer_4", SqlDbType.VarChar, 300);
                param.Value = ans4TB.Text;

            }
            else
            {
                cmd = new SqlCommand("Update_TF_Question_Answer", con);
                cmd.CommandType = CommandType.StoredProcedure;

            }


            param = cmd.Parameters.Add("@question", SqlDbType.VarChar, 8000);
            param.Value = quesTB.Text;

            param = cmd.Parameters.Add("@Question_Grade", SqlDbType.Int);
            param.Value = int.Parse(gradeTB.Text);

            param = cmd.Parameters.Add("@crs_id", SqlDbType.Int);
            param.Value = courseID;

            param = cmd.Parameters.Add("@correct_Ans", SqlDbType.VarChar, 300);
            param.Value = ans1TB.Text;


            param = cmd.Parameters.Add("@answer_2", SqlDbType.VarChar, 300);
            param.Value = ans2TB.Text;



            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("question  is Added! ");
            con.Close();
            BindDatatoDataGrid("sp_select_all_Questions_per_course", courseID, "@crs_id");
        }
        protected override void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete_Question", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            param = cmd.Parameters.Add("@quest_ID", SqlDbType.Int);
            param.Value = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("question  is deleted! ");
            con.Close();
            BindDatatoDataGrid("sp_select_all_Questions_per_course", courseID, "@crs_id");

        }
        protected override void btnEdit_Click(object sender, EventArgs e)
        {
            SqlCommand cmd;
            SqlParameter param;
            if (ans3TB.Text != string.Empty)
            {
                cmd = new SqlCommand("Update_MCQ_Question_Answer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                param = cmd.Parameters.Add("@ans3_id", SqlDbType.Int);
                param.Value = answer3;

                param = cmd.Parameters.Add("@answer_3", SqlDbType.VarChar, 300);
                param.Value = ans3TB.Text;

                param = cmd.Parameters.Add("@ans4_id", SqlDbType.Int);
                param.Value = answer4;

                param = cmd.Parameters.Add("@answer_4", SqlDbType.VarChar, 300);
                param.Value = ans4TB.Text;

            }
            else
            {
                cmd = new SqlCommand("Update_TF_Question_Answer", con);
                cmd.CommandType = CommandType.StoredProcedure;

            }


            param = cmd.Parameters.Add("@question_id", SqlDbType.Int);
            param.Value = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

            param = cmd.Parameters.Add("@question", SqlDbType.VarChar,8000);
            param.Value = quesTB.Text;

            param = cmd.Parameters.Add("@Question_Grade", SqlDbType.Int);
            param.Value = int.Parse(gradeTB.Text);

            param = cmd.Parameters.Add("@crs_id", SqlDbType.Int);
            param.Value = courseID;

            param = cmd.Parameters.Add("@correct_Ans", SqlDbType.VarChar,300);
            param.Value = ans1TB.Text;

            param = cmd.Parameters.Add("@ans2_id", SqlDbType.Int);
            param.Value = answer2;

            param = cmd.Parameters.Add("@answer_2", SqlDbType.VarChar, 300);
            param.Value = ans2TB.Text;



            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("question  is Updated! ");
            con.Close();
            BindDatatoDataGrid("sp_select_all_Questions_per_course", courseID, "@crs_id");
        }
    }


}

