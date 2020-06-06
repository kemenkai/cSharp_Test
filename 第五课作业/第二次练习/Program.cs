using System;

namespace 第二次练习
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new Calculator();
            int sum = c.Add(3, 5);
            Console.WriteLine("sum = {0}",sum);

            string day = c.Today();
            Console.WriteLine("Today = {0}",day);

            c.PrintSum(100, 200);

            c.PrintXTo1(10);

            c.PrintXTo1_2(10);

            c.SumForm1Tox(100);

            int sum2 = c.SumForm1ToX_2(50);
            Console.WriteLine("SumForm1ToX_2 --> {0}",sum2);
        }
    }

    class Calculator {
        public int Add(int x, int y) {
            int result = x + y;
            return result;
        }

        public string Today() {
            DateTime day = DateTime.Now.Date;
            return day.ToString();
        }

        public void PrintSum(int x, int y) {
            int result = x + y;
            Console.WriteLine("PrintSum = {0}",result);
        }

        public void PrintXTo1(int x) {
            for (int i = x; i > 0; i--) {
                Console.WriteLine("PrintXTo1 --> {0}",i);
            }
        }

        public void PrintXTo1_2(int x) {
            if (x == 1)
            {
                Console.WriteLine("PrintXTo1_2 --> {0}", x);
            }
            else {
                Console.WriteLine("PrintXTo1_2 --> {0}", x);
                PrintXTo1_2(x-1);
            }
        }

        public void SumForm1Tox(int x) {
            int result = 0;
            for (int i = 0; i < x + 1; i++) {
                result = i + result;
            }
            Console.WriteLine("SumForm1Tox --> {0}", result);
        }

        public int SumForm1ToX_2(int x) {
            int result = 0;

            if (x == 1)
            {
                return x;
            }
            else 
            {
                result = x + SumForm1ToX_2(x - 1);
                return result;
            }
        }

        public int SumFrom1ToX_3(int x) {
            return (1 + x) * x / 2;
        }
    }
}
