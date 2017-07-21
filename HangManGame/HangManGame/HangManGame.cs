using System;
using System.Linq;

namespace HangManGame
{
    class HangManGame
    {       
        static void Main(string[] args)
        {
            GameManager gm = new GameManager();
            Game game = new Game();

            Console.ForegroundColor = ConsoleColor.White;

            gm.players = gm.GetPlayers();   
            
            gm.OptionsMenu();

            Console.ReadLine();
        }
    }
}
