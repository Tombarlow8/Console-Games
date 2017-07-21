using System;
using System.Linq;
using System.IO;

namespace HangManGame
{
    public class GameManager
    {        
        public int players = 0;

        public void OptionsMenu()
        {
            Game game = new Game();

            if (players == 1)
            {
                game.guessWord = GetGuessWord().ToArray();
            }
            else if (players == 2)
            {
                game.guessWord = PlayerSetGuessWord().ToArray();
                //TODO better way to hide the multplayer GuessWord form the user
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
            }

            game.winOrLose = false;

            while (!game.winOrLose)
            {                   
                game.Guessing();
            }

            OptionsMenu();
        }

        //getting the guessWord form the appropriate text file
        public string GetGuessWord()
        {
            Random rand = new Random();

            string fpath = @"D:\Visual Studio 2017 Projects\HangManGame\HangManGame\GuessWords\" + GetCatergory() + ".txt";

            if (File.Exists(fpath))
            {
                string[] guessWordArray = File.ReadAllLines(fpath).ToArray();

                return guessWordArray[rand.Next(0, guessWordArray.Length)].Trim();
            }
            else
            {   //TODO go back to main menu????           
                return "File Path Not valid";
            }
        }

        //gets the catergory from the user will use this to which text file to use
        public string GetCatergory()
        {
            Console.WriteLine("please pick a catergory");
            Console.WriteLine("[1] Cities");
            Console.WriteLine("[2] Countries");
            Console.WriteLine("[3] Films");
            Console.WriteLine("[4] USA States");

            string catergory = Console.ReadLine();

            switch (catergory)
            {
                case "1": return "Cities";
                case "2": return "Countries";
                case "3": return "Films";
                case "4": return "USA States";
                //TODO should take you back to GetCategory with a message
                default: return null;
            }
        }
      
        public int GetPlayers()
        {        
            Console.WriteLine("Please select single player or multiplayer");
            Console.WriteLine("[1] Single pLayer\n[2] Multiplayer");

            players = Convert.ToInt32(Console.ReadLine());

            return players;
        }
        
        public string PlayerSetGuessWord()
        {
            Console.WriteLine("Enter the Guess Word Below");

            return Console.ReadLine();
        }
    }
}
