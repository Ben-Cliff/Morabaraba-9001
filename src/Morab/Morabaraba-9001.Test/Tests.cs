using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Linq;
using Morabaraba_9001.GameCode;
using Morabaraba_9001.GameCode.Actions;

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
            var player1 = new Player(Player.Type.Red, 7);
            // Note we used 7 to test if this works in testing with a smaller herd
            Assert.That(player1.CowsLeftToPlace == 7);
        }

        
        [Test]
        public void GameBoardEmptyAtStart()
        {
            Game g = new Game();
            Assert.That(g.board.Count() == 0);

        }
        


        
        
        [Test] //Dark player start
        public void RedShouldStart()
        {
            Game g = new Game();
            var t = g.Players[0];

            Assert.That(t.MyType == Player.Type.Red);

        }

        
        [Test]
        public void OnlyEmptySpots()
        {
            bool somethin = false;
            try
            {
                Game g = new Game();
                g.board.Add(BoardPos.a1, new Cow(Player.Type.Red));
                g.board.Add(BoardPos.c3, new Cow(Player.Type.Blue));
                var action = new ActionPlace();
                action.PlayAction(g, new List<BoardPos>() { BoardPos.a4 });
                somethin = true;
            }
            
            catch (Exception ex)
            {
                somethin = false;
            }

            Assert.That(true == somethin);

        }


        [Test]
        public void MaximumTwelvePlacements()
        {
            Game g = new Game();
            g.CurrentPlayer = new Player(Player.Type.Red, 1);
            int count_a = g.CurrentPlayer.CowsLeftToPlace;
            ActionPlace place = new ActionPlace();
            place.PlayAction (g, new List<BoardPos>() { BoardPos.a1 });
            g.CurrentPlayer.CowWasPlaced(BoardPos.a1);
            int count_b = g.CurrentPlayer.CowsLeftToPlace;

            bool was_it_working = true;
            try
            {
                place.PlayAction(g, new List<BoardPos>() { BoardPos.a4 });
                was_it_working = false;
            }
            catch
            {
                was_it_working = true;
            }

            Assert.That(count_a == 1);
            Assert.That(count_b == 0);
            Assert.That(was_it_working == true);
        }



        [Test]
        public void TestMoveStateWhilePlacing()
        {
            Game g = new Game();
            var players = g.Players;    //creates players when looking at players list
            ActionMove am = new ActionMove();
            bool ans = false;
            
            try
            {
                am.PlayAction(g, new List<BoardPos>() { BoardPos.b4 });
                ans = true;
            }
            catch (Exception)
            {
            }

            Assert.That(ans == false);
        }

    
        //GENERAL
        //Mill moo = Mill.GetAll[0];

        [Test]
        public void MillMadeOfSameHerd()
        {
            //mock mill to be created
            //check if mill has same players

            Game g = new Game();
            //3 in a row from 1 herd only

            BoardPos b = new BoardPos();
            g.board.Add(BoardPos.a1, new Cow(Player.Type.Red));
            g.board.Add(BoardPos.a4, new Cow(Player.Type.Red));
            g.board.Add(BoardPos.a7, new Cow(Player.Type.Red));
            //3 in a row from both herds
            g.board.Add(BoardPos.g1, new Cow(Player.Type.Blue));
            g.board.Add(BoardPos.g4, new Cow(Player.Type.Red));
            g.board.Add(BoardPos.g7, new Cow(Player.Type.Blue));


            Assert.That(Mill.IsThereAMillFor(g, BoardPos.a1) == true);
            Assert.That(Mill.IsThereAMillFor(g, BoardPos.g4) == false);
            //fml 

        }
        
        [Test]
        public void TwoPlayersExist()
        { 
            Game g = new Game();
            int test = g.Players.Count();

            Assert.That(test == 2);
            
            
        }
        


    }
}
