using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Xceed.Wpf.Toolkit;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjQoniacTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lblResult.Content = string.Empty;
        }

        public string getInitialValue(string s)
        {
            try
            {
                if (s == null || s.Length == 0 || s.Equals("___ ___ ___,__"))
                    return "invalid number";

                string x = s.Replace("_", string.Empty).Replace(",", ".");

                decimal wholeNumber = decimal.Parse(s.Replace("_", string.Empty));
                if (wholeNumber == 0)
                    return "0 dolar";

                //0 zero dollars
                //1 one dollar
                //25,1 twenty - five dollars and ten cents
                //0,01 zero dollars and one cent
                //45 100 forty - five thousand one hundred dollars
                //999 999 999,99 nine hundred ninety - nine million nine hundred
                //ninety - nine thousand nine hundred      ninety-nine dollars      and ninety - nine cents

                int number = 0, cents = 0;
                string[] lstValues = x.Trim().Split(".");
                number = int.Parse(lstValues[0]);
                cents = int.Parse(lstValues[1]);

                string dollars = string.Empty, centsWords = string.Empty, with = string.Empty;
                assignWords(number, cents, ref dollars, ref centsWords, ref with);

                return string.Format("{0} {1} {2} {3} {4}", this.NumberToWord(number.ToString()), dollars, with, this.NumberToWord(cents.ToString()), centsWords);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string NumberToWord(string s)
        {
            string prueba = Decimals(s);
            int numb = int.Parse(s);

            //switch (true)
            //{
            //    case true.Equals(numb >= 100 && numb < 200):
            //        prueba = "";
            //        break;

            //    default:
            //        break;
            //}
            //999 999 999

            switch (int.Parse(s))
            {
                case 0:
                    return "cero";

                default:
                    break;
            }

            return prueba;
        }

        private string Decimals(string decimals)
        {
            string name = string.Empty;
            int numb = int.Parse(decimals);
            switch (numb)
            {
                case 10:
                    name = "Ten - ";
                    break;
                case 11:
                    name = "Eleven - ";
                    break;
                case 12:
                    name = "Twelve - ";
                    break;
                case 13:
                    name = "Thirteen - ";
                    break;
                case 14:
                    name = "Fourteen - ";
                    break;
                case 15:
                    name = "Fifteen - ";
                    break;
                case 16:
                    name = "Sixteen - ";
                    break;
                case 17:
                    name = "Seventeen - ";
                    break;
                case 18:
                    name = "Eighteen - ";
                    break;
                case 19:
                    name = "Nineteen - ";
                    break;
                case 20:
                    name = "Twenty - ";
                    break;
                case 30:
                    name = "Thirty - ";
                    break;
                case 40:
                    name = "Fourty - ";
                    break;
                case 50:
                    name = "Fifty - ";
                    break;
                case 60:
                    name = "Sixty - ";
                    break;
                case 70:
                    name = "Seventy - ";
                    break;
                case 80:
                    name = "Eighty - ";
                    break;
                case 90:
                    name = "Ninety - ";
                    break;
                default:
                    name = this.Decimals(decimals.Substring(0, 1) + "0") + " " + this.Units(decimals.Substring(1));
                    break;
            }
            return name;
        }

        private string Units(string units)
        {
            int _Number = Convert.ToInt32(units);
            string name = "";
            switch (_Number)
            {
                case 0:
                    name = "Zero";
                    break;
                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }

        private void assignWords(int number, int cents, ref string dollars, ref string centsWords, ref string with)
        {
            if (number > 0 && number <= 9)
                dollars = "dolar";
            else
                dollars = "dollars";

            if (cents >= 0)
            {
                with = "with";
                centsWords = string.Format("cent{0}", cents >= 10 ? "s" : string.Empty);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lblResult.Content = this.getInitialValue(txtMoney.MaskedTextProvider.ToString());
        }

    }
}
