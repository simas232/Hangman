using System;
using System.Globalization;

namespace Hangman.Utilities
{
    public class Input
    {
        public static string AskForStringInput(string recurringLine)
        {
            string warningMessage = "Invalid Input! Enter Some Text, White Space Does Not Count.";
            Output.PrintTextInColor(recurringLine, ConsoleColor.Green, false);
            string inputString = Console.ReadLine();

            while (String.IsNullOrWhiteSpace(inputString))
            {
                Console.SetCursorPosition(0, Console.CursorTop - 2);
                Output.PrintTextInColor(warningMessage, ConsoleColor.Red, true);
                Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
                Output.PrintTextInColor(recurringLine, ConsoleColor.Green, false);
                inputString = Console.ReadLine();
            }
            Output.RemoveLastPrintedLine();
            Output.RemoveLastPrintedLine();
            Console.WriteLine("");
            return inputString;
        }
        public static void WaitForSpacebar()
        {
            string printedMessage = "Press <Spacebar> to Return to Main Menu... ";
            Console.WriteLine("");
            Output.PrintTextInColor(printedMessage, ConsoleColor.Green, true);
            while (Console.ReadKey().Key != ConsoleKey.Spacebar) { }
        }
    }
}
