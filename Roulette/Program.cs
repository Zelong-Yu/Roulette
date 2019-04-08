using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roulette.Domain;

namespace Roulette
{
    class Program
    {
        static void Main(string[] args)
        {
            Bet a = new Bet();
            int i = 0;
            foreach (var item in a.Colors)
            {
                Console.WriteLine($"{i++} {item}");
            }
            string[] b = new string[] { "2134r", "wafa" };
            Console.WriteLine(b);

        }
    }
}
