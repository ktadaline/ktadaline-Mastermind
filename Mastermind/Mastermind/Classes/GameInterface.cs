using System;
using System.Collections.Generic;
using System.Text;

namespace Mastermind.Classes
{
    public class GameInterface
    {
        public MastermindBoard board;

        public GameInterface(MastermindBoard mastermindBoard)
        {
            this.board = mastermindBoard;

        }

        /// <summary>
        /// Returns a string consisting of +'s and -'s
        /// Will return a + when the guessed digit's position and value matches the secret code's position and value
        /// Will return a - when the guessed digit's value matches the secret code's value but not the position
        /// </summary>
        /// <param name="secretCode"></param>
        /// <param name="guess"></param>
        /// <returns></returns>
        public static string CheckDigitAndPosition(string secretCode, string guess)
        {
            string returnedHint = "";
            List<int> usedIndicesInSecret = new List<int>();
            List<int> usedIndicesInGuess = new List<int>();
            //Check if digit and position are correct
            for (int i = 0; i < secretCode.Length; i++)
            {
                if (secretCode[i] == guess[i])
                {
                    returnedHint += "+";
                    usedIndicesInSecret.Add(i);
                    usedIndicesInGuess.Add(i);
                }
            }

            //checks if secretCode contains the guessed digit at any index
            for (int i = 0; i < secretCode.Length; i++)
            {
                if (usedIndicesInSecret.Contains(i))
                {
                    continue;
                }
                for (int j = 0; j < guess.Length; j++)
                {
                    if (usedIndicesInGuess.Contains(j))
                    {
                        continue;
                    }
                    if (secretCode[i] == guess[j])
                    {
                        returnedHint += "-";
                        usedIndicesInSecret.Add(i);
                        usedIndicesInGuess.Add(j);
                        break;
                    }
                }
            }
            return returnedHint;
        }
        /// <summary>
        /// Check if input is valid
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool IsValidInput(string input)
        {
            //Check if guess is correct length
            if (input.Length != board.CodeLength)
            {
                return false;
            }
            //Parse input
            int[] intInput = new int[board.CodeLength];
            for (int i = 0; i < input.Length; i++)
            {
                int number;
                bool isInt = Int32.TryParse(input[i].ToString(), out number);
                //check if number is valid int between 1 and 6
                if (isInt && number >= board.DigitMin && number <= board.DigitMax)
                {
                    intInput[i] = number;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Checks if the input is a WinningGuess
        /// </summary>
        /// <param name="returnedHints"></param>
        /// <returns></returns>
        public static bool WinningGuess(string returnedHints)
        {
            if (returnedHints == "++++")
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Prints game instructions
        /// </summary>
        public void PrintInstructions()
        {
            Console.WriteLine("\nHow to play:\n");
            Console.WriteLine($"Guess the code!\nThe code will be {board.CodeLength} digits long.\nEach number is between {board.DigitMin} and {board.DigitMax}.\nYou have {board.NumberOfGuesses} tries to guess the correct number.\n");
            Console.WriteLine("(+) indicates that both the digit and position are correct.\n(-) indicates that a digit is correct, but in the wrong position.\n");
            Console.WriteLine("Have fun and good luck!");
        }

        /// <summary>
        /// Runs a game
        /// </summary>
        public void Play()
        {
            bool gameWon = false;
            int numOfTries = board.NumberOfGuesses;
            bool selectionValid = true;
            string secretCode = board.GenerateSecretCode();
            Console.WriteLine("****\n");
            while (numOfTries > 0 && gameWon == false)
            {
                if (selectionValid == false)
                {
                    Console.WriteLine("Invalid input! Must be a four digit number and each digit should be between 1 and 6 \n");
                    selectionValid = true;
                }
                else if (numOfTries == board.NumberOfGuesses && selectionValid == true)
                {
                    Console.WriteLine("Enter a four digit code consisting of four numbers. Each digit should be between 1 and 6.");
                }
                else if (numOfTries == (board.NumberOfGuesses - 1))
                {
                    Console.WriteLine($"Keep guessing. You have {numOfTries.ToString()} tries remaining...\n");
                }
                else if (numOfTries == 1)
                {
                    Console.WriteLine("This is your final guess. Good luck!\n");
                }
                else
                {
                    Console.WriteLine($"{numOfTries.ToString()} tries remaining.\n");
                }
                Console.Write("Guess: ");
                string guess = Console.ReadLine();
                if (!IsValidInput(guess))
                {
                    selectionValid = false;
                    continue;
                }
                string hints = GameInterface.CheckDigitAndPosition(secretCode, guess);
                Console.WriteLine("\n" + hints);
                if (GameInterface.WinningGuess(hints))
                {
                    Console.WriteLine("Congratulations you won!!");
                    gameWon = true;

                }
                numOfTries--;
            }
            if (numOfTries < 1)
            {
                Console.WriteLine("Sorry, you lost. Better luck next time.");
            }
        }
    }
}