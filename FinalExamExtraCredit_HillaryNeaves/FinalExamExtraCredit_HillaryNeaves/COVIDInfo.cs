using System;
using System.Collections.Generic;
using System.Text;

namespace FinalExamExtraCredit_HillaryNeaves
{
    public class COVIDInfo
    {
        public List<States> casesByState { get; set; }
    }

    public class States
    {
        public string casesReported { get; set; }
        public string name { get; set; }
        public override string ToString()
        {
            return name;
        }
    }
}
