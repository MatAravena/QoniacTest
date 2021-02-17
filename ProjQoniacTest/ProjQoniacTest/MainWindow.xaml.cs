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
using ProjQoniacTest.Commands;

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ServicioMessage serv = new ServicioMessage();
            lblResult.Content = serv.SendMessageAsync(txtMoney.MaskedTextProvider.ToString());


        }
    }
}
