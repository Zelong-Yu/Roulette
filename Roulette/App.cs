using Roulette.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette
{
    public class App
    {
        Bet a = new Bet();
        delegate string GetWinningBet(string text);
        
        public App()
        {
            Console.OutputEncoding = Encoding.Unicode;
        }

        public void Run()
        {
            bool end=false;
            List<string> Mainmenu = new List<string>();
            Mainmenu.Add("1. Print The Roulette Wheel in original wheel order and ascending order");
            Mainmenu.Add("2. Enter a bin number, check all the winning bets");
            Mainmenu.Add("3. Spin the Roulette wheel, check all the winning bets");
            do
            {
                Console.Clear();
                int selected = UI.SelectionMenu(Mainmenu,title: "$Welcome to Roulette$  Options (Q to quit): ");
                end = HandleSelection(selected);
            } while (!end);
        }

        private bool HandleSelection(int selected)
        {
            switch (selected)
            {
                case -1:
                    return true;
                case 0:
                    PrintWheel();
                    return false;
                case 1:
                    EnterBinNumber();
                    return false;
                case 2:
                    SpinWheel();
                    return false;
                default:
                    return false;
            }
        }

        private void SpinWheel()
        {
            bool end = false;
            do
            {
                Console.Clear();
                if (UI.PromptForInputInline("Hit Q to quit. Hit any other key spin the Roulette Wheel >\n") == ConsoleKey.Q) break;
                PrintWinningBet(a.NextBet().ToString());
                if (UI.PromptForInputInline("\nHit Q to quit. Hit any other key to continue. >") == ConsoleKey.Q) end = true;
            } while (!end);
        }

        private void EnterBinNumber()
        {
            bool end = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Enter Bin Number (Use 00 or 37 for 00): (Enter Q to quit) ");
                string bin = Console.ReadLine();
                if (bin == "Q" || bin == "q") break;
                PrintWinningBet(bin);
                if(UI.PromptForInputInline("\nHit Q to quit. Hit any other key to continue. >")==ConsoleKey.Q) end=true;
            } while (!end);
        }

        private void PrintWinningBet(string bin)
        {
            bin = bin.Trim();
            if (bin=="00" || bin == "37") bin="00";
            if (bin.Contains("-0")) bin = "0";
            else
            {
                bool isValid = int.TryParse(bin, out int binNum);
                if (!isValid || !Bet.ValidateBet(binNum)) { Console.WriteLine("Invalid Input."); return; }
                if (binNum == 0) bin = "0";  //get rid of the bug that input is 0000
            }
            Console.WriteLine($"The ball falls into {bin}.");
            Console.WriteLine("=================================================");
            Console.WriteLine($"Numbers Bet Winning Bet:   {Bet.NumberBet(bin)}");
            Console.WriteLine("=================================================");
            Console.WriteLine($"Evens/Odds Bet Winning Bet:{Bet.EvenOddBet(bin)}");
            Console.WriteLine("=================================================");
            Console.WriteLine($"Lows/Highs Bet Winning Bet:{Bet.LowHighBet(bin)}");
            Console.WriteLine("=================================================");
            Console.WriteLine($"Dozens Bet Winning Bet:    {Bet.DozensBet(bin)}");
            Console.WriteLine("=================================================");
            Console.WriteLine($"Columns Bet Winning Bet:   {Bet.ColumnsBet(bin)}");
            Console.WriteLine("=================================================");
            Console.WriteLine($"Street Bet Winning Bet:    {Bet.StreetBet(bin)}");
            Console.WriteLine("=================================================");
            Console.WriteLine($"6 Numbers Bet Winning Bet: \n{Bet.SixNumbersBet(bin)}");
            Console.WriteLine("=================================================");
            Console.WriteLine($"Split Bet Winning Bet:     \n{Bet.SplitBet(bin)}");
            Console.WriteLine("=================================================");
            Console.WriteLine($"Corners Bet Winning Bet:   \n{Bet.CornerBet(bin)}");
            Console.WriteLine("=================================================");
        }

        private void PrintWheel()
        {
            Console.Clear();
            Console.WriteLine(" The Roulette Wheel bin numbers in Original Wheel Order, Start from 0 Counter-clockwise. 00 is denoted by 37.\n");
            foreach (var item in Bet.numbersWheel)
            {
                Console.ForegroundColor = ConsoleColor.White;
                if (a.Colors[item] == "red") Console.BackgroundColor = ConsoleColor.DarkRed;
                else if (a.Colors[item] == "green") Console.BackgroundColor = ConsoleColor.DarkGreen;
                else if (a.Colors[item] == "black") Console.BackgroundColor = ConsoleColor.Black;
                Console.Write($"{item}:{a.Colors[item]} ");
                Console.ResetColor();
            }
            UI.PromptForInputInline("\n\nPress any key to see The Roulette Wheel in Ascending order >\n\n");
            
            Console.WriteLine("The Roulette Wheel in Ascending order. 00 is denoted by 37.\n");
            foreach (var item in a.Numbers)
            {
                Console.ForegroundColor = ConsoleColor.White;
                if (a.Colors[item] == "red") Console.BackgroundColor = ConsoleColor.DarkRed;
                else if (a.Colors[item] == "green") Console.BackgroundColor = ConsoleColor.DarkGreen;
                else if (a.Colors[item] == "black") Console.BackgroundColor = ConsoleColor.Black;
                Console.Write($"{item}:{a.Colors[item]} ");
                Console.ResetColor();
            }
            UI.PromptForInputInline("\nPress any key to go back to main menu.");
        }
    }
}