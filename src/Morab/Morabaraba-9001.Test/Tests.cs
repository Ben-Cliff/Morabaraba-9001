using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Linq;
using Morabaraba_9001.GameCode;

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

        /*
        [Test]
        public void GameBoardEmptyAtStart()
        {


        }
        /*


        /*

        [Test] //Dark player start
        public void RedShouldStart()
        {


        }


        [Test]
        public void OnlyEmptySpots()
        {


        }


        [Test]
        public void MaximumTwelvePlacements()
        {


        }



        [Test]
        public void TestMoveStateWhilePlacing()
        {


        }

    */
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

            

            Assert.That(Mill.IsThereAMillFor(g, BoardPos.a1) == true && Mill.IsThereAMillFor(g, BoardPos.g1) == false);
            //fml 

        }

        /*
        [Test]
        public void TwoPlayersExist()
        {
           


        }

        */


    }
}
