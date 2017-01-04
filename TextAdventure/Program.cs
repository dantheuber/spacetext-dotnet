using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class Game
    {
        private Character Player;
        private Ship PlayerShip;
        private IList<Ship> EnemyShips;

        private Random rnd = new Random();

        static void Main(string[] args)
        {
            var game = new Game();
            Console.WriteLine("Welcome to text based space adventure!");
            string PlayerName = game.GetVerifiedInput("What is your name?");
            game.Player = new Character(PlayerName);
            string ShipName = game.GetVerifiedInput("What would you like to name your ship?");
            game.PlayerShip = new Ship(game.Player, ShipName);
            game.GenerateEnemyShips();
            Console.WriteLine("There are " + game.EnemyShips.Count + " enemies!");

            Console.ReadKey();
            FightStart:
            var shipsAlive = from ship in game.EnemyShips
                             where ship.IsDead != true 
                             select ship;

            var AliveShipCount = shipsAlive.Count();
            if (AliveShipCount > 0)
            {
                var input = game.GetInput(shipsAlive.Count() + " ships alive. What do we do?");
                if (input.ToLower() == "fight")
                {
                    var AttackTarget = game.GetVerifiedInput("Attach which target? (pass number between 1-" + AliveShipCount);

                    goto FightStart;
                }
            }
            
            Console.ReadKey();
        }

        private string GetVerifiedInput(string Message)
        {
            StartGettingValue:
            String Input;
            String Correct;
            Console.WriteLine(Message);
            Input = Console.ReadLine();
            Console.WriteLine("Is this correct? (y/n) -- " + Input);
            Correct = Console.ReadLine();
            if (Correct.ToLower() == "n")
            {
                Console.WriteLine("Okay, please tell me again.");
                goto StartGettingValue;
            }
            return Input;
        }

        private string GetInput(string Message)
        {
            Console.WriteLine(Message);
            string Input = Console.ReadLine();
            return Input;
        }

        private void GenerateEnemyShips()
        {
            int NumberOfEnemys = rnd.Next(1, 11); // generate up to 10 enemys
            for (int i = 1; i <= NumberOfEnemys; i++)
            {
                Console.WriteLine(i);
                Character EnemyCaptain = new Character("Enemy" + i);
                Ship EnemyShip = new Ship(EnemyCaptain, "EnemyShip" + 1);
                this.EnemyShips.Add(EnemyShip);
            }
        }
    }
}
