using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EXAMINATIONSYSTEM
{
    public class ItemWVal : RadioButton 
    {
        public String Text { get; set; }
        public int Value { get; set; }
        public ItemWVal() : base()
        {
        }
        public override string ToString()
        {
            return Text;
        }
    }
}
