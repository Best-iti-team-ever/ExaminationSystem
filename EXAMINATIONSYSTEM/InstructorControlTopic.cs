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
    public partial class InstructorControlTopic : RepeatedFrom
    {
        SqlConnection con;
        int crsid;
        public InstructorControlTopic(int cid)
        {
            InitializeComponent();
            con = new SqlConnection(UserSingleton.getinstance().connectionString);
            crsid = cid;
            label1.Text = "Topics for Course " + cid;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            BindDatatoDataGrid("sp_topicsincourse",crsid, "@crsid");

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgv = dataGridView1.Rows[e.RowIndex];
                label5.Text= dgv.Cells[1].Value.ToString();
                textBox1.Text = dgv.Cells[2].Value.ToString();
              
            }

        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_inserttopic", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param;

            param = cmd.Parameters.Add("@crsid ", SqlDbType.Int);
            param.Value = crsid;

            param = cmd.Parameters.Add("@name", SqlDbType.VarChar,50);
            param.Value = textBox1.Text;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            BindDatatoDataGrid("sp_topicsincourse", crsid, "@crsid");
            MessageBox.Show("A new Topic has been added to this course");
            textBox1.Text = string.Empty;
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_deletetopic", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@id", SqlDbType.Int);
            param.Value = int.Parse(label5.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("This topic is deleted from your Course data! ");
            con.Close();
            BindDatatoDataGrid("sp_topicsincourse", crsid, "@crsid");
            textBox1.Text = string.Empty;
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            SqlParameter param;
            SqlCommand cmd;

           
            cmd = new SqlCommand("sp_updatetopic", con);
            
            cmd.CommandType = CommandType.StoredProcedure;

            param = cmd.Parameters.Add("@id", SqlDbType.Int);
            param.Value = int.Parse(label5.Text);

            param = cmd.Parameters.Add("@crsid ", SqlDbType.Int);
            param.Value = crsid;

            param = cmd.Parameters.Add("@name", SqlDbType.VarChar, 50);
            param.Value = textBox1.Text;
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Topic Updated!");
            con.Close();
            BindDatatoDataGrid("sp_topicsincourse", crsid, "@crsid");
            textBox1.Text = string.Empty;
        }
    }
}
