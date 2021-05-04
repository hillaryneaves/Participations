using System;
using System.Collections.Generic;
using System.Text;

namespace GOTRedoExamPrep
{
    public class SecondWindow
    { 
        public string quote { get; set; }
        public string character { get; set; }

        public override string ToString()
        {
            return $"{quote}               -{character}";
        }
    }
}
