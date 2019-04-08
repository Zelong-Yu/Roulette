using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Domain
{
    public class Bet
    {
        //Array to model numbers on wheel. 0 represents 0 and 37 represents 00
        public static readonly int[] numbers = Enumerable.Range(0, 38).ToArray();
        //Array to model colors on wheel. 0 and 37(00) are green.
        public static readonly string[] colors = new string[]
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
            "red",   //12
            "black", //13
            "red",   //14
            "black", //15
            "red",   //16
            "black", //17
            "red",   //18
            "red",   //19
            "black", //20
            "red",   //21
            "black", //22
            "red",   //23
            "black", //24
            "red",   //25
            "black", //26
            "red",   //27
            "black", //28
            "black", //29
            "red",   //30
            "black", //31
            "red",   //32
            "black", //33
            "red",   //34
            "black", //35
            "red",   //36
            "green"  //00
        };

        private int currentBetNumber;

        private Random rnd = new Random();

        ///<summary>
        ///Check what numbers are on the Roulette
        /// </summary>
        /// <returns>
        /// An array with numbers on the Roulette(00 is represented by 37)
        /// </returns>
        public int[] Numbers { get => numbers;}

        ///<summary>
        ///Check what colors are on the Roulette. Colors[i] returns color of number [i]
        /// </summary>
        /// <returns>
        /// An array with colors on the Roulette(00 is represented in index 37)
        /// </returns>
        public string[] Colors { get => colors; }
        public int CurrentBetNumber { get => currentBetNumber; protected set => currentBetNumber = value; }

        ///<summary>
        ///Generate a bet
        ///</summary>
        public Bet()
        {
            this.CurrentBetNumber = rnd.Next(0, 37);
        }

        /// <summary>
        /// Take Next Bet
        /// </summary>
        /// <returns>
        /// An integer representing next bet. (00 is represented by 37)
        /// </returns>
        public int NextBet()
        {
            this.CurrentBetNumber = rnd.Next(0, 37);
            return this.CurrentBetNumber;
        }

        /// <summary>
        /// Validate an integer to check if it is an valid bet. (00 is represented by 37)
        /// </summary>
        /// <param name="betToValidate">Int to be validated as valid bet number</param>
        /// <returns>
        /// true if valid, false if not
        /// </returns>
        public static bool ValidateBet(int betToValidate)
        {
            //Validate if an interger is valid bid
            return numbers.Any(x=>x==betToValidate);
        }

        /// <summary>
        /// Check the winning bet of a Numbers Bet. Odds against winning 37 to 1.
        /// overloaded method to check int input. (00 is represented by 37 when input)
        /// </summary>
        /// <param name="bet">Bet in Number Bet</param>
        /// <returns>
        /// Winning bin as a number. -1 if input is not a valid bid. (00 is represented by 37)
        /// </returns>
        public static int NumberBet(int bet)
        {
            return ValidateBet(bet) ? bet : -1;
        }

        /// <summary>
        /// Check the winning bet of a Numbers Bet. Odds against winning . Use 00 or 37 to denote 00
        /// Overloaded method to check string input
        /// </summary>
        /// <param name="bet">Bet in Number Bet</param>
        /// <returns>
        /// Winning bin as a number. "-1" if input is not a valid bid. 
        /// </returns>
        public static string NumberBet(string bet)
        {
            bet=bet.Trim();
            if (bet=="00") return "00";
            if (bet=="37") return "00";
            bool isValid = int.TryParse(bet, out int parsedInt);
            if (!isValid) return "-1";
            return NumberBet(parsedInt).ToString();
        }
        /// <summary>
        /// Check the winning bet of an Even/Odd bet. Odds against winning 1 and 1/9 to 1. Use 00 or 37 to denote 00
        /// </summary>
        /// <param name="bet">Bet in Even/Odd Bet</param>
        /// <returns>
        /// Return "Even" if the bet wins even. Return "Odd" if the bet wins odd.
        /// Return "0/00 don't win Even/Odd bet" if bet is 0/00
        /// Return "-1" if input is not a valid bid. 
        /// </returns>
        public static string EvenOddBet(string bet)
        {
            bet = bet.Trim();
            if(bet == "00"|| bet == "0" || bet=="37") return "0/00 don't win Even/Odd bet";
            bool isValid = int.TryParse(bet, out int parsedInt);
            if (!isValid) return "-1";
            if (!ValidateBet(parsedInt)) return "-1";
            //return Even if the bet is valid and even. 
            return parsedInt % 2 == 0 ? "Even" : "Odd"; 
        }

        /// <summary>
        /// Check the winning bet of an Even/Odd bet. Odds against winning 1 and 1/9 to 1. Use 00 or 37 to denote 00
        /// </summary>
        /// <param name="bet">Bet in Red/Black Bet</param>
        /// <returns>
        /// Return "red" if the bet wins red. Return "black" if the bet wins black.
        /// Return "0/00 don't win Red/Black bet" if bet is 0/00
        /// Return "-1" if input is not a valid bid. 
        /// </returns>
        public static string RedBlackBet(string bet)
        {
            bet = bet.Trim();
            if (bet == "00" || bet == "0" || bet == "37") return "0/00 don't win Red/Black bet";
            bool isValid = int.TryParse(bet, out int parsedInt);
            if (!isValid) return "-1";
            if (!ValidateBet(parsedInt)) return "-1";
            //return color of the bet
            return colors[parsedInt];
        }

        /// <summary>
        /// Check the winning bet of an Low/High bet. Odds against winning 1 and 1/9 to 1. Use 00 or 37 to denote 00
        /// </summary>
        /// <param name="bet">Bet in Low/High Bet</param>
        /// <returns>
        /// Return "low" if the bet wins low. Return "high" if the bet wins high.
        /// Return "0/00 don't win Low/High bet" if bet is 0/00
        /// Return "-1" if input is not a valid bid. 
        /// </returns>
        public static string LowHighBet(string bet)
        {
            bet = bet.Trim();
            if (bet == "00" || bet == "0" || bet == "37") return "0/00 don't win Low/High bet";
            bool isValid = int.TryParse(bet, out int parsedInt);
            if (!isValid) return "-1";
            if (!ValidateBet(parsedInt)) return "-1";
            //return low/high of the bet
            return parsedInt <= 18 ? "Low" : "High";
        }

        /// <summary>
        /// Check the winning bet of an Dozens bet. Odds against winning 2 and 1/6 to 1. Use 00 or 37 to denote 00
        /// </summary>
        /// <param name="bet">Bet in Dozens Bet</param>
        /// <returns>
        /// Return "1st Dozen" if the bet is between 1-12. 
        /// Return "2nd Dozen" if the bet is between 13-24. 
        /// Return "3rd Dozen" if the bet is between 25-36.
        /// Return "0/00 don't win Dozens bet" if bet is 0/00
        /// Return "-1" if input is not a valid bid. 
        /// </returns>
        public static string DozensBet(string bet)
        {
            bet = bet.Trim();
            if (bet == "00" || bet == "0" || bet == "37") return "0/00 don't win Dozens bet";
            bool isValid = int.TryParse(bet, out int parsedInt);
            if (!isValid) return "-1";
            if (!ValidateBet(parsedInt)) return "-1";
            //return which dozen does the wins
            if (parsedInt <= 12)
                return "1st Dozen";
            else if (parsedInt <= 24)
                return "2nd Dozen";
            else return "3rd Dozen";
        }
    }
}
