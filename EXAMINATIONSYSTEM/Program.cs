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
            //Application.Run( new ChooseExam( UserSingleton.getinstance().user.uid ) );
            User user = UserSingleton.getinstance().user;
            switch (user.GetType().ToString())
            {
                case "EXAMINATIONSYSTEM.Student" :
                    //"EXAMINATIONSYSTEM.Student":
                    ChooseExam chooseExam = new ChooseExam(user.uid);
                    chooseExam.ShowDialog();
                    break;
            }

        }
    }
}
