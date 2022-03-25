using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXAMINATIONSYSTEM
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Home());
            Application.Run( new ChooseExam( UserSingleton.getinstance().user.uid ) );
            //UserSingleton user = UserSingleton.getinstance();
           //((Student)user.user).

        }
    }
}
