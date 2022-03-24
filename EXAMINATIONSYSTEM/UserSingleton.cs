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
        static UserSingleton instance = null;
        public Home home { get; set; }
        private UserSingleton()
        { 
            home = new Home();
            home.ShowDialog();
            if(home.DialogResult==DialogResult.OK)
            {
                switch (home.user)
                {
                    case 1:
                        Loginform stdlg = new Loginform("Student");
                        stdlg.ShowDialog();
                        if (stdlg.DialogResult == DialogResult.OK)
                            user = new Student(int.Parse(stdlg.textBox1.Text), stdlg.textBox2.Text);
                        break;
                    case 2:
                        Loginform Inslg = new Loginform("Instructor");
                        Inslg.ShowDialog();
                        if (Inslg.DialogResult == DialogResult.OK)
                            user = new Instructor(int.Parse(Inslg.textBox1.Text), Inslg.textBox2.Text);
                        break;
                    case 3:
                        Loginform adlg = new Loginform("Admin");
                        adlg.ShowDialog();
                        if (adlg.DialogResult == DialogResult.OK)
                            user = new Admin(int.Parse(adlg.textBox1.Text), adlg.textBox2.Text);
                    break;

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
