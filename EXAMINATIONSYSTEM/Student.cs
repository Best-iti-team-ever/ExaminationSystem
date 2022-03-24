using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMINATIONSYSTEM
{
    class Student : User
    {
        SqlConnection con;
        public String Address { get; set; }
        public int gradyear { get; set; }
        public string deptname { get; set; }
        public Student(int id,string pass)
        {
            string connetionString = "Data Source=tcp:sqlproject.database.windows.net,1433;Initial Catalog = sqlproject;  Persist Security Info = False; User ID =sqlproject; Password =Project2022; MultipleActiveResultSets = False";
            con = new SqlConnection(connetionString);


            SqlCommand cmd = new SqlCommand("StudentLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param;
            param = cmd.Parameters.Add("@stud_id", SqlDbType.VarChar, 50);
            param.Value = id;

            param = cmd.Parameters.Add("@std_pass", SqlDbType.VarChar, 50);
            param.Value = pass;
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader dReader = cmd.ExecuteReader();
            while (dReader.Read())
            {
                uid = int.Parse(dReader[0].ToString());
                name = dReader[1].ToString()+" "+dReader[2].ToString();
                Mobile = float.Parse(dReader[3].ToString());
                Address = dReader[4].ToString();
                gradyear =int.Parse(dReader[5].ToString());
                deptname = dReader[8].ToString();
                ChooseExam CH = new ChooseExam(uid);
                 CH.ShowDialog();
                
            }
            // Call Close when done reading.
            dReader.Close();
            con.Close();
        }
    }
}
