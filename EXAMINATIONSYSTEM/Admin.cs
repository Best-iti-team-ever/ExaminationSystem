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
    class Admin : User
    {

        public static User InitFromSQL(int id, string pass)
        {
            SqlConnection con;

            string connetionString = "Data Source=tcp:sqlproject.database.windows.net,1433;Initial Catalog = sqlproject;  Persist Security Info = False; User ID =sqlproject; Password =Project2022; MultipleActiveResultSets = False";
            con = new SqlConnection(connetionString);


            SqlCommand cmd = new SqlCommand("selectadmin", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param;
            param = cmd.Parameters.Add("@ad_id", SqlDbType.Int);
            param.Value = id;

            param = cmd.Parameters.Add("@ad_pass", SqlDbType.VarChar, 64);
            param.Value = pass;
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader dReader = cmd.ExecuteReader();
            if (dReader.HasRows)
            {
                Admin admin = new Admin();

                if (dReader.Read())
                {
                    admin.uid = int.Parse(dReader[0].ToString());
                    admin.name = dReader[1].ToString();
                    admin.Mobile = dReader[2].ToString();

                    //ChooseExam CH = new ChooseExam(uid);
                    //CH.ShowDialog();
                }
                dReader.Close();
                con.Close();
                return admin;
                // Call Close when done reading.
            }
            else
            {
                MessageBox.Show("Incorrect Credentials");
                dReader.Close();
                con.Close();
                return null;
            }
        }

        private Admin()
        {
            
        }
        
    }
}
