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
using ProjQoniacTest.Services;
using System.ComponentModel;

namespace ProjQoniacTest
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lblResult.Content = string.Empty;
            this.Lbl = string.Empty;
            this.Txt = string.Empty;
        }
         

        private string _lbl;
        private string _txt;
        public string Lbl
        {
            get { return _lbl; }
            set
            {
                if (value != _lbl)
                {
                    _lbl = value; 
                }
            }
        }
        public string Txt
        {
            get { return _txt; }
            set
            {
                if (value != _txt)
                {
                    _txt = value;
                }
            }
        }

        public object PropertyChanged { get; private set; }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string numb = txtMoney.MaskedTextProvider.ToString();
                if (numb == null || numb.Length == 0 || numb.Equals("___ ___ ___,__"))
                {
                    Txt =  "invalid number";
                    lblResult.Content = "invalid number";
                    return;
                }

                ServicioMessage serv = new ServicioMessage();
                lblResult.Content = await serv.SendMessageAsync(numb);
            }
            catch (Exception ex)
            {
                lblResult.Content = ex.Message;
            }
        }
    }
}
