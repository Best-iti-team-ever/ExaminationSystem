using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMINATIONSYSTEM
{
    class Student : User
    {
        public String Address { get; set; }
        public int gradyear { get; set; }
        public Student(int id,string pass)
        {
            //TODO:database procedure V COPY FROM FORM STUDENT LOGIN
        }
    }
}
