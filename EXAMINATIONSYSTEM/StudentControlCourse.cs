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
    public partial class StudentControlCourse : RepeatedFrom
    {
        SqlConnection con;
        int cid;
        public StudentControlCourse()
        {
            InitializeComponent();
            label1.Text = "Student Courses";
            btnEdit.Hide();
            BindDatatoDataGrid("sp_selectcoursesforStudent", UserSingleton.getinstance().user.uid, "@std_id");

            //Course Data in combobox1
            con = new SqlConnection(UserSingleton.getinstance().connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_selectallcourses", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dReader = cmd.ExecuteReader();
            while (dReader.Read())
            {
                
                    //if (int.Parse(dReader[0].ToString()) != int.Parse(dataGridView1.SelectedRows[i].Cells[0].Value.ToString()))
                    //{
                        comboBox1.Items.Add(dReader[0].ToString());

                    //}


            }
            dReader.Close();
            con.Close();
            //Courses that student take that he can drop
           
            SqlCommand cm = new SqlCommand("sp_selectcoursesforStudent", con);
            cm.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cm.Parameters.Add("@std_id", SqlDbType.Int);
            param.Value = UserSingleton.getinstance().user.uid;
            con.Open();
            cm.ExecuteNonQuery();
            SqlDataReader Reader = cm.ExecuteReader();
            while (Reader.Read())
            {
                comboBox2.Items.Add(Reader[0].ToString());
                comboBox3.Items.Add(Reader[0].ToString());
            }
            Reader.Close();
            con.Close();


        }
       

        private void btnAdd_Click_1(object sender, EventArgs e)//add course
        {
            SqlCommand cmd = new SqlCommand("sp_insertstudentcourse", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param;

            param = cmd.Parameters.Add("@stdid", SqlDbType.Int);
            param.Value = UserSingleton.getinstance().user.uid;

            param = cmd.Parameters.Add("@crsid", SqlDbType.Int);
            param.Value = int.Parse(comboBox1.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            BindDatatoDataGrid("sp_selectcoursesforStudent", UserSingleton.getinstance().user.uid, "@std_id");
            MessageBox.Show("New Course has been added to your Data!");
            comboBox1.Text = string.Empty;

            //refresh courses in comboboxes
            SqlCommand cm = new SqlCommand("sp_selectcoursesforStudent", con);
            cm.CommandType = CommandType.StoredProcedure;
            SqlParameter paramm;
            paramm = cm.Parameters.Add("@std_id", SqlDbType.Int);
            paramm.Value = UserSingleton.getinstance().user.uid;
            con.Open();
            cm.ExecuteNonQuery();
            SqlDataReader Reader = cm.ExecuteReader();
            if (comboBox2.Items.Count > 0)
            {
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();
            }
            while (Reader.Read())
            {
               
                comboBox2.Items.Add(Reader[0].ToString());
                comboBox3.Items.Add(Reader[0].ToString());
            }
            Reader.Close();
            con.Close();

        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_deletestudentcourse", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param;

            param = cmd.Parameters.Add("@stdid", SqlDbType.Int);
            param.Value = UserSingleton.getinstance().user.uid;

            param = cmd.Parameters.Add("@crsid", SqlDbType.Int);
            param.Value = int.Parse(comboBox2.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            BindDatatoDataGrid("sp_selectcoursesforStudent", UserSingleton.getinstance().user.uid, "@std_id");
            MessageBox.Show("Course has been deleted from your Data!");
            comboBox2.Text = string.Empty;

            //refresh courses in comboboxes
            SqlCommand cm = new SqlCommand("sp_selectcoursesforStudent", con);
            cm.CommandType = CommandType.StoredProcedure;
            SqlParameter paramm;
            paramm = cm.Parameters.Add("@std_id", SqlDbType.Int);
            paramm.Value = UserSingleton.getinstance().user.uid;
            con.Open();
            cm.ExecuteNonQuery();
            SqlDataReader Reader = cm.ExecuteReader();
            if (comboBox2.Items.Count > 0)
            {
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();
            }
            while (Reader.Read())
            {
                comboBox2.Items.Add(Reader[0].ToString());
                comboBox3.Items.Add(Reader[0].ToString());
            }
            Reader.Close();
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)//take exam
        {
           
            if (comboBox3.Text==string.Empty)
            {
                MessageBox.Show("Choose Course Id to Start Exam!");
            }
            else
            {
                cid = int.Parse(comboBox3.Text);
                Exam ex = new Exam(cid);
                this.Hide();
                ex.ShowDialog();
                this.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)//Show Student Grade in this Course
        {
            SqlCommand cmd = new SqlCommand("Calculate_Grade", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param;

            param = cmd.Parameters.Add(" @Student_ID", SqlDbType.Int);
            param.Value = UserSingleton.getinstance().user.uid;

            param = cmd.Parameters.Add("@crsid", SqlDbType.Int);
            param.Value = int.Parse(comboBox3.Text);

            var str = "select distinct std_take from ExamQuestion where std_id = 17 and crs_id = 1";
            //MessageBox.Show(str);
            SqlCommand selectatke = new SqlCommand();
            selectatke.CommandText = str;
            SqlDataReader dReader = selectatke.ExecuteReader();
            while(dReader.Read())
            {

            }

            param = cmd.Parameters.Add("@take int", SqlDbType.Int);
            param.Value = int.Parse(comboBox3.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
          

        }
    }
   
}
