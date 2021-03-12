using System;
using System.Collections.Generic;
using System.Text;

namespace GOTQuote
{
    public class SecondWindow
    {
        public List<ResultObject> results { get; set; }
    }

    public class ResultObject
    {
        public string url { get; set; }
        public string quote { get; set; }
        public string name { get; set; }

        public override string ToString()
        {
            return quote;
        }
    }
}
