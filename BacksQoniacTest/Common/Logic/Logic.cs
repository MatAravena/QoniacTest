using Common.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Logic
{
    public class Logic
    {
        public void GetValue(ref DataMessage message)
        {
            try
            {
                if (message.numbValue == null || message.numbValue.Length == 0 || message.numbValue.Equals("___ ___ ___,__"))
                    message.numbInWords = "invalid number";

                //0 zero dollars
                //1 one dollar
                //25,1 twenty - five dollars and ten cents
                //0,01 zero dollars and one cent
                //45 100 forty - five thousand one hundred dollars
                //999 999 999,99 nine hundred ninety - nine million nine hundred
                //ninety - nine thousand nine hundred ninety-nine dollars and ninety - nine cents

                int number = 0, centsValue = 0;
                string cents = string.Empty;
                string[] lstValues = message.numbValue.Trim().Replace(" ", string.Empty).Split(Convert.ToChar(","));

                if (lstValues.Length > 0 && !int.TryParse(lstValues[0].Replace("_", string.Empty), out number))
                    number = 0;

                if (lstValues.Length > 1 && lstValues[1].Length >= 1)
                {
                    cents = lstValues[1].Replace("_", "0");
                    if (!int.TryParse(cents, out centsValue))
                        centsValue = 0;
                }

                string dollars = string.Empty, centsWords = string.Empty, with = string.Empty;
                AssignWords(number, centsValue, ref dollars, ref centsWords, ref with);

                if (centsValue > 0)
                    message.numbInWords = string.Format("{0} {1} {2} {3} {4}", this.NumberToWord(number), dollars, with, ConvertDecimals(cents), centsWords);
                else
                    message.numbInWords = string.Format("{0} {1}", this.NumberToWord(number), dollars);
            }
            catch (Exception e)
            {
                message.numbInWords = e.Message;
            }
        }

        private string ConvertDecimals(string number)
        {
            if (number.Length > 1 && number[0].ToString().Equals("0"))
                return this.Units(number);

            return this.Tens(number, true);
        }

        public string NumberToWord(int numb)
        {
            string test = string.Empty;

            if (numb == 0)
                return "zero";

            if (numb < 0)
                return "negavitve " + NumberToWord(Math.Abs(numb));

            if ((numb / 1000000) > 0)
            {
                test += NumberToWord(numb / 1000000) + " million ";
                numb %= 1000000;
            }

            if ((numb / 1000) > 0)
            {
                test += NumberToWord(numb / 1000) + " thousand ";
                numb %= 1000;
            }

            if ((numb / 100) > 0)
            {
                test += NumberToWord(numb / 100) + " hundred ";
                numb %= 100;
            }

            if (numb <= 9)
                test += Units(numb.ToString());
            else
                test += Tens(numb.ToString());

            return test;
        }

        private string Tens(string decimals, bool isCent = false)
        {
            string name = string.Empty;
            switch (int.Parse(decimals))
            {
                case 10:
                    return "ten";
                case 11:
                    return "eleven";
                case 12:
                    return "twelve";
                case 13:
                    return "thirteen";
                case 14:
                    return "fourteen";
                case 15:
                    return "fifteen";
                case 16:
                    return "sixteen";
                case 17:
                    return "seventeen";
                case 18:
                    return "eighteen";
                case 19:
                    return "nineteen";
                case 20:
                    name = "twenty";
                    break;
                case 30:
                    name = "thirty";
                    break;
                case 40:
                    name = "fourty";
                    break;
                case 50:
                    name = "fifty";
                    break;
                case 60:
                    name = "sixty";
                    break;
                case 70:
                    name = "seventy";
                    break;
                case 80:
                    name = "eighty";
                    break;
                case 90:
                    name = "ninety";
                    break;
                default:
                    return this.Tens(decimals.Substring(0, 1) + "0") + " " + this.Units(decimals.Substring(1));
            }

            if (isCent)
                return name;

            return name + " -";
        }

        private string Units(string units)
        {
            int _Number = Convert.ToInt32(units);
            string name = "";
            switch (_Number)
            {
                //case 0:
                //    name = "zero";
                //    break;
                case 1:
                    name = "one";
                    break;
                case 2:
                    name = "two";
                    break;
                case 3:
                    name = "three";
                    break;
                case 4:
                    name = "four";
                    break;
                case 5:
                    name = "five";
                    break;
                case 6:
                    name = "six";
                    break;
                case 7:
                    name = "seven";
                    break;
                case 8:
                    name = "eight";
                    break;
                case 9:
                    name = "nine";
                    break;
            }
            return name;
        }

        private void AssignWords(int number, int cents, ref string dollars, ref string centsWords, ref string with)
        {
            if (number == 1)
                dollars = "dollar";
            else
                dollars = "dollars";

            if (cents > 0)
            {
                with = "and";
                centsWords = string.Format("cent{0}", cents >= 10 ? "s" : string.Empty);
            }
        }


    }
}
