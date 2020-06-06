using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace 第五课作业
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator c = new Calculator();
            int x = c.Add(1, 2);
            string day = c.Today();
            Console.WriteLine(x);
            Console.WriteLine(day);
            c.PrintSum(50, 70);
            c.PrintXTo1(10);
            c.PrintXTo1_2(10);
            int sum1 = c.SumForm1ToX(100);
            int sum2 = c.SumForm1ToX_2(100);
            int sum3 = c.SumForm1ToX_3(100);
            Console.WriteLine("SumFrom1ToX_1 --> {0}",sum1);
            Console.WriteLine("SumFrom1ToX_2 --> {0}",sum2);
            Console.WriteLine("SumFrom1ToX_3 --> {0}", sum3);
        }
    }

    class Calculator
    {
        public int Add(int a, int b) {
            int result = a + b;
            return result;
        }

        public string Today() {
            DateTime day = DateTime.Now.Date;
            return day.ToString();
        }

        public void PrintSum(int a, int b) {
            int result = a + b;
            Console.WriteLine(result);
        }
        public void PrintXTo1(int x)
        {
            for (int i = x; i > 0; i--) {
                Console.WriteLine("PrintXTo1 --> {0}",i);
            }
        }

        public void PrintXTo1_2(int x)
        {
            if (x == 0)
            {
                // Console.WriteLine(x);
            }
            else
            {
                Console.WriteLine("PrintXTo1_2 --> {0}", x);
                PrintXTo1_2(x - 1);
            }
        }

        public int SumForm1ToX(int x)
        {
            int result = 0;
            for (int i = 1; i < x + 1; i++)
            {
                result = result + i;
            }
            return result;
        }

        public int SumForm1ToX_2(int x) {
            int result = 0;
            if (x == 1)
            {
                return 1;
            }
            else {
                result = x + SumForm1ToX_2(x - 1);
                return result;
            }
        }
        public int SumForm1ToX_3(int x) {
            return (1 + x) * x / 2;

        }
    }
}
