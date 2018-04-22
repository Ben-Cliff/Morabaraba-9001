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
        [Test]//Checking initial debug mode. 7 will be replaced with 12 and vica verca
        public void PlayersStartAndCanPlace7Cows()
        {
            /*
             * var player1 = new Player(Player.Type.Red, 7);
             * // Note we used 7 to test if this works in testing with a smaller herd
             * Assert.That(player1.CowsLeftToPlace == 7);
             */
            Assert.That(false);
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
        public void RedShouldStart()
        {
            /*
             * Game g = new Game();
             * var t = g.Players[0];
             *
             * Assert.That(t.MyType == Player.Type.Red);
             */
            Assert.That(false);
        }


        [Test]
        public void OnlyEmptySpots()
        {
            /*
            * bool somethin = false;
            * try
            * {
            *     Game g = new Game();
            *     g.board.Add(BoardPos.a1, new Cow(Player.Type.Red));
            *     g.board.Add(BoardPos.c3, new Cow(Player.Type.Blue));
            *     var action = new ActionPlace();
            *     action.Test(g, BoardPos.a4);
            *     somethin = true;
            * }
            * 
            * catch (Exception ex)
            * {
            *     somethin = false;
            * }
            * 
            * Assert.That(true == somethin);
            */
            Assert.That(false);
        }


        [Test]
        public void MaximumTwelvePlacements()
        {
            /*
            * Game g = new Game();
            * g.CurrentPlayer = new Player(Player.Type.Red, 1);
            * int count_a = g.CurrentPlayer.CowsLeftToPlace;
            * ActionPlace place = new ActionPlace();
            * place.Test(g, BoardPos.a1);
            * g.CurrentPlayer.CowWasPlaced(BoardPos.a1);
            * int count_b = g.CurrentPlayer.CowsLeftToPlace;
            * 
            * bool was_it_working = true;
            * try
            * {
            *     place.Test(g, BoardPos.a4);
            *     was_it_working = false;
            * }
            * catch
            * {
            *     was_it_working = true;
            * }
            * 
            * Assert.That(count_a == 1);
            * Assert.That(count_b == 0);
            * Assert.That(was_it_working == true);
            */
            Assert.That(false);
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
            /*
            * //mock mill to be created
            * //check if mill has same players
            * 
            * Game g = new Game();
            * //3 in a row from 1 herd only
            * 
            * BoardPos b = new BoardPos();
            * g.board.Add(BoardPos.a1, new Cow(Player.Type.Red));
            * g.board.Add(BoardPos.a4, new Cow(Player.Type.Red));
            * g.board.Add(BoardPos.a7, new Cow(Player.Type.Red));
            * //3 in a row from both herds
            * g.board.Add(BoardPos.g1, new Cow(Player.Type.Blue));
            * g.board.Add(BoardPos.g4, new Cow(Player.Type.Red));
            * g.board.Add(BoardPos.g7, new Cow(Player.Type.Blue));
            * 
            * 
            * Assert.That(Mill.IsThereAMillFor(g, BoardPos.a1) == true);
            * Assert.That(Mill.IsThereAMillFor(g, BoardPos.g4) == false);
            * //fml 
            */
            Assert.That(false);
        }

        [Test]
        public void TwoPlayersExist()
        {
            /*
             * Game g = new Game();
             * int test = g.Players.Count();
             * 
             * Assert.That(test == 2);
             */
            Assert.That(false);
        }
    }
}
