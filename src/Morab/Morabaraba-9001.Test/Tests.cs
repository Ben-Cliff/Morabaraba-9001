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


        [Test]
        public void GameBoardEmptyAtStart()
        {


        }

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


        [Test]
        public void MillMadeOfSameHerd()
        {
            

        }


        [Test]
        public void TwoPlayersExist()
        {
           


        }




    }
}
