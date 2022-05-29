using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentModel
{
    public class LabelAttribute : Attribute
    {
        public string LabelText { get; set; }

        public LabelAttribute(string labelText)
        {
            LabelText = labelText;
        }
    }
}
