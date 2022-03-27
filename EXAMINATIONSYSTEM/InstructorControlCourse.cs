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
    public partial class InstructorControlCourse : RepeatedFrom
    {
        SqlConnection con;
        public InstructorControlCourse()
        {
            btnAdd.Hide();
            btnDelete.Hide();
            label1.Text = "Courses Data";
            InitializeComponent();
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            BindDatatoDataGrid("sp_selectcoursesforinstructor", UserSingleton.getinstance().user.uid,"@ins_id");
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
            }

        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            SqlParameter param;
            SqlCommand cmd;
            con = new SqlConnection(UserSingleton.getinstance().connectionString);
            cmd = new SqlCommand("sp_updatecourse", con);
          
            cmd.CommandType = CommandType.StoredProcedure;

            param = cmd.Parameters.Add("@id", SqlDbType.Int);
            param.Value = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            param = cmd.Parameters.Add("@name", SqlDbType.VarChar, 50);
            param.Value = textBox1.Text;

            param = cmd.Parameters.Add("@h", SqlDbType.VarChar, 15);
            param.Value = textBox2.Text;

            if(textBox3.Text==string.Empty)
            {
                param = cmd.Parameters.Add("@split", SqlDbType.NVarChar, 10);
                param.Value = null;

            }
            else
            {
                param = cmd.Parameters.Add("@split", SqlDbType.NVarChar, 10);
                param.Value = textBox3.Text;

            }
       
            param = cmd.Parameters.Add("@passgrade", SqlDbType.Int);
            param.Value = textBox4.Text;

            param = cmd.Parameters.Add("@maxtake", SqlDbType.Int);
            param.Value = textBox4.Text;


            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Course Data is Updated ");
            con.Close();
            BindDatatoDataGrid("sp_selectcoursesforinstructor", UserSingleton.getinstance().user.uid, "@ins_id");
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = string.Empty;
        }
    }
}
