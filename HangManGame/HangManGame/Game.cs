using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HangManGame
{
    public class Game
    {       
        public List<char> guessedLetters = new List<char>();
        
        #region Variables      
        public char[] guessWord;
        int incorrectGuesses = 0;
        char guessedLetter;
        bool guessedCorrectly = false;
        public bool winOrLose = false;       
        #endregion

        public void Guessing()
        {
            char guessedLetter = PlayerGuess();
           
            foreach (char letter in guessWord)
            {
                if (guessedLetter == letter || Convert.ToChar(guessedLetter.ToString().ToUpper()) == letter)
                {
                    guessedCorrectly = true;
                    break;
                }
                else
                {
                    guessedCorrectly = false;
                }
            }

            if (guessedCorrectly != true)
            {
                incorrectGuesses++;
                HangManDraw(incorrectGuesses);
            }

            GuessedSofar();
        }

        // prints out the letters guessed so far and unguessed letters appear as "_"
        public void GuessedSofar()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < guessWord.Length; i++)
            {
                if (guessedLetters.Contains(guessWord[i]))
                {
                    sb.Append(guessWord[i]);
                }
                else
                {
                    sb.Append('_');
                }                 
            }
                               
            Console.WriteLine(sb.ToString().ToCharArray());

            PrintGuessedLetters();

            string guessWordString = string.Join("", guessWord);

            if (sb.ToString() == guessWordString)
            {
                winOrLose = true;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nYOU WIN!!!!!!!!!!!");
                Console.ForegroundColor = ConsoleColor.White;
            }            
        }
   
        // takes the user input adds it to the list of already guessed letters
        public char PlayerGuess()
        {
            Console.WriteLine("\nGuess a letter");

            try
            {
                guessedLetter = Convert.ToChar(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter one character at a time");
                PlayerGuess();
            }

            guessedLetters.Add(guessedLetter);
            guessedLetters.Add(Convert.ToChar(guessedLetter.ToString().ToUpper()));
            
            return guessedLetter;
        }

        // draws the hangman visual for the player
        public void HangManDraw(int incorrectGuesses)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            switch (incorrectGuesses)
            {               
                case 1: Console.WriteLine("______"); break;

                case 2: Console.WriteLine("______/"); break;

                case 3:
                        Console.WriteLine("       |");
                        Console.WriteLine("       |");
                        Console.WriteLine("       |");
                        Console.WriteLine("______/|"); break;

                case 4:
                        Console.WriteLine(@"      \|");
                        Console.WriteLine("       |");
                        Console.WriteLine("       |");
                        Console.WriteLine("       |");
                        Console.WriteLine("______/|"); break;

                case 5:
                        Console.WriteLine("  _____");
                        Console.WriteLine(@"      \|");
                        Console.WriteLine("       |");
                        Console.WriteLine("       |");
                        Console.WriteLine("       |");
                        Console.WriteLine("______/|"); break;

                case 6:
                        Console.WriteLine("  _____");
                        Console.WriteLine(@" |    \|");
                        Console.WriteLine("       |");
                        Console.WriteLine("       |");
                        Console.WriteLine("       |");
                        Console.WriteLine("______/|"); break;

                case 7:
                        Console.WriteLine("  _____");
                        Console.WriteLine(@"  |   \|");
                        Console.WriteLine("  0    |");
                        Console.WriteLine("       |");
                        Console.WriteLine("       |");
                        Console.WriteLine("______/|"); break;

                case 8:
                        Console.WriteLine("  _____");
                        Console.WriteLine(@"  |   \|");
                        Console.WriteLine("  0    |");
                        Console.WriteLine("  |    |");
                        Console.WriteLine("       |");
                        Console.WriteLine("______/|"); break;

                case 9:
                        Console.WriteLine("  _____");
                        Console.WriteLine(@"  |   \|");
                        Console.WriteLine("  0    |");
                        Console.WriteLine(@"  |\   |");
                        Console.WriteLine("       |");
                        Console.WriteLine("______/|"); break;

                case 10:
                        Console.WriteLine("  _____");
                        Console.WriteLine(@"  |   \|");
                        Console.WriteLine("  0    |");
                        Console.WriteLine(@" /|\   |");
                        Console.WriteLine("       |");
                        Console.WriteLine("______/|"); break;

                case 11:
                        Console.WriteLine("  _____");
                        Console.WriteLine(@"  |   \|");
                        Console.WriteLine("  0    |");
                        Console.WriteLine(@" /|\   |");
                        Console.WriteLine(@"   \   |");
                        Console.WriteLine("______/|"); break;

                case 12:
                        Console.WriteLine("  _____");
                        Console.WriteLine(@"  |   \|");
                        Console.WriteLine("  0    |");
                        Console.WriteLine(@" /|\   |");
                        Console.WriteLine(@" / \   |");
                        Console.WriteLine("______/|"); 
                        Console.WriteLine("GAME OVER");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("The Answer was {0}",String.Join("",guessWord));
                        winOrLose = true;
                        break;

                default:
                    break;
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintGuessedLetters()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Guessed letters: ");

            //TODO Make it so it print in red for 'incorrect' and green for 'correct' characters
            for (int i = 0; i < guessedLetters.Count;)
            {
                Console.Write(guessedLetters[i].ToString().ToUpper() + " ");
                i += 2;
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
