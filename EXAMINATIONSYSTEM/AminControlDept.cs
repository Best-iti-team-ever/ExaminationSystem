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
    public partial class AdminControlDept : RepeatedFrom
    {
        SqlConnection con;
        public AdminControlDept()
        {
            InitializeComponent();
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            BindDatatoDataGrid("sp_selectalldepartments");
            con = new SqlConnection(UserSingleton.getinstance().connectionString);
            FillComboBox();

        }

        private void FillComboBox()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_selectAllInstructors", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dReader = cmd.ExecuteReader();
            while (dReader.Read())
            {
                cbxMangerID.Items.Add(dReader[0].ToString());
            }
            dReader.Close();
            con.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                DataGridViewRow dgv = dataGridView1.Rows[e.RowIndex];

                txbName.Text = dgv.Cells[1].Value.ToString().Trim();
                cbxMangerID.Text = dgv.Cells[2].Value.ToString().Trim();

            }

        }
        private SqlParameter SetParams(SqlCommand cmd)
        {

            SqlParameter param = cmd.Parameters.Add("@dept_name", SqlDbType.VarChar, 50);
            param.Value = txbName.Text.Trim();

            param = cmd.Parameters.Add("@manager_id", SqlDbType.Int);
            param.Value = cbxMangerID.Text.Trim();



            return param;
        }

        protected override void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_insertDepartment", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = SetParams(cmd);


            con.Open();
            //cmd.ExecuteNonQuery();
            SqlDataReader dReader = cmd.ExecuteReader();
            if (dReader.Read())
            {
                MessageBox.Show("Department " + txbName.Text + " was added w/ Id = : " + dReader[0].ToString() + "\nYour Data is added to our System");
            }

            dReader.Close();
            con.Close();

            BindDatatoDataGrid("sp_selectalldepartments");

            txbName.Text = cbxMangerID.Text = string.Empty;
        }

        protected override void btnDelete_Click(object sender, EventArgs e)

        {
            SqlCommand cmd = new SqlCommand("sp_deletedepartment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@dept_id", SqlDbType.Int);
            param.Value = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            con.Open();
            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Department Data is deleted from your data! ");
            }
            con.Close();
            BindDatatoDataGrid("sp_selectalldepartments");
            txbName.Text = cbxMangerID.Text = string.Empty;
        }

        protected override void btnEdit_Click(object sender, EventArgs e)
        {
            UpdateDepartmentForm up = new UpdateDepartmentForm(3);
            up.ShowDialog();
        }
    }

}

