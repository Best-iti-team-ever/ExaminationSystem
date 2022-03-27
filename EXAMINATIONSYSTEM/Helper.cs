using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EXAMINATIONSYSTEM
{
    static class Helper
    {
        public static string ToHash(this String plain )
        {
            SHA256 sha256 = new SHA256Managed();
            return BitConverter.ToString(sha256.ComputeHash(Encoding.ASCII.GetBytes(plain))).Replace("-", "");
        }
        public static int toInt(this Object o)
        {
            if (o is null)
                return -1;
            if (o.ToString() == string.Empty)
                return -1;

            return int.Parse(o.ToString());    
        }
    }
}
