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
    public partial class AdminControlIns : RepeatedFrom
    {
        SqlConnection con;
        public AdminControlIns()
        {
            InitializeComponent();
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            BindDatatoDataGrid("sp_selectallInstructors");
            con = new SqlConnection(UserSingleton.getinstance().connectionString);

            con.Open();
            con.Close();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                DataGridViewRow dgv = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = dgv.Cells[1].Value.ToString();
                textBox3.Text = dgv.Cells[2].Value.ToString();
                textBox2.Text = dgv.Cells[3].Value.ToString();
                textBox4.Text = dgv.Cells[4].Value.ToString();
          

          
            }

        }

        protected override void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_insertinstructor", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = SetParams(cmd);

            param = cmd.Parameters.Add("@ins_password", SqlDbType.VarChar, 64);
            param.Value = textBox5.Text.ToHash();

            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader dReader = cmd.ExecuteReader();
            if (dReader.Read())
            {
                MessageBox.Show("Welcome " + textBox1.Text + " " + textBox2.Text + " Your login Id is : " + dReader[0].ToString() + "\nYour Data is added to our System");
            }

            dReader.Close();
            con.Close();

            BindDatatoDataGrid("sp_selectallinstructors");

            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text= string.Empty;
           
        }

        private SqlParameter SetParams(SqlCommand cmd)
        {
          
            SqlParameter param = cmd.Parameters.Add("@ins_name", SqlDbType.VarChar, 15);
            param.Value = textBox1.Text;

            param = cmd.Parameters.Add("@ins_phone", SqlDbType.NChar, 15);
            param.Value = textBox2.Text;

            param = cmd.Parameters.Add("@ins_email", SqlDbType.NVarChar,50);
            param.Value = textBox3.Text;

            param = cmd.Parameters.Add("@ins_degree", SqlDbType.VarChar,64);
            param.Value = textBox4.Text;

            return param;
        }

        protected override void btnDelete_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("sp_deleteinstructor", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@id", SqlDbType.Int);

            param.Value = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            con.Open();
            cmd.ExecuteNonQuery();

            MessageBox.Show("Instructor Data  is deleted from your data! ");
            con.Close();
            BindDatatoDataGrid("sp_selectallinstructors");

            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text  = string.Empty;
         
        }

        protected override void btnEdit_Click(object sender, EventArgs e)
        {
            SqlParameter param;
            SqlCommand cmd;

            if (textBox5.Text == String.Empty)
            {
                cmd = new SqlCommand("sp_updateInstructorNoPassword", con);
            }
            else
            {
                cmd = new SqlCommand("sp_updateInstructor", con);

                param = cmd.Parameters.Add("@ins_passowrd", SqlDbType.VarChar, 64);
                param.Value = textBox5.Text.ToHash();
            }
            cmd.CommandType = CommandType.StoredProcedure;
            param = cmd.Parameters.Add("@ins_id", SqlDbType.Int);

            param.Value = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            param = SetParams(cmd);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Instructor Data is Updated ");
            con.Close();
            BindDatatoDataGrid("sp_selectallinstructors");
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = string.Empty;
        
        }
    }
}
