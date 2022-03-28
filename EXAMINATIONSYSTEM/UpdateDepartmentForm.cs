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
    public partial class UpdateDepartmentForm : Form
    {
        SqlConnection con;
        public int  deptID { get; set; }
        public UpdateDepartmentForm(int dept_id)
        {
            InitializeComponent();
            deptID = dept_id;
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
            cmd = new SqlCommand("sp_selectDepartment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = cmd.Parameters.Add("@dept_id", SqlDbType.Int);
            param.Value = dept_id;
            con.Open();
            cmd.ExecuteNonQuery();
             dReader = cmd.ExecuteReader();
            if (dReader.Read())
            {
                textBox1.Text = dReader[1].ToString();
                comboBox1.Text = dReader[2].ToString();

            }
            dReader.Close();
            con.Close();

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Controller cont = new Controller();
            cont.run();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //[sp_updateDepartment](@dept_id int,@dept_name varchar(50),@manager_id int)
            con = new SqlConnection(UserSingleton.getinstance().connectionString);
            SqlCommand cmd = new SqlCommand("sp_updateDepartment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = cmd.Parameters.Add("@dept_id", SqlDbType.Int);
            param.Value = deptID;

            param = cmd.Parameters.Add("@dept_name", SqlDbType.VarChar, 50);
            param.Value = textBox1.Text;

            param = cmd.Parameters.Add("@manager_id", SqlDbType.Int);
            param.Value = comboBox1.Text;
            con.Open();
            cmd.ExecuteNonQuery();
            textBox1.Text = comboBox1.Text = string.Empty;
            MessageBox.Show("Department is Updated");
            con.Close();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ViewCoursesForDepartmentForm from = new ViewCoursesForDepartmentForm(deptID);
            from.ShowDialog();
            this.Hide();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewInstructioresForDepartmentForm form1 = new ViewInstructioresForDepartmentForm(deptID);
            form1.ShowDialog();
        }
    }
}
