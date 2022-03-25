using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EXAMINATIONSYSTEM
{
    public partial class Std_Signup : Form
    {
        SqlConnection con;


        public Std_Signup()
        {
            InitializeComponent();
            //Fill student Data

            string connetionString = "Data Source=tcp:sqlproject.database.windows.net,1433;Initial Catalog = sqlproject;  Persist Security Info = False; User ID =sqlproject; Password =Project2022; MultipleActiveResultSets = False";
            con = new SqlConnection(connetionString);

            con.Open();
            sqlDataAdapter1.Fill(dataSet1);
            con.Close();
            

            //Fill Department Data

            sqlConnection1.Open();
            sqlDataAdapter2.Fill(dataSet2);
            sqlConnection1.Close();

            
        }

        private void button1_Click(object sender, EventArgs e)//SUBMIT
        {
            SqlCommand cmd = new SqlCommand("sp_insertstudent",con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param;



            param = cmd.Parameters.Add("@std_fname", SqlDbType.VarChar, 50);
            param.Value = textBox1.Text;

            param = cmd.Parameters.Add("@std_lname", SqlDbType.VarChar, 50);
            param.Value = textBox2.Text;

            param = cmd.Parameters.Add("@std_mobile", SqlDbType.BigInt);
            param.Value =int.Parse(textBox3.Text);

            param = cmd.Parameters.Add("@std_address", SqlDbType.NVarChar,50);
            param.Value = textBox4.Text;

            param = cmd.Parameters.Add("@std_grandYear", SqlDbType.Int);
            param.Value =int.Parse(textBox5.Text);

            param = cmd.Parameters.Add("@dept_id", SqlDbType.Int);
            param.Value = int.Parse(comboBox1.Text);

            param = cmd.Parameters.Add("@std_passowrd", SqlDbType.VarChar,64);
            param.Value = textBox7.Text.ToHash();

            sqlConnection1.Open();
            cmd.Connection = sqlConnection1;
            cmd.ExecuteNonQuery();
            SqlDataReader dReader = cmd.ExecuteReader();
            if (dReader.Read())
            {
                MessageBox.Show("Welcome " + textBox1.Text + " " + textBox2.Text + " Your login Id is : " + dReader[0].ToString() + "\nYour Data is added to our System");
            }
            dReader.Close();
            sqlConnection1.Close();
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox7.Text = string.Empty;
            comboBox1.Text = string.Empty;

            //Loginform stdlg = new Loginform("Student");
            this.Hide();
            //stdlg.ShowDialog();
            this.Close();

        }

        private void Std_Signup_Load(object sender, EventArgs e)//ON PAGE LOAD
        {

            for (int i = 0; i <dataSet2.Tables[0].Rows.Count;i++)
            {
                DataRow dr = dataSet2.Tables[0].Rows[i];
                comboBox1.Items.Add(dr["Dept_ID"].ToString());
            }

        }

        private void label1_Click(object sender, EventArgs e)//Home
        {
            //Home HOME = new Home();
            this.Hide();
            //HOME.ShowDialog();
            this.Close();

        }

        private void label4_Click(object sender, EventArgs e)//EXIT
        {
            Environment.Exit(0);
        }
    }
}
