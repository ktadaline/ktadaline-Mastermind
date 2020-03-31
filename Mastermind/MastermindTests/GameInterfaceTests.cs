using Mastermind.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MastermindTests
{
    [TestClass]
    public class GameInterfaceTests
    {
        [DataTestMethod]
        [DataRow("1111", "1234", "+")]
        [DataRow("2323", "2323", "++++")]
        [DataRow("3377", "7733", "----")]
        [DataRow("1234", "4216", "+--")]
        [DataRow("6543", "4321", "--")]
        [DataRow("5555", "2222", "")]
        [DataRow("5123", "3232", "--")]
        public void CheckDigitAndPositionTests(string secretCode, string guess, string expectedResult)
        {
            string actualResult = GameInterface.CheckDigitAndPosition(secretCode, guess);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [DataTestMethod]
        [DataRow("0000", false)]
        [DataRow("1356", true)]
        [DataRow("234234", false)]
        [DataRow("12x4", false)]
        [DataRow("dfwh", false)]
        [DataRow("234", false)]
        public void IsValidInputTests(string input, bool expectedResult)
        {
            MastermindBoard board = new MastermindBoard();
            GameInterface GI = new GameInterface(board);
            bool actualResult = GI.IsValidInput(input);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [DataTestMethod]
        [DataRow("++++", true)]
        [DataRow("+++", false)]
        [DataRow("xxxx", false)]
        [DataRow("----", false)]
        [DataRow("+++++", false)]
        [DataRow("", false)]
        public void WinningGuessTests(string input, bool expectedResult)
        {
            bool actualResult = GameInterface.WinningGuess(input);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
