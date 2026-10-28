using System;

namespace Calculatorultra2._0
{
    internal class Math
    {
        public double Addition(double a, double b)
        {
            return a + b;
        }
        public double Subtraction(double a, double b)
        {
            return a - b;
        }
        public double Multiplication(double a, double b)
        {
            return a * b;
        }
        public double Divider(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Деление на ноль невозможно");
            }
            return a / b;
        }
        public double Percent(double a, double b)
        {
            return (a * b) / 100.0;
        }
        public double Power(double baseValue, int exponent)
        {
            return System.Math.Pow(baseValue, exponent);
        }
    }
}