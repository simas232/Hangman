using System;
using System.Linq;

namespace Hangman.Utilities
{
    public class Misc
    {
        public static bool CheckForGameWin(char[] printedWord)
        {
            if (!printedWord.Contains('_'))
            {
                Output.PrintTextInColor("Congratulations, You Won The Game!", ConsoleColor.Green, true);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
