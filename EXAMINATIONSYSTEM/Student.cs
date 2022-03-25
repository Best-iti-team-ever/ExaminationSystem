using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXAMINATIONSYSTEM
{
    class Student : User
    {
        SqlConnection con;
        public String Address { get; set; }
        public int gradyear { get; set; }
        public string deptname { get; set; }

        public static User InitFromSQL(int id, string pass)
        {
            SqlConnection con;
            string connetionString = "Data Source=tcp:sqlproject.database.windows.net,1433;Initial Catalog = sqlproject;  Persist Security Info = False; User ID =sqlproject; Password =Project2022; MultipleActiveResultSets = False";
            con = new SqlConnection(connetionString);


            SqlCommand cmd = new SqlCommand("StudentLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param;
            param = cmd.Parameters.Add("@stud_id", SqlDbType.Int);
            param.Value = id;

            param = cmd.Parameters.Add("@std_pass", SqlDbType.VarChar, 64);
            param.Value = pass;
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader dReader = cmd.ExecuteReader();
            if (dReader.HasRows)
            {
                Student student = new Student();

                if (dReader.Read())
                {                  
                    student.uid = int.Parse(dReader[0].ToString());
                    student.name = dReader[1].ToString() + " " + dReader[2].ToString();
                    student.Mobile = float.Parse(dReader[3].ToString());
                    student.Address = dReader[4].ToString();
                    student.gradyear = int.Parse(dReader[5].ToString());
                    student.deptname = dReader[8].ToString();
                }
                dReader.Close();
                con.Close();
                return student;
            }
            else
            {
                MessageBox.Show("Incorrect Credentials");
                dReader.Close();
                con.Close();
                return null;
            }
        }


        private Student()
        {

        }
    }
}
