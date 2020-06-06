using System;
using System.Runtime.InteropServices;
using System.Threading.Channels;

namespace Hanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            Hanoi_1 move = new Hanoi_1();
            move.Hanoi_move(4,"A","B","C");
        }
    }

    class Hanoi_1 {
        public void Hanoi_move(int n, string a, string b, string c) {
            if (n == 1)
            {
                Console.WriteLine("{0} --> {1}", a, c);
            }
            else 
            {
                Hanoi_move(n - 1, a, c, b);
                Console.WriteLine("{0} --> {1}", a, c);
                Hanoi_move(n - 1, b, a, c);
            }
        }
    }
}
