using Morabaraba9001;
using Morabaraba9001.Interfaces;
using NUnit.Framework;
using System.Collections.Generic;
using Morabaraba9001.Enums;

namespace Morabaraba_9001.Test
{
    [TestFixture]
    public class Tests
    {
        /*
            FIRST PRINCPLES:
                -> FAST
                -> ISOLATED
                -> REPEATABLE
                ->THROUGH
         */
        [Test]
        public void PlayersStartAndCanPlace12Cows()
        {
            List<Colour> brd = new List<Colour>() { Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None };
            var player1 = new Player(Colour.Dark, 12, new GameBoard(brd));
            for (int i= 0; i<12; i++)
            {
                { player1.placeCow(player1.PlayBoard, i); }
            }

            Assert.That(player1.PlayBoard.PlayerCowCount(player1.playerColour) == 12);
        }


        [Test]
        public void GameBoardEmptyAtStart()
        {
             // From implementing the "first" of the tests, made sure all tests not implemented fail for the start for us (since we are trying to succeed in and use every test)

             // First we create the testing requirements, this needs a gameboard
             // For the empty game board we need to create it as if it is a new game's board (aka. in the positions it has nothing):
            List<Colour> boardList = new List<Colour>()
            {
                Colour.None, Colour.None, Colour.None, Colour.None,
                Colour.None, Colour.None, Colour.None, Colour.None,
                Colour.None, Colour.None, Colour.None, Colour.None,
                Colour.None, Colour.None, Colour.None, Colour.None,
                Colour.None, Colour.None, Colour.None, Colour.None,
                Colour.None, Colour.None, Colour.None, Colour.None
            };
            GameBoard gameBoard = new GameBoard(boardList);

            // Finally we run the function and see if we get as many of the legitimate correct answers as we need.
            //  -> as an added note, we could have 24 "None" in the list and a single "Dark"
            //     -> Using ONLY the None doesnt guarantee it is correct from the testing perspective
            //     -> We should work on covering all bases as often as possible
            Assert.That(gameBoard.PlayerCowCount(Colour.None) == 24);
            Assert.That(gameBoard.PlayerCowCount(Colour.Dark) == 0);
            Assert.That(gameBoard.PlayerCowCount(Colour.Light) == 0);

            // You will see on this push:
            //  -> Failed   GameBoardEmptyAtStart
            //     Error Message:
            //     System.NotImplementedException : The method or operation is not implemented.
            
            // Run tests using "dotnet test" in console on your PC as you need
        }





        [Test] //Dark player start
        public void DarkShouldStart()
        {
            List<Colour> board = new List<Colour>() { Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None };
            
            GameBoard gameBoard = new GameBoard(board);
            Player Player1 = new Player(Colour.Light, 12, gameBoard);
            Player Player2 = new Player(Colour.Dark, 12, gameBoard);
            Referee Peter = new Referee(gameBoard, Player1, Player2);

            Assert.That(Peter.WhoseTurn == Colour.Dark);
        }


        [Test]
        public void OnlyEmptySpots()
        {
            List<Colour> board = new List<Colour>() { Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None };
            
            GameBoard gameBoard = new GameBoard(board);
            Player Player1 = new Player(Colour.Light, 12, gameBoard);
            Player Player2 = new Player(Colour.Dark, 12, gameBoard);
            Referee Peter = new Referee(gameBoard, Player1, Player2);

            Assert.That(gameBoard.PlayerCowCount(Colour.Dark) == 0 && gameBoard.PlayerCowCount(Colour.Light) == 0 && gameBoard.PlayerCowCount(Colour.None) == 24);
        }


        [Test]
        public void MaximumTwelvePlacements()
        {
            List<Colour> brd = new List<Colour>() { Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None };
            var player1 = new Player(Colour.Dark, 12, new GameBoard(brd));
            for (int i = 0; i < 12; i++)
            {
                { player1.placeCow(player1.PlayBoard, i); }
            }

            Assert.That(player1.PlayBoard.PlayerCowCount(Colour.Dark) == 12);

            player1.placeCow(player1.PlayBoard, 12);

            Assert.That(player1.PlayBoard.PlayerCowCount(Colour.Dark) == 12);

        }



        [Test]
        public void TestMoveStateWhilePlacing()
        {
            /* Game g = new Game();
            * var players = g.Players;    //creates players when looking at players list
            * ActionMove am = new ActionMove();
            * bool ans = false;
            * 
            * try
            * {
            *     am.Test(g, BoardPos.b4);
            *     ans = true;
            * }
            * catch (Exception)
            * {
            * }
            * 
            * Assert.That(ans == false);
            */
            Assert.That(false);
        }


        //GENERAL
        //Mill moo = Mill.GetAll[0];

        [Test]
        public void MillMadeOfSameHerd()
        {
            List<Colour> board = new List<Colour>() { Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None };
            
            GameBoard gameBoard = new GameBoard(board);
            Player Player1 = new Player(Colour.Dark, 12, gameBoard);
            Player Player2 = new Player(Colour.Light, 12, gameBoard);
            Referee Peter = new Referee(gameBoard, Player1, Player2);

            board[4] = Player1.playerColour;        //Placing 3 identicle cows in a row (Should form a mill)
            board[5] = Player1.playerColour;
            board[6] = Player1.playerColour;

            board[0] = Player1.playerColour;        //Placing 3 different cows in a row (Should not form a mill)
            board[1] = Player1.playerColour;
            board[2] = Player2.playerColour;

            board[13] = Player1.playerColour;       //Testing mills dont form around corners. ( [13] [4/6] [5] )

            Assert.That(Peter.isAMillFormd(4));     

            Assert.That(!Peter.isAMillFormd(0));

            Assert.That(!Peter.isAMillFormd(13));

        }

        [Test]
        public void TwoPlayersExist()
        {
            List<Colour> board = new List<Colour>() { Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None };
            
            GameBoard gameBoard = new GameBoard(board);
            Player Player1 = new Player(Colour.Dark, 12, gameBoard);
            Player Player2 = new Player(Colour.Light, 12, gameBoard);
            Referee Peter = new Referee(gameBoard, Player1, Player2);

            Assert.That(Peter.player1 != null && Peter.player2 != null && Peter.player1 != Peter.player2);

        }
    }
}
