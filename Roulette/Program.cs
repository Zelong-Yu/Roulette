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
            Roulette.Domain.bet a = new Roulette.Domain.bet();
            foreach (var item in a.colors)
            {
                Console.WriteLine(item);
            }
        }
    }
}
