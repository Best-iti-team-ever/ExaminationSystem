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
    public partial class AdminControlCourse : RepeatedFrom
    {
        SqlConnection con;
        public AdminControlCourse()
        {
            InitializeComponent();
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            BindDatatoDataGrid("sp_selectallcourses");
            con = new SqlConnection(UserSingleton.getinstance().connectionString);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                DataGridViewRow dgv = dataGridView1.Rows[e.RowIndex];

                txbName.Text = dgv.Cells[1].Value.ToString().Trim();
                txbHours.Text = dgv.Cells[2].Value.ToString().Trim();
                txbSplit.Text = dgv.Cells[3].Value.ToString().Trim();
                txbGrade.Text = dgv.Cells[4].Value.ToString().Trim();
                txbMaxTake.Text = dgv.Cells[5].Value.ToString().Trim();
            }

        }

        private SqlParameter SetParams(SqlCommand cmd)
        {

            SqlParameter param = cmd.Parameters.Add("@name", SqlDbType.VarChar, 50);
            param.Value = txbName.Text.Trim();

            param = cmd.Parameters.Add("@h", SqlDbType.Int);
            param.Value = txbHours.Text.Trim();


            param = cmd.Parameters.Add("@passgrade", SqlDbType.Int);
            param.Value = txbGrade.Text.Trim();

            param = cmd.Parameters.Add("@maxtake", SqlDbType.Int);
            param.Value = txbMaxTake.Text.Trim();


            return param;
        }
        protected override void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_insertcourse", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = SetParams(cmd);



            con.Open();
            //cmd.ExecuteNonQuery();
            SqlDataReader dReader = cmd.ExecuteReader();
            if (dReader.Read())
            {
                MessageBox.Show("Course " + txbName.Text + " is added w/  Id = : " + dReader[0].ToString() + "\nYour Data is added to our System");
            }

            dReader.Close();
            con.Close();

            BindDatatoDataGrid("sp_selectallcourses");

            txbName.Text = txbMaxTake.Text = txbSplit.Text = txbHours.Text = txbGrade.Text = string.Empty;
        }

        protected override void btnDelete_Click(object sender, EventArgs e)

        {
            SqlCommand cmd = new SqlCommand("sp_deletecourse", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@id", SqlDbType.Int);
            param.Value = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            con.Open();
            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Course Data is deleted from your data! ");
            }
            con.Close();
            BindDatatoDataGrid("sp_selectallcourses");
            txbName.Text = txbMaxTake.Text = txbSplit.Text = txbHours.Text = txbGrade.Text = string.Empty;

        }
        protected override void btnEdit_Click(object sender, EventArgs e)
        {
            SqlParameter param;
            SqlCommand cmd;
            if (txbName.Text != "" && txbHours.Text != "" && txbGrade.Text != "")
            {
                cmd = new SqlCommand("sp_updatecourse", con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (txbSplit.Text != "")
                {
                    param = cmd.Parameters.Add("@split", SqlDbType.Int);
                    param.Value = txbSplit.Text.Trim();
                }
               
                param = cmd.Parameters.Add("@id", SqlDbType.Int);
                param.Value = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                param = SetParams(cmd);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Course Data is Updated ");
                con.Close();
                BindDatatoDataGrid("sp_selectallcourses");
                txbName.Text = txbMaxTake.Text = txbSplit.Text = txbHours.Text = txbGrade.Text = string.Empty;

            }
        }


    }
}
