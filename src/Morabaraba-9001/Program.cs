using Morabaraba_9001.GameCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba_9001
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            
            while (!game.EndGame)
            {
                game.Draw();
                game.Update();
            }

            game.EndGameMessage();

            System.Console.ReadLine();
        }
    }
}
