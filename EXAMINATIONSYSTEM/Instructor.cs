using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMINATIONSYSTEM
{
    
    class Instructor :User
    {
        SqlConnection con;

        public String Degree { get; set; }
        public String Email { get; set; }
        public Instructor(int id,string pass)
        {
            string connetionString = "Data Source=tcp:sqlproject.database.windows.net,1433;Initial Catalog = sqlproject;  Persist Security Info = False; User ID =sqlproject; Password =Project2022; MultipleActiveResultSets = False";
            con = new SqlConnection(connetionString);

           
            SqlCommand cmd = new SqlCommand("InstructorLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param;
            param = cmd.Parameters.Add("@ins_id", SqlDbType.VarChar, 50);
            param.Value = id;

            param = cmd.Parameters.Add("@ins_pass", SqlDbType.VarChar, 50);
            param.Value = pass;
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader dReader = cmd.ExecuteReader();
            while (dReader.Read())
            {
                uid =int.Parse(dReader[0].ToString());
                name = dReader[1].ToString();
                Mobile = float.Parse(dReader[2].ToString());
                Email = dReader[3].ToString();
                Degree = dReader[5].ToString();
            }

            // Call Close when done reading.
            dReader.Close();
            con.Close();

        }

    }
}
