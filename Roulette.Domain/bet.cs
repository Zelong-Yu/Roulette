using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Domain
{
    public class bet
    {
        //Array to model numbers on wheel. 0 represents 0 and 37 represents 00
        protected int[] numbers = Enumerable.Range(0, 38).ToArray();
        //Array to model colors on wheel. 0 and 37(00) are green.
        public string[] colors = new string[] 
        {
            "green", //0
            "red",   //1
            "black", //2
            "red",   //3
            "black", //4
            "red",   //5
            "black", //6
            "red",   //7
            "black", //8
            "red",   //9
            "black", //10
            "black", //11
        };
    }
}
