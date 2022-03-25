using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMINATIONSYSTEM
{
   abstract public class User
    {
        public int uid { get; set; }
        public String name { get; set; }
        public float Mobile { get; set; }
        //public static abstract User InitFromSQL(int id, string pass);
    }
}
