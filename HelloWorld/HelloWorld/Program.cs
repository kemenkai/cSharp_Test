using System;
using System.Reflection.Metadata;
using Tools;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            double hello1 = Hello1.Sub(1.1,1.4);
            Console.WriteLine(hello1);
        }
    }
}
