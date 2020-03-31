using Mastermind.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MastermindTests
{
    [TestClass]
    public class MastermindBoardTests
    {
        [TestMethod]
        public void GenerateSecretCodeLengthTest()
        {
            MastermindBoard board = new MastermindBoard();

            string code = board.GenerateSecretCode();

            Assert.AreEqual(4, code.Length);
        }
        [TestMethod]
        public void GeneratesSecretCodeBetween1And6()
        {
            MastermindBoard board = new MastermindBoard();

            string code = board.GenerateSecretCode();

            bool isBetween1and6 = (Int32.Parse(code[0].ToString()) >= 1 && Int32.Parse(code[0].ToString()) <= 6);

            Assert.IsTrue(isBetween1and6);
        }
    }
}
