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

namespace SimpleCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CalculatorWindow : Window
    {
        public CalculatorWindow()
        {
            InitializeComponent();
            weight.Focus();
        }

        /// <summary>
        /// calculate method
        /// </summary>
        private void ButtonCalculate_Click(object sender, RoutedEventArgs e)
        {
            //Button operationButton = sender as Button;
            string caffeineSelection = comboBoxCaffeine.SelectionBoxItem as string;
            string drinkName = "";
            double caffeineContent = 0;
            double sensitivity = SensitivityLevel();
            double inputWeight = 0;

            if (double.TryParse(weight.Text, out inputWeight))
            {
                if (caffeineSelection == "Cup of Coffee (8 Oz)")
                {
                    caffeineContent = 163;
                    drinkName = "Cup(s) of Coffee";
                }
                if (caffeineSelection == "Can of Soda (12 Oz)")
                {
                    caffeineContent = 39;
                    drinkName = "Can(s) of Soda";
                }
                if (caffeineSelection == "Coffee, Espresso (1 Oz)")
                {
                    caffeineContent = 64;
                    drinkName = "Shot(s) of Espresso";
                }
                if (caffeineSelection == "Cup of Tea (8 Oz)")
                {
                    caffeineContent = 26;
                    drinkName = "Cup(s) of Tea";
                }

                double kilos = inputWeight / 2.205;

                double limit = (kilos * 6) / caffeineContent + sensitivity;

                answer.Text = Math.Round(limit) + " " + drinkName;

            }

            else
            {
                Console.WriteLine();
                Console.WriteLine("Please enter a valid weight.");
            }

        }

        /// <summary>
        /// Exxit button
        /// </summary>
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// help button
        /// </summary>
        private void Help_Button_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.ShowDialog();
        }

        /// <summary>
        /// User feedback
        /// </summary>
        private void Input_Changed(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(weight.Text, out double number))
            {
                textBlockUserFeedback.Text = "Weight Must Be Numeric.";
            }
            else
            {
                textBlockUserFeedback.Text = "";
            }
        }

        /// <summary>
        /// Checks if the radio buttons are checked
        /// </summary>
        private void Sensitive_Checked(object sender, RoutedEventArgs e)
        {
            if (IsLoaded)
            {
                SensitivityLevel();
            }
        }

        /// <summary>
        /// Sets the sesnsitivity to whichever radio button was selected
        /// </summary>
        private double SensitivityLevel()
        {
            double sensitivity = 0;

            if ((bool)normal.IsChecked)
            {
                sensitivity = 0;
            }

            if ((bool)moreSensitive.IsChecked)
            {
                sensitivity = -1;
            }

            if ((bool)lessSensitive.IsChecked)
            {
                sensitivity = 1;
            }

            return sensitivity;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            weight.Clear();
            answer.Clear();
            textBlockUserFeedback.Text = " ";
            weight.Focus();
        }
    }
}
