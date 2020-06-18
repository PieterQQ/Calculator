using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
   
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private decimal number1 = 0;
        private decimal number2 = 0;
        private string operation = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberBtn_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            if (operation is null)
            {
               
                number1 = (number1 * 10) + decimal.Parse(clickedButton.Tag.ToString());
                Display.Text = number1.ToString();
            }
            else
            {
                number2 = (number2 * 10) + (decimal)clickedButton.Tag;
                Display.Text = number2.ToString();
            }
        }
    }
}
