using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace HangManGame
{
    public class GameManager
    {        
        public int players = 0;

        string folder = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName;

        Dictionary<int,string> catagories = new Dictionary<int, string>();

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
                Console.Clear();
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

            string fpath = folder + @"\GuessWords\" + SelectCatergory() + ".txt";

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
        public string SelectCatergory()
        {
            Console.WriteLine("\nplease pick a catergory");

            foreach (KeyValuePair<int, string> pair in catagories)
            {
                Console.WriteLine("[{0}] {1}", pair.Key, pair.Value);
            }
           
            int catergory = Convert.ToInt16(Console.ReadLine());

            return catagories[catergory];
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

        //Gets the catergories form the GUessWords Folder and adds them to a dictionary
        public void GetCatergories()
        {
            string fpath = folder + @"\GuessWords\";
            int fileCount = 1;

            foreach (string file in Directory.GetFiles(fpath))
            {
                catagories.Add(fileCount, Path.GetFileNameWithoutExtension(string.Format(file)));
                fileCount++;
            }
        }
    }
}
