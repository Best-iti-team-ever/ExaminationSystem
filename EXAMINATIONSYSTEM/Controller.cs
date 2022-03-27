using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMINATIONSYSTEM
{
    public class Controller
    {
        public void run()
        {
            User user = UserSingleton.getinstance().user;
            switch (user.GetType().ToString())
            {
                case "EXAMINATIONSYSTEM.Student":
                    //"EXAMINATIONSYSTEM.Student":
                    StudentHomeForm studhome = new StudentHomeForm();
                    studhome.ShowDialog();
                    break;
                case "EXAMINATIONSYSTEM.Admin":
                    AdminHomeForm adminHomeForm = new AdminHomeForm();
                    adminHomeForm.ShowDialog();
                    break ;
                case "EXAMINATIONSYSTEM.Instructor":
                    InstructorHomeForm insHomeForm = new InstructorHomeForm();
                    insHomeForm.ShowDialog();
                    break;
            }
        }
    }
}
