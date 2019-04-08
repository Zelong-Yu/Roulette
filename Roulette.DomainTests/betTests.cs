﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roulette.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Domain.Tests
{
    [TestClass()]
    public class BetTests
    {
        //new bet instance for testing
        Bet oot = new Bet();
        [TestMethod()]
        public void BetPropertiesTest()
        {
            Assert.AreEqual(38, oot.Numbers.Length); //there should be 38 numbers

            Assert.AreEqual(18, oot.Colors.Count(c => c == "red")); //there should be 18 red

            Assert.AreEqual(18, oot.Colors.Count(c => c == "black")); //there should be 18 black

            Assert.AreEqual(2, oot.Colors.Count(c => c == "green")); //there should be 2 green

            Assert.AreEqual("red", oot.Colors[34]); //34 should be red

            Assert.AreEqual("green", oot.Colors[0]);//0 should be green

            Assert.AreEqual("green", oot.Colors[37]); //00/37 should be green
        }

        [TestMethod()]
        public void BetConstructorTest()
        {
            Assert.IsNotNull(oot.CurrentBetNumber); //CurrentBetNumber is not null

            //CurrentBetNumber should be within Available numbers
            Assert.IsTrue(oot.Numbers.Any(x => x == oot.CurrentBetNumber));

            //NextBet should (mostly) not equals to current bet
            Assert.AreNotEqual(oot.CurrentBetNumber, oot.NextBet());

            //NextBet should (mostly) not equals to current bet
            Assert.AreNotEqual(oot.CurrentBetNumber, oot.NextBet());

            //NextBet should (mostly) not equals to current bet
            Assert.AreNotEqual(oot.CurrentBetNumber, oot.NextBet());
        }

        [TestMethod()]
        public void ValidateBetTest()
        {
            //Validate bet 19
            Assert.IsTrue(Bet.ValidateBet(19));

            //Validate bet 0
            Assert.IsTrue(Bet.ValidateBet(0));

            //Validate bet 37
            Assert.IsTrue(Bet.ValidateBet(37));

            //Validate bet -5
            Assert.IsFalse(Bet.ValidateBet(-5));

            //Validate bet 100
            Assert.IsFalse(Bet.ValidateBet(100));

        }

        [TestMethod()]
        public void NumberBetTest()
        {
            Assert.AreEqual(13, Bet.NumberBet(13));
            Assert.AreEqual(0, Bet.NumberBet(0));
            Assert.AreEqual(37, Bet.NumberBet(37));
            Assert.AreEqual(-1, Bet.NumberBet(-255));

            //validate the overloaded method that takes a string
            Assert.AreEqual("00", Bet.NumberBet("00  "));
            Assert.AreEqual("00", Bet.NumberBet("00"));
            Assert.AreEqual("-1", Bet.NumberBet("0  0  "));
            Assert.AreEqual("00", Bet.NumberBet("    37"));
            Assert.AreEqual("9", Bet.NumberBet("    9 "));
            Assert.AreEqual("-1", Bet.NumberBet("  39  "));
            Assert.AreEqual("-1", Bet.NumberBet("asdjuag"));
            Assert.AreEqual("-1", Bet.NumberBet(""));
            Assert.AreEqual("-1", Bet.NumberBet("392139487654367"));
        }

        [TestMethod()]
        public void EvenOddBetTest()
        {
            Assert.AreEqual("0/00 don't win Even/Odd bet", Bet.EvenOddBet("00  "));
            Assert.AreEqual("0/00 don't win Even/Odd bet", Bet.EvenOddBet("00"));
            Assert.AreEqual("0/00 don't win Even/Odd bet", Bet.EvenOddBet("0"));
            Assert.AreEqual("-1", Bet.EvenOddBet("0  0  "));
            Assert.AreEqual("0/00 don't win Even/Odd bet", Bet.EvenOddBet("    37"));
            Assert.AreEqual("Odd", Bet.EvenOddBet("    9 "));
            Assert.AreEqual("Odd", Bet.EvenOddBet("35   "));
            Assert.AreEqual("Even", Bet.EvenOddBet("    12 "));
            Assert.AreEqual("Even", Bet.EvenOddBet("26"));
            Assert.AreEqual("-1", Bet.EvenOddBet("  39  "));
            Assert.AreEqual("-1", Bet.EvenOddBet("asdjuag"));
            Assert.AreEqual("-1", Bet.EvenOddBet(""));
            Assert.AreEqual("-1", Bet.EvenOddBet("392139487654367"));
        }

        [TestMethod()]
        public void RedBlackBetTest()
        {
            Assert.AreEqual("0/00 don't win Red/Black bet", Bet.RedBlackBet("00  "));
            Assert.AreEqual("0/00 don't win Red/Black bet", Bet.RedBlackBet("00"));
            Assert.AreEqual("0/00 don't win Red/Black bet", Bet.RedBlackBet("0"));
            Assert.AreEqual("-1", Bet.RedBlackBet("0  0  "));
            Assert.AreEqual("0/00 don't win Red/Black bet", Bet.RedBlackBet("    37"));
            Assert.AreEqual("red", Bet.RedBlackBet("    9 "));
            Assert.AreEqual("black", Bet.RedBlackBet("35   "));
            Assert.AreEqual("red", Bet.RedBlackBet("    12 "));
            Assert.AreEqual("black", Bet.RedBlackBet("26"));
            Assert.AreEqual("red", Bet.RedBlackBet("1"));
            Assert.AreEqual("-1", Bet.RedBlackBet("  39  "));
            Assert.AreEqual("-1", Bet.RedBlackBet("-2"));
            Assert.AreEqual("-1", Bet.RedBlackBet("asdjuag"));
            Assert.AreEqual("-1", Bet.RedBlackBet(""));
            Assert.AreEqual("-1", Bet.RedBlackBet("392139487654367"));
        }

        [TestMethod()]
        public void LowHighBetTest()
        {
            Assert.AreEqual("0/00 don't win Low/High bet", Bet.LowHighBet("00  "));
            Assert.AreEqual("0/00 don't win Low/High bet", Bet.LowHighBet("00"));
            Assert.AreEqual("0/00 don't win Low/High bet", Bet.LowHighBet("0"));
            Assert.AreEqual("-1", Bet.LowHighBet("0  0  "));
            Assert.AreEqual("0/00 don't win Low/High bet", Bet.LowHighBet("    37"));
            Assert.AreEqual("Low", Bet.LowHighBet("    9 "));
            Assert.AreEqual("High", Bet.LowHighBet("35   "));
            Assert.AreEqual("Low", Bet.LowHighBet("    12 "));
            Assert.AreEqual("High", Bet.LowHighBet("26"));
            Assert.AreEqual("Low", Bet.LowHighBet("1"));
            Assert.AreEqual("Low", Bet.LowHighBet("18"));
            Assert.AreEqual("High", Bet.LowHighBet("19"));
            Assert.AreEqual("-1", Bet.LowHighBet("  39  "));
            Assert.AreEqual("-1", Bet.LowHighBet("-2"));
            Assert.AreEqual("-1", Bet.LowHighBet("asdjuag"));
            Assert.AreEqual("-1", Bet.LowHighBet(""));
            Assert.AreEqual("-1", Bet.LowHighBet("392139487654367"));
        }

        [TestMethod()]
        public void DozensBetTest()
        {
            Assert.AreEqual("0/00 don't win Dozens bet", Bet.DozensBet("00  "));
            Assert.AreEqual("0/00 don't win Dozens bet", Bet.DozensBet("00"));
            Assert.AreEqual("0/00 don't win Dozens bet", Bet.DozensBet("0"));
            Assert.AreEqual("0/00 don't win Dozens bet", Bet.DozensBet("    37"));
            Assert.AreEqual("-1", Bet.DozensBet("0  0  "));   
            Assert.AreEqual("1st Dozen", Bet.DozensBet("    9 "));
            Assert.AreEqual("3rd Dozen", Bet.DozensBet("35   "));
            Assert.AreEqual("1st Dozen", Bet.DozensBet("    12 "));
            Assert.AreEqual("2nd Dozen", Bet.DozensBet("13          "));
            Assert.AreEqual("3rd Dozen", Bet.DozensBet("26"));
            Assert.AreEqual("1st Dozen", Bet.DozensBet("1"));
            Assert.AreEqual("2nd Dozen", Bet.DozensBet("18"));
            Assert.AreEqual("3rd Dozen", Bet.DozensBet("25"));
            Assert.AreEqual("3rd Dozen", Bet.DozensBet("36"));
            Assert.AreEqual("-1", Bet.DozensBet("  39  "));
            Assert.AreEqual("-1", Bet.DozensBet("-2"));
            Assert.AreEqual("-1", Bet.DozensBet("asdjuag"));
            Assert.AreEqual("-1", Bet.DozensBet(""));
            Assert.AreEqual("-1", Bet.DozensBet("392139487654367"));
        }
    }
}