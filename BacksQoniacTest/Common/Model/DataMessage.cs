using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Model
{
    public class DataMessage
    {
        public string numbValue { get; set; }
        public string numbInWords { get; set; }

        public DataMessage()
        {
        }
        public DataMessage(string numbValue)
        {
            this.numbValue = numbValue;
        }

        public DataMessage(DataMessage value)
        {
            if (value != null)
            {
                this.numbValue = value.numbValue;
                this.numbInWords = value.numbInWords;
            }
        }
    }
}
