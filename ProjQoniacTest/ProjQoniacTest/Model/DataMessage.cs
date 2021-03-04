using System;
using System.Collections.Generic;
using System.Text;

namespace ProjQoniacTest.Model
{
    public class DataMessage
    {
        public DataMessage()
        {
        }
        public DataMessage(string numbValue)
        {
            this.numbValue = numbValue;
        }

        public string numbValue { get; set; }
        public string numbInWords { get; set; }

    }
}
