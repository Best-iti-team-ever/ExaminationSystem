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
    public partial class ViewCoursesForDepartmentForm : RepeatedFrom
    {
        SqlConnection con;
        public int deptID { get; set; }
        public ViewCoursesForDepartmentForm(int dept_id)
        {
            InitializeComponent();
            deptID = dept_id;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            
            BindDatatoDataGrid("sp_selectcoursesindepartment",deptID, "@dept_id");

            con = new SqlConnection(UserSingleton.getinstance().connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_selectallcourses", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dReader = cmd.ExecuteReader();
            while (dReader.Read())
            {
                comboBox1.Items.Add(dReader[0].ToString());
            }
            dReader.Close();
            con.Close();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgv = dataGridView1.Rows[e.RowIndex];
                //textBox1.Text = dgv.Cells[1].Value.ToString();
                //textBox2.Text = dgv.Cells[2].Value.ToString();
                //textBox3.Text = dgv.Cells[3].Value.ToString();
                //textBox4.Text = dgv.Cells[4].Value.ToString();
                //textBox5.Text = dgv.Cells[5].Value.ToString();
              
            }
        }

        protected override void btnAdd_Click(object sender, EventArgs e)
        {
            //check if course in department 

            //sp_insertCourseToDepartment @dept_id int , @coures_id int
            SqlCommand cmd = new SqlCommand("sp_insertCourseToDepartment", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param =  cmd.Parameters.Add("@dept_id", SqlDbType.Int);
            param.Value = deptID;

            param = cmd.Parameters.Add("@coures_id", SqlDbType.Int);
            param.Value = int.Parse(comboBox1.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("course added to department ");
            con.Close();
            BindDatatoDataGrid("sp_selectcoursesindepartment", deptID, "@dept_id");
        }

            private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {

        }
    }
}
