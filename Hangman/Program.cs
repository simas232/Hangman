using System;
using System.Linq;
using System.Text;
using Hangman.Utilities;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load the file with random words from the same directory as Program.cs file
            string[] wordArray = System.IO.File.ReadAllText(path: AppDomain.CurrentDomain.BaseDirectory + "../../../words.txt").Split(',');
            
            Random rnd = new Random();
            string secretWord = wordArray[rnd.Next(0, wordArray.Length)];
            char[] printedWord = Enumerable.Repeat('_', secretWord.Length).ToArray();
            
            StringBuilder incorrectLetters = new StringBuilder();
            string userGuess;
            int guessesLeft = 10;
            do
            {
                Output.DisplayMainScreen(printedWord);   

                //Perhaps a strange place to check for a game win, but it allows to show up nicely with revealed word in refreshed console
                if (Misc.CheckForGameWin(printedWord))
                {
                    break;
                }

                Output.PrintTextInColor($"Guesses Left: {guessesLeft}", ConsoleColor.Green, true);
                Output.PrintTextInColor($"Guessed Letters: {incorrectLetters}", ConsoleColor.Green, true);
                
                userGuess = Input.AskForStringInput("Enter Your Guess (letter or word): ");

                if (userGuess.Length == 1)
                {
                    if (string.Join("", printedWord).Contains(userGuess))
                    {
                        continue;
                    }
                    else if (secretWord.Contains(userGuess))
                    {
                        for (int index = 0; index < secretWord.Length; index++)
                        {
                            if (secretWord[index].Equals(char.Parse(userGuess)))
                            {
                                printedWord[index] = char.Parse(userGuess);
                            }
                        }
                    }
                    else if (incorrectLetters.ToString().Contains(userGuess))
                    {
                        continue;//This letter was used in previous guesses, so it should not be counted as another guess
                    } 
                    else
                    {
                        incorrectLetters.Append(userGuess);
                    }
                }
                else if (userGuess.Length > 1)
                {
                    if (secretWord.Equals(userGuess))
                    {
                        printedWord = secretWord.ToCharArray();
                        continue;//To prevent false game lost announcement if guessesLeft = 1 at this line
                    }
                }
                guessesLeft--;//Should only be reached if the current guess does not reveal the whole secret word
            } while (guessesLeft > 0);

            if (guessesLeft == 0)
            {
                Output.PrintTextInColor($"You Lost The Game! The Secret Word Was: {secretWord}", ConsoleColor.Red, true);
            }
            Input.WaitForSpacebar();
        }
    }
}
