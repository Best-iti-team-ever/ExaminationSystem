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
    public partial class ViewInstructioresForDepartmentForm : RepeatedFrom
    {
        SqlConnection con;
        public int deptID { get; set; }
        public ViewInstructioresForDepartmentForm(int dept_id)
        {
            InitializeComponent();
            deptID = dept_id;
            //sp_selectInstructorsInDepartmrnt @dept_id int

            BindDatatoDataGrid("sp_selectInstructorsInDepartmrnt", deptID, "@dept_id");

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
            //ALTER proc [dbo].[sp_insertworkon] @depid int , @insid int
            SqlCommand cmd = new SqlCommand("sp_insertworkon", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = cmd.Parameters.Add("@depid", SqlDbType.Int);
            param.Value = deptID;

            param = cmd.Parameters.Add("@insid", SqlDbType.Int);
            param.Value = int.Parse(comboBox1.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("instructor  added to department ");
            con.Close();
            BindDatatoDataGrid("sp_selectInstructorsInDepartmrnt", deptID, "@dept_id");
        }
        protected override void btnDelete_Click(object sender, EventArgs e)
        {
            //ALTER proc [dbo].[sp_deleteworkon] @inisid int , @dept_id int
            SqlCommand cmd = new SqlCommand("sp_deleteworkon", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@dept_id", SqlDbType.Int);
            param.Value = deptID;
            param = cmd.Parameters.Add("@instid", SqlDbType.Int);
            param.Value = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("instructor is deleted from Department! ");
            con.Close();
            BindDatatoDataGrid("sp_selectInstructorsInDepartmrnt", deptID, "@dept_id");
        }
        protected override void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // int instructor_ID = 
            viewCoursesPerInstructorForm viewCourses = new viewCoursesPerInstructorForm(3);
            viewCourses.ShowDialog();
        }
    }
}
