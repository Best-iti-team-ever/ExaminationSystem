using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXAMINATIONSYSTEM
{
    public class UserSingleton
    {
        public User user { get; set; }
        public string connectionString { get; set; } = "Data Source=tcp:sqlproject.database.windows.net,1433;Initial Catalog = sqlproject;  Persist Security Info = False; User ID =sqlproject; Password =Project2022; MultipleActiveResultSets = False";
        static UserSingleton instance = null;
        private UserSingleton()
        {

            user = null;
            while (user == null)
            {
                Home home = new Home();
                home.ShowDialog();

                if(home.DialogResult==DialogResult.OK)
                {

                    switch (home.user)
                    {
                        case 1:
                            Loginform stdlg = new Loginform("Student");
                            stdlg.ShowDialog();
                            if (stdlg.DialogResult == DialogResult.OK)
                                user = Student.InitFromSQL(int.Parse(stdlg.textBox1.Text), stdlg.textBox2.Text.ToHash());
                            break;
                        case 2:
                            Loginform Inslg = new Loginform("Instructor");
                            Inslg.ShowDialog();
                            if (Inslg.DialogResult == DialogResult.OK)
                                user = Instructor.InitFromSQL(int.Parse(Inslg.textBox1.Text), Inslg.textBox2.Text.ToHash());
                            break;
                        case 3:
                            Loginform adlg = new Loginform("Admin");
                            adlg.ShowDialog();
                            if (adlg.DialogResult == DialogResult.OK)
                                user = Admin.InitFromSQL(int.Parse(adlg.textBox1.Text), adlg.textBox2.Text.ToHash());
                        break;
                    }
                }
            }
        }
        public static UserSingleton getinstance()
        {
            if(instance!=null)
            {
                return instance;
            }
            else
            {
                instance = new UserSingleton();
                return instance;
            }
        }
    }
}
