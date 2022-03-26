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
            InitializeComponent();
            //this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            BindDatatoDataGrid("sp_selectcoursesforinstructor", UserSingleton.getinstance().user.uid);
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
    }
}
