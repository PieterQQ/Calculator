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
        private string number1 = String.Empty;
        private string number2 = String.Empty;
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
               
                number1 += clickedButton.Tag.ToString();
                Display.Text = number1.ToString();
            }
            else
            {
               
                number2 += clickedButton.Tag.ToString();
                Display.Text = number2.ToString();
                DisplayHistory.Text +=number2;
            }
        }

        private void OperationBtn_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            operation = clickedButton.Tag.ToString();
            DisplayHistory.Text = number1 + operation;
            Display.Text = "0";
        }

        private void BtnEquals_Click(object sender, RoutedEventArgs e)
        {
            switch (operation)
            {
                case "+":
                    Display.Text = (double.Parse(number1) + double.Parse(number2)).ToString();
                    break;
                case "-":
                    Display.Text = (double.Parse(number1) - double.Parse(number2)).ToString();
                    break;
                case "*":
                    Display.Text = (double.Parse(number1) * double.Parse(number2)).ToString();
                    break;
                case "/":
                    if (number2!="0")
                    {
                        Display.Text = (double.Parse(number1) / double.Parse(number2)).ToString();
                       
                    }
                 else
                    {
                        Display.Text = "Błąd dzielenia przez 0";
                         number1 = String.Empty;
                        number2 = String.Empty;
                        operation = null;
                        return;
                    }
                    break;

            }
            number1 = Display.Text;
            number2 = String.Empty;
        }

        private void BtnClearEntry_Click(object sender, RoutedEventArgs e)
        {
            if (operation is null)
                number1 = String.Empty;
            else
                number2 = String.Empty;
            Display.Text = "0";
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            number1 = String.Empty;
            number2 = String.Empty;
            operation = null;
            Display.Text = "0";
        }

        private void BtnBackspace_Click(object sender, RoutedEventArgs e)
        {
            if (operation is null)
            {

                number1 = number1.Remove(number1.Length - 1);
                Display.Text = number1.ToString();
            }
            else
            {
                number2 = number2.Remove(number2.Length - 1);
                Display.Text = number2.ToString();
            }
        }

        private void BtnPosNeg_Click(object sender, RoutedEventArgs e)
        {
            if (operation is null)
            {

                number1 = (double.Parse(number1) * -1).ToString();
                Display.Text = number1.ToString();
            }
            else
            {
                number2 = (double.Parse(number2) * -1).ToString();
                Display.Text = number2.ToString();
            }
        }

        private void BtnDot_Click(object sender, RoutedEventArgs e)
        {
            if (!number1.Contains(","))
            {
                if(number1 == String.Empty)
                    number1 += "0,";
                else
                number1 += ",";
                Display.Text = number1.ToString();
            }
            else if (!number2.Contains(","))
            {
                if (number2 == String.Empty)
                    number2 += "0,";
                else
                    number2 += ",";
                Display.Text = number2.ToString();
            }
        }
    }
}
