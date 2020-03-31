using System;
using System.Collections.Generic;
using Mastermind.Classes;

namespace Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepPlaying = true;
            while (keepPlaying)
            {
                Console.Clear();
                Console.WriteLine();
                PrintTitle();
                Console.WriteLine("1. Instructions");
                Console.WriteLine("2. Play Mastermind");
                Console.WriteLine("3. Quit");
                Console.Write("Please enter selection number: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        PrintTitle();
                        MastermindBoard mastermindBoard = new MastermindBoard();
                        GameInterface gameInterface = new GameInterface(mastermindBoard);
                        gameInterface.PrintInstructions();
                        break;
                    case "2":
                        Console.Clear();
                        PrintTitle();
                        Console.WriteLine("Generating the secret number...");
                        MastermindBoard board = new MastermindBoard();
                        GameInterface GI = new GameInterface(board);
                        GI.Play();
                        break;
                    case "3":
                        keepPlaying = false;
                        continue;
                    default:
                        Console.WriteLine("Invalid Menu Selection. Please try again.");
                        break;
                }
                Console.ReadLine();
            }
        }

        public static void PrintTitle()
        {
            string title = @"
    __  ___           __                      _           __
   /  |/  /___ ______/ /____  _________ ___  (_)___  ____/ /
  / /|_/ / __ `/ ___/ __/ _ \/ ___/ __ `__ \/ / __ \/ __  / 
 / /  / / /_/ (__  ) /_/  __/ /  / / / / / / / / / / /_/ /  
/_/  /_/\__,_/____/\__/\___/_/  /_/ /_/ /_/_/_/ /_/\__,_/   
                                                            ";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(title);
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
