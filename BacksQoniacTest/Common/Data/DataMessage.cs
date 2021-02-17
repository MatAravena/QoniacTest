using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Data
{
    public class DataMessage
    {
        public DataMessage(string numbValue)
        {
            this.numbValue = numbValue;
        }

        public string numbValue { get; set; }
        public string numbInWords { get; set; }

    }
}
