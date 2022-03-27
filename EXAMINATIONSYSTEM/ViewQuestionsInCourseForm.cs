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
                            break;
                        case 1:
                            ans3TB.Text = dReader[1].ToString();
                            break;
                        case 2:
                            ans4TB.Text = dReader[1].ToString();
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

        }
        protected override void btnDelete_Click(object sender, EventArgs e)
        {
            //[dbo].[delete_Question] @quest_ID int 
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

        }
    }


}

