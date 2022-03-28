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
    public partial class StudentControlData : RepeatedFrom
    {
        SqlConnection con;
        public StudentControlData()
        {
            InitializeComponent();
            label1.Text = "Student Data";
            btnAdd.Hide();
            btnDelete.Hide();
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            BindDatatoDataGrid("sp_selectStudent", UserSingleton.getinstance().user.uid, "@stud_id");
            con = new SqlConnection(UserSingleton.getinstance().connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_selectalldepartments", con);
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
                textBox1.Text = dgv.Cells[1].Value.ToString();
                textBox2.Text = dgv.Cells[2].Value.ToString();
                textBox3.Text = dgv.Cells[3].Value.ToString();
                textBox4.Text = dgv.Cells[4].Value.ToString();
                textBox5.Text = dgv.Cells[5].Value.ToString();
                comboBox1.Text = dgv.Cells[6].Value.ToString();
            }

        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            SqlParameter param;
            SqlCommand cmd;

            if (textBox7.Text == String.Empty)
            {
                cmd = new SqlCommand("sp_updateStudentNoPassword", con);
            }
            else
            {
                cmd = new SqlCommand("sp_updateStudent", con);

                param = cmd.Parameters.Add("@std_passowrd", SqlDbType.VarChar, 64);
                param.Value = textBox7.Text.ToHash();
            }
            cmd.CommandType = CommandType.StoredProcedure;
            param = cmd.Parameters.Add("@std_id", SqlDbType.Int);
            param.Value = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            param = SetParams(cmd);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Student Data is Updated ");
            con.Close();
            BindDatatoDataGrid("sp_selectStudent", UserSingleton.getinstance().user.uid, "@stud_id");
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox7.Text = string.Empty;
            comboBox1.Text = string.Empty;
        }
        private SqlParameter SetParams(SqlCommand cmd)
        {
            SqlParameter param = cmd.Parameters.Add("@std_fname", SqlDbType.VarChar, 50);
            param.Value = textBox1.Text;

            param = cmd.Parameters.Add("@std_lname", SqlDbType.VarChar, 50);
            param.Value = textBox2.Text;

            param = cmd.Parameters.Add("@std_mobile", SqlDbType.VarChar, 15);
            param.Value = textBox3.Text;

            param = cmd.Parameters.Add("@std_address", SqlDbType.NVarChar, 50);
            param.Value = textBox4.Text;

            param = cmd.Parameters.Add("@std_grandYear", SqlDbType.Int);
            param.Value = int.Parse(textBox5.Text);

            param = cmd.Parameters.Add("@dept_id", SqlDbType.Int);
            param.Value = int.Parse(comboBox1.Text);
            return param;
        }
    }
}
