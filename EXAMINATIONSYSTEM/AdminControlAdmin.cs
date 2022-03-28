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
    public partial class AdminControlAdmin : RepeatedFrom
    {
        SqlConnection con;

        public AdminControlAdmin()
        {
            InitializeComponent();
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            BindDatatoDataGrid("sp_selectAllAdmins");
            con = new SqlConnection(UserSingleton.getinstance().connectionString);

            
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                DataGridViewRow dgv = dataGridView1.Rows[e.RowIndex];

                txbName.Text = dgv.Cells[1].Value.ToString().Trim();
                txbPhone.Text = dgv.Cells[2].Value.ToString().Trim();

            }

        }
        private SqlParameter SetParams(SqlCommand cmd)
        {

            SqlParameter param = cmd.Parameters.Add("@admin_name", SqlDbType.VarChar, 10);
            param.Value = txbName.Text.Trim();

            param = cmd.Parameters.Add("@admin_phone", SqlDbType.VarChar, 64);
            param.Value = txbPhone.Text.Trim();

         

            return param;
        }
        protected override void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_insertAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = SetParams(cmd);

            param = cmd.Parameters.Add("@password", SqlDbType.VarChar, 64);
            param.Value = txbPass.Text.Trim().ToHash();

            con.Open();
            //cmd.ExecuteNonQuery();
            SqlDataReader dReader = cmd.ExecuteReader();
            if (dReader.Read())
            {
                MessageBox.Show("Welcome " + txbName.Text +  " Your login Id is : " + dReader[0].ToString() + "\nYour Data is added to our System");
            }

            dReader.Close();
            con.Close();

            BindDatatoDataGrid("sp_selectAllAdmins");

            txbName.Text = txbPass.Text = txbPhone.Text = string.Empty;
        }

        protected override void btnDelete_Click(object sender, EventArgs e)

        {
            SqlCommand cmd = new SqlCommand("sp_DeleteAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@id", SqlDbType.Int);
            param.Value = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            con.Open();
            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Admin Data is deleted from your data! ");
            }
            con.Close();
            BindDatatoDataGrid("sp_selectAllAdmins");
            txbName.Text = txbPass.Text = txbPhone.Text = string.Empty;
        }
        protected override void btnEdit_Click(object sender, EventArgs e)
        {
            SqlParameter param;
            SqlCommand cmd;
            if ( txbPhone.Text!="" && txbName.Text!="")
            {

                if (txbPass.Text == String.Empty)
                {
                    cmd = new SqlCommand("sp_updateAdminNoPassword", con);
                }
                else
                {
                    cmd = new SqlCommand("sp_updateAdmin", con);

                    param = cmd.Parameters.Add("@admin_password", SqlDbType.VarChar, 64);
                    param.Value = txbPass.Text.ToHash();
                }
                cmd.CommandType = CommandType.StoredProcedure;
                param = cmd.Parameters.Add("@admin_id", SqlDbType.Int);
                param.Value = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                param = SetParams(cmd);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Admin Data is Updated ");
                con.Close();
                BindDatatoDataGrid("sp_selectAllAdmins");
                txbPass.Text = txbName.Text = txbPhone.Text =  string.Empty;
            }
        }
    }
}
