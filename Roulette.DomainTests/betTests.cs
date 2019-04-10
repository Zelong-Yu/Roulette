using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            Assert.IsNotNull(oot.CurrentNumber); //CurrentBetNumber is not null

            //CurrentBetNumber should be within Available numbers
            Assert.IsTrue(oot.Numbers.Any(x => x == oot.CurrentNumber));

            //NextBet should (mostly) not equals to current bet
            Assert.AreNotEqual(oot.CurrentNumber, oot.NextBet());

            //NextBet should (mostly) not equals to current bet
            Assert.AreNotEqual(oot.CurrentNumber, oot.NextBet());

            //NextBet should (mostly) not equals to current bet
            Assert.AreNotEqual(oot.CurrentNumber, oot.NextBet());
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
            Assert.AreEqual("0", Bet.NumberBet("0"));
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

        [TestMethod()]
        public void ColumnsBetTest()
        {
            Assert.AreEqual("0/00 don't win Columns bet", Bet.ColumnsBet("00  "));
            Assert.AreEqual("0/00 don't win Columns bet", Bet.ColumnsBet("00"));
            Assert.AreEqual("0/00 don't win Columns bet", Bet.ColumnsBet("0"));
            Assert.AreEqual("0/00 don't win Columns bet", Bet.ColumnsBet("    37"));
            Assert.AreEqual("3rd Column", Bet.ColumnsBet("    9 "));
            Assert.AreEqual("2nd Column", Bet.ColumnsBet("35   "));
            Assert.AreEqual("3rd Column", Bet.ColumnsBet("    12 "));
            Assert.AreEqual("1st Column", Bet.ColumnsBet("13          "));
            Assert.AreEqual("2nd Column", Bet.ColumnsBet("26"));
            Assert.AreEqual("1st Column", Bet.ColumnsBet("1"));
            Assert.AreEqual("3rd Column", Bet.ColumnsBet("18"));
            Assert.AreEqual("1st Column", Bet.ColumnsBet("25"));
            Assert.AreEqual("3rd Column", Bet.ColumnsBet("36"));
            Assert.AreEqual("-1", Bet.ColumnsBet("0  0  "));
            Assert.AreEqual("-1", Bet.ColumnsBet("  39  "));
            Assert.AreEqual("-1", Bet.ColumnsBet("-2"));
            Assert.AreEqual("-1", Bet.ColumnsBet("asdjuag"));
            Assert.AreEqual("-1", Bet.ColumnsBet(""));
            Assert.AreEqual("-1", Bet.ColumnsBet("392139487654367"));
        }

        [TestMethod()]
        public void StreetBetTest()
        {
            Assert.AreEqual("0/00 don't win Street bet", Bet.StreetBet("00  "));
            Assert.AreEqual("0/00 don't win Street bet", Bet.StreetBet("00"));
            Assert.AreEqual("0/00 don't win Street bet", Bet.StreetBet("0"));
            Assert.AreEqual("0/00 don't win Street bet", Bet.StreetBet("    37"));
            Assert.AreEqual("7/8/9", Bet.StreetBet("    9 "));
            Assert.AreEqual("34/35/36", Bet.StreetBet("35   "));
            Assert.AreEqual("10/11/12", Bet.StreetBet("    12 "));
            Assert.AreEqual("13/14/15", Bet.StreetBet("13          "));
            Assert.AreEqual("25/26/27", Bet.StreetBet("26"));
            Assert.AreEqual("1/2/3", Bet.StreetBet("1"));
            Assert.AreEqual("16/17/18", Bet.StreetBet("18"));
            Assert.AreEqual("25/26/27", Bet.StreetBet("25"));
            Assert.AreEqual("34/35/36", Bet.StreetBet("36"));
            Assert.AreEqual("-1", Bet.StreetBet("0  0  "));
            Assert.AreEqual("-1", Bet.StreetBet("  39  "));
            Assert.AreEqual("-1", Bet.StreetBet("-2"));
            Assert.AreEqual("-1", Bet.StreetBet("asdjuag"));
            Assert.AreEqual("-1", Bet.StreetBet(""));
            Assert.AreEqual("-1", Bet.StreetBet("392139487654367"));
        }

        [TestMethod()]
        public void SixNumbersBetTest()
        {
            Assert.AreEqual("0/00 don't win 6Numbers bet", Bet.SixNumbersBet("00  "));
            Assert.AreEqual("0/00 don't win 6Numbers bet", Bet.SixNumbersBet("00"));
            Assert.AreEqual("0/00 don't win 6Numbers bet", Bet.SixNumbersBet("0"));
            Assert.AreEqual("0/00 don't win 6Numbers bet", Bet.SixNumbersBet("    37"));
            Assert.AreEqual("4/5/6/7/8/9\n7/8/9/10/11/12\n", Bet.SixNumbersBet("    9 "));
            Assert.AreEqual("31/32/33/34/35/36\n", Bet.SixNumbersBet("35   "));
            Assert.AreEqual("7/8/9/10/11/12\n10/11/12/13/14/15\n", Bet.SixNumbersBet("    12 "));
            Assert.AreEqual("10/11/12/13/14/15\n13/14/15/16/17/18\n", Bet.SixNumbersBet("13          "));
            Assert.AreEqual("22/23/24/25/26/27\n25/26/27/28/29/30\n", Bet.SixNumbersBet("26"));
            Assert.AreEqual("1/2/3/4/5/6\n", Bet.SixNumbersBet("1"));
            Assert.AreEqual("13/14/15/16/17/18\n16/17/18/19/20/21\n", Bet.SixNumbersBet("18"));
            Assert.AreEqual("22/23/24/25/26/27\n25/26/27/28/29/30\n", Bet.SixNumbersBet("25"));
            Assert.AreEqual("31/32/33/34/35/36\n", Bet.SixNumbersBet("36"));
            Assert.AreEqual("-1", Bet.SixNumbersBet("0  0  "));
            Assert.AreEqual("-1", Bet.SixNumbersBet("  39  "));
            Assert.AreEqual("-1", Bet.SixNumbersBet("-2"));
            Assert.AreEqual("-1", Bet.SixNumbersBet("asdjuag"));
            Assert.AreEqual("-1", Bet.SixNumbersBet(""));
            Assert.AreEqual("-1", Bet.SixNumbersBet("392139487654367"));
        }

        [TestMethod()]
        public void SplitBetTest()
        {
            //Test 0/00 cases
            Assert.AreEqual("0/00 don't win Split bet", Bet.SplitBet("00  "));
            Assert.AreEqual("0/00 don't win Split bet", Bet.SplitBet("00"));
            Assert.AreEqual("0/00 don't win Split bet", Bet.SplitBet("0"));
            Assert.AreEqual("0/00 don't win Split bet", Bet.SplitBet("   0"));
            Assert.AreEqual("0/00 don't win Split bet", Bet.SplitBet("0  "));
            Assert.AreEqual("0/00 don't win Split bet", Bet.SplitBet("    37"));

            //Test invalid input
            Assert.AreEqual("-1", Bet.SplitBet("0  0  "));
            Assert.AreEqual("-1", Bet.SplitBet("  39  "));
            Assert.AreEqual("-1", Bet.SplitBet("-2"));
            Assert.AreEqual("-1", Bet.SplitBet("asdjuag"));
            Assert.AreEqual("-1", Bet.SplitBet(""));
            Assert.AreEqual("-1", Bet.SplitBet("392139487654367"));

            //Test Corner cases
            Assert.AreEqual("1/2\n1/4\n", Bet.SplitBet("1"));
            Assert.AreEqual("2/3\n3/6\n", Bet.SplitBet("3   "));
            Assert.AreEqual("31/34\n34/35\n", Bet.SplitBet("  34   "));
            Assert.AreEqual("33/36\n35/36\n", Bet.SplitBet(" 36 "));

            //Test Edge Cases
            Assert.AreEqual("1/2\n2/3\n2/5\n", Bet.SplitBet("2"));
            Assert.AreEqual("32/35\n34/35\n35/36\n", Bet.SplitBet(" 35"));
            Assert.AreEqual("10/13\n13/14\n13/16\n", Bet.SplitBet("13 "));
            Assert.AreEqual("24/27\n26/27\n27/30\n", Bet.SplitBet("27"));

            //Test Center Cases
            Assert.AreEqual("23/26\n25/26\n26/27\n26/29\n", Bet.SplitBet("  26"));
        }

        [TestMethod()]
        public void CornerBetTest()
        {
            //Test 0/00 cases
            Assert.AreEqual("0/00 don't win Corner bet", Bet.CornerBet("00  "));
            Assert.AreEqual("0/00 don't win Corner bet", Bet.CornerBet("00"));
            Assert.AreEqual("0/00 don't win Corner bet", Bet.CornerBet("0"));
            Assert.AreEqual("0/00 don't win Corner bet", Bet.CornerBet("   0"));
            Assert.AreEqual("0/00 don't win Corner bet", Bet.CornerBet("0  "));
            Assert.AreEqual("0/00 don't win Corner bet", Bet.CornerBet("    37"));

            //Test invalid input
            Assert.AreEqual("-1", Bet.CornerBet("0  0  "));
            Assert.AreEqual("-1", Bet.CornerBet("  39  "));
            Assert.AreEqual("-1", Bet.CornerBet("-2"));
            Assert.AreEqual("-1", Bet.CornerBet("asdjuag"));
            Assert.AreEqual("-1", Bet.CornerBet(""));
            Assert.AreEqual("-1", Bet.CornerBet("392139487654367"));

            //Test Corner cases
            Assert.AreEqual("1/2/4/5\n", Bet.CornerBet("1"));
            Assert.AreEqual("2/3/5/6\n", Bet.CornerBet("3   "));
            Assert.AreEqual("31/32/34/35\n", Bet.CornerBet("  34   "));
            Assert.AreEqual("32/33/35/36\n", Bet.CornerBet(" 36 "));

            //Test Edge Cases
            Assert.AreEqual("1/2/4/5\n2/3/5/6\n", Bet.CornerBet("2"));
            Assert.AreEqual("31/32/34/35\n32/33/35/36\n", Bet.CornerBet(" 35"));
            Assert.AreEqual("10/11/13/14\n13/14/16/17\n", Bet.CornerBet("13 "));
            Assert.AreEqual("23/24/26/27\n26/27/29/30\n", Bet.CornerBet("27"));

            //Test Center Cases
            Assert.AreEqual("22/23/25/26\n23/24/26/27\n25/26/28/29\n26/27/29/30\n", Bet.CornerBet("  26"));
        }
    }
}