using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropetySample
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            AdventureWorksDW2017Entities proxy = new AdventureWorksDW2017Entities();
            foreach (var sql in proxy.ProspectiveBuyer)
            { 
                if (sum >= 200)
                {
                    continue;
                }
                Console.WriteLine(sql.Phone);
                sum++;
                Console.WriteLine(sum);
                
            }
            Console.WriteLine("==========================================");
            Console.WriteLine(proxy.ProspectiveBuyer.Count());
        }
    }
}
