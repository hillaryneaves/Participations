using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfThrones_Participation
{
    internal class GOTResult
    {
        public string quote { get; set; }
        public string character { get; set; }
        //public string url { get; set; }

        public override string ToString()
        {
            return $"{quote}    -{character}";
        }
    }
}
