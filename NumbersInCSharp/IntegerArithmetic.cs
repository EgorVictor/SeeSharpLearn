using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersInCSharp
{
    public class IntegerArithmetic
    {
        internal void WorkWithIntegers()
        {
            int a = 18;
            int b = 6;
            int c = a + b;
            Console.WriteLine(c);

            c = a - b;
            Console.WriteLine(c);

            c = a * b;
            Console.WriteLine(c);

            c = a / b;
            Console.WriteLine(c);
        }

        internal void OrderPrecedence()
        {
            int a = 5;
            int b = 4;
            int c = 2;
            int d = a + b * c;
            Console.WriteLine(d);

            d = (a + b) * c;
            Console.WriteLine(d);

            d = (a + b) - 6 * c + (12 * 4) / 3 + 12;
            Console.WriteLine(d);

            int e = 7;
            int f = 4;
            int g = 3;
            int h = (e + f) / g;
            Console.WriteLine(h);
        }

        internal void IntMaxMinValue()
        {
            int maxValue = int.MaxValue;
            int minValue = int.MinValue;

            Console.WriteLine($"int range is {minValue} to {maxValue}");
        }

        internal void DoubleMaxMinValue()
        {
            double maxValue = double.MaxValue;
            double minValue = double.MinValue;
            Console.WriteLine($"double range is {minValue} to {maxValue}");

            double a = 1.0;
            double b = 3.0;
            Console.WriteLine(a/b);
  
        }

        internal void DecimalMaxMinValue()
        {
            decimal maxValue = decimal.MaxValue;
            decimal minValue = decimal.MinValue;
            Console.WriteLine($"decimal range is {minValue} to {maxValue}");

            decimal a = 1M;
            decimal b = 3M;
            Console.WriteLine(a / b);
        }

        internal void CircleArea(double radius)
        {
            //计算圆面积
            var area = Math.Pow(radius, 2) * Math.PI;
            Console.WriteLine(area);
        }
    }
}
