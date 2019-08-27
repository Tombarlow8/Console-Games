using System;

namespace Lost_in_Space
{
    class Program
    {
        static void Main(string[] args)
        {
            Ship ship = new Ship();
     
            ship.SystemStartUp();

            ship.Introduction();

            ship.generateScenarioList();

            while (ship.SystemHealthCheck())
            {
                Console.WriteLine("view ship status Y/N?");   
                string answer = Console.ReadLine();
                if (answer == "Y" || answer == "y" || answer == "Yes" || answer == "yes")
                {
                    ship.SystemStatusReport();
                }
                ship.invokeScenario();        
            }

                 
        }
    }
}
