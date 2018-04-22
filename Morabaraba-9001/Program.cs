using Morabaraba9001.Interfaces;
using System;
using System.Collections.Generic;
using Morabaraba9001.Enums;

namespace Morabaraba9001
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Colour> board = new List<Colour>() { Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None };
            // Currently the board is empty to start, this is just since we test if it compiles and runs
            GameBoard gameBoard = new GameBoard(board); // For some reason we arent allowed IGameBoard?
            IPlayer Player1 = new Player(Colour.Dark, 12, gameBoard);
            IPlayer Player2 = new Player(Colour.Light, 12, gameBoard);
            IReferee Peter = new Referee(gameBoard, Player1, Player2);
            Console.WriteLine("Welcome to Morabarab C# OOPS \n Have faith in the referee that he will have a just <3");
         

            while (Peter.EndGame == false)
            {
                Peter.ShowWhosTurn();
                gameBoard.DrawBoard();
                Peter.playTheTurn();
            }

            Console.Write("\n\tCongratulations on your game, ");
            switch (Peter.ImLookingAt.playerColour)
            {
                case Colour.Dark: Console.Write("Dark");
                    break;
                case Colour.Light: Console.Write("Light");
                    break;
            }
            Console.Write(" you have won");
            Console.ReadLine();
        }
    }
}
