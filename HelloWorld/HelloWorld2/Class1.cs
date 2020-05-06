using System;

namespace Tools
{
    public class Hello1
    {
        public static string hello2()
        {
            return "hello2";
        }
        public static string hello3()
        {
            return "hello3";
        }

        public static double Add(double a, double b)
        { 
            return a + b;
        }

        public static double Sub(double a, double b)
        {
            return a - b;
        }

        public static double Mul(double a, double b)
        {
            return a * b;
        }

        public static double Div(double a, double b)
        {
            if (b == 0)
            {
                return double.PositiveInfinity;
            }
            else
            {
                return a / b;
            }
        }
    }
}
