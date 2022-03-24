using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMINATIONSYSTEM
{
    class Instructor :User
    {
        public String Degree { get; set; }
        public String Email { get; set; }
        public Instructor(int id,string pass)
        {
            
            //TODO:database procedure V COPY FROM FORM STUDENT LOGIN

        }

    }
}
