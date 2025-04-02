using System;
using System.Windows;
using System.Windows.Controls;

namespace Module11PracticalCalculator
{
    public partial class MainWindow : Window
    {
        private double _currentValue = 0;
        private string _currentOperation = string.Empty;
        private bool _isNewEntry = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (_isNewEntry)
                {
                    Display.Text = button.Content.ToString();
                    _isNewEntry = false;
                }
                else
                {
                    Display.Text += button.Content.ToString();
                }
            }
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                _currentValue = double.Parse(Display.Text);
                _currentOperation = button.Content.ToString();
                _isNewEntry = true;
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = "0";
            _currentValue = 0;
            _currentOperation = string.Empty;
            _isNewEntry = true;
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            double newValue = double.Parse(Display.Text);
            double result = 0;

            switch (_currentOperation)
            {
                case "+":
                    result = _currentValue + newValue;
                    break;
                case "-":
                    result = _currentValue - newValue;
                    break;
                case "x":
                    result = _currentValue * newValue;
                    break;
                case "/":
                    if (newValue != 0)
                    {
                        result = _currentValue / newValue;
                    }
                    else
                    {
                        MessageBox.Show("Cannot divide by zero", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    break;
            }

            Display.Text = result.ToString();
            _currentValue = result;
            _isNewEntry = true;
        }
    }
}
