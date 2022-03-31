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
    public partial class InstructorHomeForm : Form
    {
        SqlConnection con;
        public InstructorHomeForm()
        {

            InitializeComponent();
            comboBox1.Hide();
            label6.Hide();
            con = new SqlConnection(UserSingleton.getinstance().connectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand("sp_isDepartmentManager", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = cmd.Parameters.Add("@instructor_id", SqlDbType.Int);
            param.Value = UserSingleton.getinstance().user.uid;

            SqlDataReader dReader = cmd.ExecuteReader();
            if (dReader.HasRows)
            {
                comboBox1.Show();
                label6.Show();
                while (dReader.Read())
                {
                    comboBox1.Items.Add(dReader[0].ToString());
                }
            }
            
            dReader.Close();
            con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            InstructorDataUpdate insupdate = new InstructorDataUpdate();
            insupdate.ShowDialog();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            InstructorControlCourse course = new InstructorControlCourse();
            course.ShowDialog();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.ShowDialog();
            this.Close();

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void label3_Click(object sender, EventArgs e)
        {
            ReportForm report = new ReportForm();
            report.ShowDialog();
            this.Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int dept_id = comboBox1.SelectedItem.toInt();
            UpdateDepartmentForm up = new UpdateDepartmentForm(dept_id);
            up.ShowDialog();
            this.Hide();
        }
    }
}
