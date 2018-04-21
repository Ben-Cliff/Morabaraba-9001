using Morabaraba9001.Interfaces;
using System;
using System.Collections.Generic;

namespace Morabaraba9001
{
    class Program
    {
        static void Main(string[] args)
        {
            // As you will note we need instances to use the game
            // Currently this version isnt implemented however we still make sure we try use it
            //  -> you will need to add references like for GameBoard these were added:
            //       using Morabaraba9001.Interfaces;
            //       using System.Collections.Generic;
            List<Colour> board = new List<Colour>();
            // Currently the board is empty to start, this is just since we test if it compiles and runs
            GameBoard gameBoard = new GameBoard(board);

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
