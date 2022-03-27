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
    public partial class ViewInstructorsPerCourseForm : RepeatedFrom
    {
        SqlConnection con;

        public int CourseID { get; set; }
        public ViewInstructorsPerCourseForm(int course_id)
        {
            InitializeComponent();

            CourseID = course_id;
            BindDatatoDataGrid("sp_select_Ins_per_Crs", course_id, "@crs_id");

            con = new SqlConnection(UserSingleton.getinstance().connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_selectAllInstructors", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dReader = cmd.ExecuteReader();
            while (dReader.Read())
            {
                comboBox1.Items.Add(dReader[0].ToString());
            }
            dReader.Close();
            con.Close();
            btnEdit.Hide();
            btnDelete.Text = "Remove";
            btnDelete.Width = btnDelete.Width + 10;
        }

        protected override void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_add_Ins_per_Crs", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = cmd.Parameters.Add("@crs_id", SqlDbType.Int);
            param.Value = CourseID;

            param = cmd.Parameters.Add("@ins_id", SqlDbType.Int);
            param.Value = int.Parse(comboBox1.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("instructor  added to course ");
            con.Close();
            BindDatatoDataGrid("sp_select_Ins_per_Crs", CourseID, "@crs_id");
        }

        protected override void btnDelete_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("sp_delete_Ins_Crs_from_Teach", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            param = cmd.Parameters.Add("@crs_id", SqlDbType.Int);
            param.Value = CourseID;

            param = cmd.Parameters.Add("@ins_id", SqlDbType.Int);
            param.Value = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("instructor  is deleted from course! ");
            con.Close();
            BindDatatoDataGrid("sp_select_Ins_per_Crs", CourseID, "@crs_id");

        }
    }
}
