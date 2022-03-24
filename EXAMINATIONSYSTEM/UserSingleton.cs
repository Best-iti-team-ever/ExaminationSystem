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
        private UserSingleton()
        { 
            Home home = new Home();
            home.ShowDialog();
            if(home.DialogResult==DialogResult.OK)
            {
                switch (home.user)
                {
                    case 1:
                        StudentLogin stdlg = new StudentLogin();
                        stdlg.ShowDialog();
                        user = new Student(int.Parse(stdlg.textBox1.Text), stdlg.textBox2.Text);
                        break;
                    case 2:
                        Instructorlogin Inslg = new Instructorlogin();
                        Inslg.ShowDialog();
                        user = new Instructor(int.Parse(Inslg.textBox1.Text), Inslg.textBox2.Text);
                        break;
                    //case 3:

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
