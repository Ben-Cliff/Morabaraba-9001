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
            for (int i = 0; i < 12; i++)
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
            List<Colour> board = new List<Colour>() { Colour.Dark, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None };

            GameBoard gameBoard = new GameBoard(board);
            Player Player1 = new Player(Colour.Dark, 11, gameBoard); //Player1 still has 11 cows to place
            Player Player2 = new Player(Colour.Light, 12, gameBoard);
            Referee Peter = new Referee(gameBoard, Player1, Player2);


            Player1.moveCow(gameBoard, 0, 1);
            Player1.placeCow(gameBoard, 2);
            Assert.That(gameBoard.Positions[0] == Colour.Dark && gameBoard.Positions[1] == Colour.None);    //Asserts that the cow has moved to the new position
            Assert.That(gameBoard.Positions[2] == Colour.Dark);        //Asserts that the player is still infact placing

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

            Assert.That(Peter.isAMillFormd(4));


        }



        [Test]
        public void MillCheckDifferentCowsInMill()
        {

            List<Colour> board = new List<Colour>() { Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None };

            GameBoard gameBoard = new GameBoard(board);
            Player Player1 = new Player(Colour.Dark, 12, gameBoard);
            Player Player2 = new Player(Colour.Light, 12, gameBoard);
            Referee Peter = new Referee(gameBoard, Player1, Player2);

            board[0] = Player1.playerColour;        //Placing 3 different cows in a row (Should not form a mill)
            board[1] = Player1.playerColour;
            board[2] = Player2.playerColour;

            Assert.That(!Peter.isAMillFormd(0));

        }


        [Test]
        public void MillAndCorners()
        {
            List<Colour> board = new List<Colour>() { Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None };

            GameBoard gameBoard = new GameBoard(board);
            Player Player1 = new Player(Colour.Dark, 12, gameBoard);
            Player Player2 = new Player(Colour.Light, 12, gameBoard);
            Referee Peter = new Referee(gameBoard, Player1, Player2);

            board[4] = Player1.playerColour;        //Placing 3 identicle cows in a row (Should form a mill)
            board[5] = Player1.playerColour;
            board[6] = Player1.playerColour;



            board[13] = Player1.playerColour;       //Testing mills dont form around corners. ( [13] [4/6] [5] )



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


        [Test]
        public void CowsPlaceOnEmptySpots()
        {

            List<Colour> board = new List<Colour>() { Colour.Dark, Colour.None, Colour.Light, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None };

            GameBoard gameBoard = new GameBoard(board);
            Player Player1 = new Player(Colour.Dark, 11, gameBoard);
            Player Player2 = new Player(Colour.Light, 11, gameBoard);
            Referee Peter = new Referee(gameBoard, Player1, Player2);


            Assert.That(Peter.checkIsvalidInputPlace(0) == false); //Primary test, empty
            Assert.That(Peter.checkIsvalidInputPlace(2) == false);// test on enemy occupied spot
            Assert.That(Peter.checkIsvalidInputPlace(1) == true); // pass case





        }


        //------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //During Moving


        [Test]
        public void MoveAdjacentDark()
        {
            List<Colour> board = new List<Colour>() { Colour.Dark, Colour.None, Colour.Light, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None };

            GameBoard gameBoard = new GameBoard(board);
            Player Player1 = new Player(Colour.Dark, 11, gameBoard);
            Player Player2 = new Player(Colour.Light, 11, gameBoard);
            Referee Peter = new Referee(gameBoard, Player1, Player2);

            //dark player
            Assert.That(Peter.checkIsvalidInputMove(0, 3) == false); //not adjacent
            Assert.That(Peter.checkIsvalidInputMove(0, 1) == true);



        }


        [Test]
        public void MoveAdjacentLight()
        {
            List<Colour> board = new List<Colour>() { Colour.Dark, Colour.None, Colour.Light, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None };

            GameBoard gameBoard = new GameBoard(board);
            Player Player1 = new Player(Colour.Dark, 11, gameBoard);
            Player Player2 = new Player(Colour.Light, 11, gameBoard);
            Referee Peter = new Referee(gameBoard, Player1, Player2);
            Peter.ImLookingAt = Player2;
            //Light player
            Assert.That(Peter.checkIsvalidInputMove(2, 23) == false); //not adjacent
            Assert.That(Peter.checkIsvalidInputMove(2, 3) == true);


        }




        [Test]
        public void MovingDoesNotChangeNumberOfCows()
        {
            List<Colour> board = new List<Colour>() { Colour.Dark, Colour.None, Colour.Light, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None };

            GameBoard gameBoard = new GameBoard(board);
            Player Player1 = new Player(Colour.Dark, 0, gameBoard);//0 means that placing is done
            Player Player2 = new Player(Colour.Light, 0, gameBoard);
            Referee Peter = new Referee(gameBoard, Player1, Player2);
            int countOne = gameBoard.PlayerCowCount(Player1.playerColour);
            Player1.moveCow(gameBoard, 0, 1);
            int countTwo = gameBoard.PlayerCowCount(Player1.playerColour);

            //dark player
            Assert.That(countOne == countTwo); //
        }



        [Test]
        public void ThreeCowsMeansflystate()
        {
            List<Colour> board = new List<Colour>() { Colour.Dark, Colour.Dark, Colour.Light, Colour.None, Colour.Dark, Colour.None, Colour.None, Colour.Light, Colour.None, Colour.None, Colour.Light, Colour.None, Colour.Light, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None };

            GameBoard gameBoard = new GameBoard(board);
            Player Player1 = new Player(Colour.Dark, 0, gameBoard);//0 means that placing is done
            Player Player2 = new Player(Colour.Light, 0, gameBoard);
            Referee Peter = new Referee(gameBoard, Player1, Player2);

            Player1.flyCow(gameBoard, 0, 3);

            Player2.flyCow(gameBoard, 2, 23);




            //dark player
            Assert.That(board[3] == Player1.playerColour); //fly is successful
            Assert.That(board[23] == Colour.None); //fly cannot occur as player2 has 4 cows on baord
        }


        [Test]
        public void FlyCowTest()
        {
            List<Colour> board = new List<Colour>() { Colour.Dark, Colour.Dark, Colour.Light, Colour.None, Colour.Dark, Colour.None, Colour.None, Colour.Light, Colour.None, Colour.None, Colour.Light, Colour.None, Colour.Light, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None };

            GameBoard gameBoard = new GameBoard(board);
            Player Player1 = new Player(Colour.Dark, 0, gameBoard);//0 means that placing is done
            Player Player2 = new Player(Colour.Light, 0, gameBoard);
            Referee Peter = new Referee(gameBoard, Player1, Player2);

            Player1.flyCow(gameBoard, 0, 3);

            Player2.flyCow(gameBoard, 2, 23);




            //dark player
            Assert.That(board[3] == Player1.playerColour); //fly is successful
            Assert.That(board[23] == Colour.None); //fly cannot occur as player2 has 4 cows on baord
        }

        // Referee isnt editing board, verifys if input is correct (or if that option isnt allowed)
        [Test]
        public void CantShootMillsWhenThereAreCows()
        {
            List<Colour> board = new List<Colour>() { Colour.Dark, Colour.Dark, Colour.Dark, Colour.None, Colour.Dark, Colour.None, Colour.None, Colour.Light, Colour.None, Colour.None, Colour.Light, Colour.None, Colour.Light, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None };
            GameBoard gameBoard = new GameBoard(board);
            Player Player1 = new Player(Colour.Dark, 0, gameBoard);//0 means that placing is done
            Player Player2 = new Player(Colour.Light, 0, gameBoard);
            Referee Peter = new Referee(gameBoard, Player1, Player2);
            Peter.ImLookingAt = Player2;

            Assert.That(Peter.checkIsvalidInputShoot(0, false) == false);
            Assert.That(Peter.checkIsvalidInputShoot(4, false) == true);
        }


        [Test]
        public void CanShootMillsWhenAllMills()
        {

            List<Colour> board = new List<Colour>() { Colour.Dark, Colour.Dark, Colour.Dark, Colour.None, Colour.None, Colour.None, Colour.None, Colour.Light, Colour.None, Colour.None, Colour.Light, Colour.None, Colour.Light, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None };
            GameBoard gameBoard = new GameBoard(board);
            Player Player1 = new Player(Colour.Dark, 0, gameBoard);//0 means that placing is done
            Player Player2 = new Player(Colour.Light, 0, gameBoard);
            Referee Peter = new Referee(gameBoard, Player1, Player2);
            Peter.ImLookingAt = Player2;

            Assert.That(Peter.checkIsvalidInputShoot(0, true) == true);

        }

        [Test]
        public void CantShootOwnCows()
        {

            List<Colour> board = new List<Colour>() { Colour.Dark, Colour.Dark, Colour.Dark, Colour.None, Colour.None, Colour.None, Colour.None, Colour.Light, Colour.None, Colour.None, Colour.Light, Colour.None, Colour.Light, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None };
            GameBoard gameBoard = new GameBoard(board);
            Player Player1 = new Player(Colour.Dark, 0, gameBoard); //0 means that placing is done
            Player Player2 = new Player(Colour.Light, 0, gameBoard);
            Referee Peter = new Referee(gameBoard, Player1, Player2);
            
            Assert.That(Peter.checkIsvalidInputShoot(0, false) == false);  //Ref set to player1 by default

        }


        [Test]
        public void CantShootAtNothing()
        {

            List<Colour> board = new List<Colour>() { Colour.None, Colour.Dark, Colour.Dark, Colour.None, Colour.None, Colour.None, Colour.None, Colour.Light, Colour.None, Colour.None, Colour.Light, Colour.None, Colour.Light, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None };
            GameBoard gameBoard = new GameBoard(board);
            Player Player1 = new Player(Colour.Dark, 0, gameBoard); //0 means that placing is done
            Player Player2 = new Player(Colour.Light, 0, gameBoard);
            Referee Peter = new Referee(gameBoard, Player1, Player2);

            Assert.That(Peter.checkIsvalidInputShoot(0, false) == false);  //Ref set to player1 by default

        }

        [Test]
        public void ShootingRemoveCowsFromBoard()
        {
            List<Colour> board = new List<Colour>() { Colour.Dark, Colour.None, Colour.Light, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None };

            GameBoard gameBoard = new GameBoard(board);
            Player Player1 = new Player(Colour.Dark, 0, gameBoard);//0 means that placing is done
            Player Player2 = new Player(Colour.Light, 0, gameBoard);
            Referee Peter = new Referee(gameBoard, Player1, Player2);

            int countOne = gameBoard.PlayerCowCount(Player2.playerColour);

            Player1.shootCow(gameBoard, 2);
            int countTwo  = gameBoard.PlayerCowCount(Player2.playerColour);

            //dark player
            Assert.That(countOne == countTwo+1 ); //
        }




        [Test]
        public void WinOccursifHasFewerThan3Cows()
        {
            List<Colour> board = new List<Colour>() { Colour.Dark, Colour.Dark, Colour.Light, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None, Colour.None };

            GameBoard gameBoard = new GameBoard(board);
            Player Player1 = new Player(Colour.Dark, 0, gameBoard);//0 means that placing is done
            Player Player2 = new Player(Colour.Light, 0, gameBoard);
            Referee Peter = new Referee(gameBoard, Player1, Player2);

            Peter.ImLookingAt = Player2;
            Peter.CheckEndGame();


            //dark player
            Assert.That(Peter.EndGame); //
        }


        [Test]
        public void WinOccursIfOpponentCannotMove()
        {
            List<Colour> boardFilled = new List<Colour>() { Colour.Dark, Colour.Light, Colour.Dark, Colour.Light, Colour.Dark, Colour.Light, Colour.Dark, Colour.Light, Colour.Dark, Colour.Light, Colour.Dark, Colour.Light, Colour.Dark, Colour.Light, Colour.Dark, Colour.Light, Colour.Dark, Colour.Light, Colour.Dark, Colour.Light };

            GameBoard gameBoard = new GameBoard(boardFilled);
            Player Player1 = new Player(Colour.Dark, 0, gameBoard);//0 means that placing is done
            Player Player2 = new Player(Colour.Light, 0, gameBoard);
            Referee Peter = new Referee(gameBoard, Player1, Player2);
            
            Assert.That(!Peter.IsAMoveAvailable()); //
        }

        [Test]
        public void ShootOnlyPossibleAsMillCreatedNotAfter()
        {
            /*
             * Ref only checks if a mill is created for the position you JUST placed on or moved to
             * Never ANY others at all, our Mill tests before cover this to make sure we only accept mills currently made in mill positions
             */
            /*
             * The only way our code can test this is if we artifically create a mill in the initial definition of the board. Then
             * move cows to form a mill and note that the last move/place/fly that created this mill is used by the mill logic earlier defined.
             * 
             * Assert.That(true);*/
            List<Colour> boardFilled = new List<Colour>() { Colour.Dark, Colour.Dark, Colour.Dark, Colour.Dark, Colour.None, Colour.Light, Colour.Dark, Colour.Light, Colour.Dark, Colour.Light, Colour.Dark, Colour.Light, Colour.Dark, Colour.Light, Colour.Dark, Colour.Light, Colour.Dark, Colour.Light, Colour.Dark, Colour.Light };

            GameBoard gameBoard = new GameBoard(boardFilled);
            Player Player1 = new Player(Colour.Dark, 1, gameBoard);//0 means that placing is done
            Player Player2 = new Player(Colour.Light, 0, gameBoard);
            Referee Peter = new Referee(gameBoard, Player1, Player2);

            bool test_spot_for_mill = Peter.isAMillFormd(4);
            Player1.placeCow(gameBoard, 4);
            bool test_spot_for_mill_after = Peter.isAMillFormd(4);

            Assert.That(test_spot_for_mill != test_spot_for_mill_after);
        }










    }
}
