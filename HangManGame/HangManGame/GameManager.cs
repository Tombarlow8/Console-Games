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

            try 
	        {	        
		        if (players == 1)
                {
                    game.guessWord = GetGuessWord().ToArray();
                }
                else if (players == 2)
                {
                    game.guessWord = PlayerSetGuessWord().ToArray();
                    Console.Clear();
                }
	        }
	        catch (Exception) //when methods that should return a string return null
	        {
                //TODO write a better exception & message                 
                Console.WriteLine("Please try again");  
                OptionsMenu();
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
            string folder = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName;
            string fpath = folder + @"\GuessWords\" + GetCatergory() + ".txt";

            if (File.Exists(fpath))
            {
                string[] guessWordArray = File.ReadAllLines(fpath).ToArray();

                return guessWordArray[rand.Next(0, guessWordArray.Length)].Trim();
            }
            else
            {             
                return null;                
            }
        }

        //gets the catergory from the user will use this to state which text file to use
        public string GetCatergory()
        {
            //TODO look into automatically generating this list (maybe using a dictionary)
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
