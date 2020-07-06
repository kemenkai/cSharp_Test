using System;
using System.ComponentModel;

namespace CSharpFun
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Calculator ca = new Calculator();
            Console.WriteLine(Calculator.GetConeVolume(10,20));
        }
    }

    class Calculator {
        public static double GetCircleArea(double r) {
            return Math.PI * r * r;
        }

        public static double GetCylinderVolume(double r, double h)
        {
            return GetCircleArea(r) * h;
        }

        public static double GetConeVolume(double r, double h)
        {
            return GetCylinderVolume(r,h) / 3;
        }
    }
}
