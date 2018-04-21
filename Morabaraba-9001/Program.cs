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
            Player Player1 = new Player(Colour.Dark, 12, gameBoard);
            Player Player2 = new Player(Colour.Light, 12, gameBoard);
            Referee Peter = new Referee(gameBoard, Player1, Player2);
            Console.WriteLine("Welcome to Morabarab C# OOPS \n Have faith in the referee that he will have a just <3");

            while (Peter.EndGame == false)
            {
                Peter.playTheTurn();
                // F12
                //Whose turn
                //Can player move?
                //place to move state -> then fly
                //is mill
                //game ends?
               
            }
            

            Console.ReadLine();
        }
    }
}
