using Roulette.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette
{
    public class App
    {
        Bet a = new Bet();
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
                int selected = UI.SelectionMenu(Mainmenu,title: "$Welcome to Roulette$  Options(Q to quit): ");
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
                default:
                    return false;
            }
        }

        private void EnterBinNumber()
        {
            throw new NotImplementedException();
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