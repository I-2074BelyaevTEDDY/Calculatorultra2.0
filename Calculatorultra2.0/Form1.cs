using System;
using System.Windows.Forms;

namespace Calculatorultra2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Calculatorultra2._0.Math calcMath = new Calculatorultra2._0.Math();
        bool newOperation = true;
        bool lastAction = true;
        double firstValue;
        double secondValue;
        double result = 0.0;
        string choosenOperation = "";
        private void button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (newOperation)
            {
                textBox1.Clear();
                newOperation = false;
            }

            if (btn.Text == ",")
            {
                var val = textBox1.Text.IndexOf(',');
                if (val != -1)
                {
                    return; 
                }
                if (textBox1.Text == "")
                {
                    textBox1.Text = "0";
                }
            }

            textBox1.Text += btn.Text;
            lastAction = false;
        }
        private void operator_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            if (btn.Text == "AC")
            {
                firstValue = 0;
                secondValue = 0;
                result = 0;
                choosenOperation = "";
                textBox1.Text = "0";
                newOperation = true;
                lastAction = false;
                return;
            }
            if (btn.Text == "<--")
            {
                if (textBox1.Text.Length <= 1)
                {
                    textBox1.Text = "0";
                    newOperation = true;
                }
                else
                {
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                }
                return;
            }

            try
            {
                if (btn.Text != "=")
                {
                    if (choosenOperation != "" && !newOperation)
                    {
                        secondValue = Convert.ToDouble(textBox1.Text);
                        ExecuteMathOperations();
                        firstValue = result;
                    }
                    else
                    {
                        firstValue = Convert.ToDouble(textBox1.Text);
                    }

                    choosenOperation = btn.Text;
                    newOperation = true;
                    lastAction = false;
                    return;
                }
                if (lastAction)
                {
                    firstValue = Convert.ToDouble(textBox1.Text);
                }
                else
                {
                    secondValue = Convert.ToDouble(textBox1.Text);
                }
                ExecuteMathOperations();

                textBox1.Text = result.ToString();
                newOperation = true;
                lastAction = true;
                choosenOperation = ""; 
            }
            catch (DivideByZeroException ex)
            {
                textBox1.Text = ex.Message;
                ResetState();
            }
            catch (FormatException)
            {
                textBox1.Text = "Неверный формат";
                ResetState();
            }
            catch (Exception)
            {
                textBox1.Text = "Ошибка";
                ResetState();
            }
        }
        private void ExecuteMathOperations()
        {
            switch (choosenOperation)
            {
                case "+":
                    result = calcMath.Addition(firstValue, secondValue);
                    break;
                case "-":
                    result = calcMath.Subtraction(firstValue, secondValue);
                    break;
                case "*":
                    result = calcMath.Multiplication(firstValue, secondValue);
                    break;
                case "/":
                    result = calcMath.Divider(firstValue, secondValue);
                    break;
                case "%":
                    result = calcMath.Percent(firstValue, secondValue);
                    break;
                case "^":
                    result = calcMath.Power(firstValue, Convert.ToInt32(secondValue));
                    break;
                default:
                    result = Convert.ToDouble(textBox1.Text);
                    break;
            }
        }
        private void ResetState()
        {
            firstValue = 0;
            secondValue = 0;
            result = 0;
            choosenOperation = "";
            newOperation = true;
            lastAction = true;
        }
    }
}