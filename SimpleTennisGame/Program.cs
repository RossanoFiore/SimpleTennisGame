using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTennisGame
{
    class Program
    {
        static private int playerAPoints = -1;
        static private int playerBPoints = -1;
        static void Main(string[] args)
        {
            Game game = new Game(playerAPoints, playerBPoints);
            string gameResult = String.Empty;
            gameResult = game.GetCurrentStatus();
            Console.WriteLine(gameResult);
            Console.ReadKey();
        }
    }
}
