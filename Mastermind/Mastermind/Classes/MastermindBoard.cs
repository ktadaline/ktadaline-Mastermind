using System;
using System.Collections.Generic;
using System.Text;

namespace Mastermind.Classes
{
    public class MastermindBoard
    {
        public int DigitMax { get; } = 6;
        //The max value of each digit in the code. Must be greater or equal to 0 and less than 10.
        
        public int DigitMin { get; } = 1;
        //The min value of each digit in the code. Must be greater or equal to 0 and less than 10.

        public int CodeLength { get; } = 4;
        //The length of digits in the code. Must be greater than 0. 

        public int NumberOfGuesses { get; } = 10;
        //The number of guesses per game. Must be greater than or equal to 1.


        private Random random { get; }
        public MastermindBoard() 
        {
            this.random = new Random();
        }
        /// <summary>
        /// Generate the solution, which is a string made up of a 4 digit random number
        /// Each char represents a number between 1-6
        /// </summary>
        public string GenerateSecretCode()
        {
            string FourRandomNumbersString = "";
            for (int i = 0; i < CodeLength; i++)
            {
                string randomNumber = random.Next(DigitMin, DigitMax + 1).ToString();
                FourRandomNumbersString += randomNumber;
            }
            return FourRandomNumbersString;
        }
    }
}
