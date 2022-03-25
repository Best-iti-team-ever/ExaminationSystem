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
    public partial class RepeatedFrom : Form
    {

        protected void BindDatatoDataGrid(String SqlCommandString, int? SelectByParam = null, string SelectParamName = null)
        {

            SqlConnection con;
            con = new SqlConnection(UserSingleton.getinstance().connectionString);
            SqlCommand cmd = new SqlCommand(SqlCommandString, con);
            cmd.CommandType = CommandType.StoredProcedure;
            if (SelectByParam.HasValue)
            {
                SqlParameter param;
                param = cmd.Parameters.Add(SelectParamName, SqlDbType.Int);
                param.Value = SelectByParam;

            }

            con.Open();
            cmd.ExecuteNonQuery();
            

            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();


        }
        
        public RepeatedFrom()
        {
            InitializeComponent();
        }

        private void RepeatedFrom_Load(object sender, EventArgs e)
        {

        }

        protected virtual void btnAdd_Click(object sender, EventArgs e)
        {

        }
        protected virtual  void btnDelete_Click(object sender, EventArgs e)
        {

        }
        protected virtual void btnEdit_Click(object sender, EventArgs e)
        {

        }
  

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Controller cont = new Controller();
            cont.run();
          
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
