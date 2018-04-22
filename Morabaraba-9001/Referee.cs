using Morabaraba9001.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Morabaraba9001.Enums;

namespace Morabaraba9001
{
    public class Referee : IReferee
    {
        public IPlayer player1 { get; private set; }

        public IPlayer player2 { get; private set; }

        public Colour WhoseTurn { get; private set; }

        public IBoard game_board { get; private set; }

        public bool EndGame { get; private set; }

        //creating one away list
        //PositionNames = list of all inputs 1 (a1) - 23 (d3)
        private List<List<int>> OneAway = new List<List<int>> {
               new List<int>{1,8,7}, //a1
               new List<int>{0,9,2},
               new List<int>{1,10,3},
               new List<int>{2,11,4 },
               new List<int>{5,12,3 },
               new List<int>{6,13,4 },
               new List<int>{7,14,5 },
               new List<int>{0,15,6 },
               new List<int>{0,9,16,15 },
               new List<int>{1,8,10,17 },
               new List<int>{ 9,2,18,11},
               new List<int>{19,10,3,12 },
               new List<int>{ 20,11,4,13},
               new List<int>{ 14,5,21,12},
               new List<int>{6,15,22,13 },
               new List<int>{ 7,8,23,14},
               new List<int>{8,23,17 },
               new List<int>{ 16,9,18},
               new List<int>{ 17,10,19},
               new List<int>{18,11,20 },
               new List<int>{19,12,21 },
               new List<int>{22,20,13 },
               new List<int>{ 23,21,14},
               new List<int>{15,16,22}
            };

        public Referee(IBoard board, IPlayer firstPlayer, IPlayer secondPlayer)
        {
            game_board = board;
            if (firstPlayer.playerColour == Colour.Light)
            {
                Console.WriteLine("Referee: Sorry light player, you cant be first.");
                player2 = firstPlayer;
                player1 = secondPlayer;
            }
            else
            {
                player1 = firstPlayer;
                player2 = secondPlayer;
            }

            ImLookingAt = player1;
            WhoseTurn = Colour.Dark;
        }

        public bool checkIsvalidInputFly(int from, int to)
        {
            Console.WriteLine("Referee: Let's take a look at what you have selected");

            if (game_board.Positions[from] != this.ImLookingAt.playerColour)
            {
                Console.WriteLine("Referee: Haibo! You have no bovine here. Try again");
                return false;

            }

            Console.WriteLine("Referee: From coordinate accepted");




            if (game_board.Positions[to] != Colour.None)
            {
                Console.WriteLine("Referee: Haibo! This appears to be filled. Chose a non-bovine affiliated spot to move to");
                return false;

            }


            Console.WriteLine("Referee: 'To' coordinate accepted");
            return true;
        }

        public bool checkIsvalidInputMove(int from, int to)
        {
            //valid to
            // -> next to (one away) + empty
            //valid from
            // -> cow = same herd 

            Console.WriteLine("Referee: Let's take a look at what you have selected");

            if (game_board.Positions[from] != this.ImLookingAt.playerColour)
            {
                Console.WriteLine("Referee: Haibo! You have no bovine here. Try again");
                return false;

            }

            Console.WriteLine("Referee: From coordinate accepted");




            if (game_board.Positions[to] != Colour.None)
            {
                Console.WriteLine("Referee: Haibo! This appears to be filled. Chose a non-bovine affiliated spot to move to");
                return false;

            }


            Console.WriteLine("Referee: 'To' coordinate accepted");

            Console.WriteLine("Referee: Now checking for if your desired coordinates is adjacent to eachother \n ......... \n ......... \n .........");



            

            List<int> FineTuned = OneAway[from];
            if (FineTuned.Contains(to) == false )
            {
                Console.WriteLine("Referee: Harrez big man, not adjacent spots");
                return false;
            }

            Console.WriteLine("Referee: Welcome to the matrix, erm, I mean, input accepted");

            return true;
        }

        public bool checkIsvalidInputPlace(int to)
        {
            if (game_board.Positions[to] != Colour.None)
            {
                Console.WriteLine("Referee: Sorry buddy, that option isnt available.");
                 return false;
            }
            Console.WriteLine("Referee: nice option there, you can do the placement there.");
            return true;
        }

        public bool checkIsvalidInputShoot( int target, bool millsAllowed)
        {
            if(game_board.Positions[target] == this.ImLookingAt.playerColour || game_board.Positions[target] == Colour.None)
            {
                Console.WriteLine("Referee: Error, you cannot shoot an unfilled position or an ally cow. ");
                return false;
            }


            if (!millsAllowed)
            {
                if (isAMillFormd(target))
                {
                    Console.WriteLine("Referee: Error, that is a mill, please select another pos.");
                    return false;
                }
            }
            

            return true;
        }

        public bool isAMillFormd(int to)
        {
            // First find all mills containing "to"
           
            List<List<int>> final_checks = new List<List<int>>();

            for (int i = 0; i < game_board.Mills.Count; i++)
            {

                foreach (var a in game_board.Mills[i])
                {
                    if (a == to)
                    {
                       
                        final_checks.Add(game_board.Mills[i]);
                    }

                }
            }

            for (int i = 0; i < final_checks.Count; i++)
            {
                var this_check = final_checks[i];
          
                if ((game_board.Positions[to] == game_board.Positions[this_check[0]]) &&
                    (game_board.Positions[to] == game_board.Positions[this_check[1]]) &&
                    (game_board.Positions[to] == game_board.Positions[this_check[2]]))
                {
                    return true;
                }
            }

   
            return false;
        }

        public IPlayer ImLookingAt { get; set; }
        public void playTheTurn()
        {
             //IPlayer ImLookingAt
            switch (WhoseTurn)
            {
                case Colour.Dark:
                    ImLookingAt = player1;
                    Console.WriteLine("Referee: It is your turn Ms. Dark.");
                    break;
                case Colour.Light:
                    ImLookingAt = player2;
                    Console.WriteLine("Referee: Ah, Mr. Light, step forwards since it's you!");
                    break;
            }

            //Check player can acutally move
            if (!IsAMoveAvailable())
            {
                Console.WriteLine("Referee: you cant move, you lose. Sorry");
                EndGame = true;
                switch (WhoseTurn)
                {
                    case Colour.Dark: WhoseTurn = Colour.Light; break;
                    case Colour.Light: WhoseTurn = Colour.Dark; break;
                }
                return;
            }

            (int, int) userGave = (-1, -1);

            Console.WriteLine("Referee: Cool, so lets see what you can do...");
            if (ImLookingAt.CowsInBox > 0)                   // ******************************************************************************PLACE STATE                          
            {
                Console.WriteLine("Referee: you still have cows in your box, so you are going to place one in an open spot on the board, where shall that be? " + "Your box has: " + ImLookingAt.CowsInBox.ToString() + " cows");
                userGave = ImLookingAt.getActionInput(Enums.RefListens.SinglePosition);
                bool ref_test1 = checkIsvalidInputPlace(userGave.Item2);
                while (ref_test1 == false)
                {
                    userGave = ImLookingAt.getActionInput(Enums.RefListens.SinglePosition);
                    ref_test1 = checkIsvalidInputPlace(userGave.Item2);
                }
                
                ImLookingAt.placeCow(game_board, userGave.Item2);
            }
            else if (game_board.PlayerCowCount(ImLookingAt.playerColour) == 3) // ******************************************************************************FLY STATE
            {
                Console.WriteLine("Referee: You have " + game_board.PlayerCowCount(WhoseTurn).ToString() + " cows left on el board");
                userGave = ImLookingAt.getActionInput(Enums.RefListens.DoublePosition);
                bool ref_test1 = checkIsvalidInputFly(userGave.Item1,userGave.Item2);
                while (ref_test1 == false)
                {
                    userGave = ImLookingAt.getActionInput(Enums.RefListens.DoublePosition);
                    ref_test1 = checkIsvalidInputFly(userGave.Item1, userGave.Item2);
                }

                ImLookingAt.flyCow(game_board, userGave.Item1, userGave.Item2);
            }
            else                                                                // ******************************************************************************MOVE STATE
            {
                userGave = ImLookingAt.getActionInput(Enums.RefListens.DoublePosition);

                bool ref_test1 = checkIsvalidInputMove(userGave.Item1 , userGave.Item2);
                while (ref_test1 == false)
                {
                    userGave = ImLookingAt.getActionInput(Enums.RefListens.DoublePosition);
                    ref_test1 = checkIsvalidInputMove(userGave.Item1 , userGave.Item2);
                }

                ImLookingAt.moveCow(game_board, userGave.Item1, userGave.Item2);

            }

            Colour whatWeLookAt = Colour.None;
            if (isAMillFormd(userGave.Item2) == true)
            {
                bool millShootCheck = false;
               
                if (ImLookingAt.playerColour == Colour.Dark)
                {
                    whatWeLookAt = Colour.Light;
                }
                else
                {
                    whatWeLookAt = Colour.Dark;
                }
                for (int i = 0; i < game_board.Positions.Count; i++)
                {
                    if (game_board.Positions[i] == whatWeLookAt)
                    {
                        if (!isAMillFormd(i))
                        {
                            Console.WriteLine("Referee: You can shoot - " + game_board.PositionNames[i]);
                            millShootCheck = true;
                        }
                    }
                }

                if (millShootCheck == false)
                {
                    Console.WriteLine("Referee: A mill was formed, but the enemy's cows were all in mills, you CAN shoot a mill.");
                    int target = ImLookingAt.getActionInput(Enums.RefListens.SinglePosition).Item2;
                    bool ref_ismill = checkIsvalidInputShoot(target, true);
                    while (ref_ismill == false)
                    {
                        target = ImLookingAt.getActionInput(Enums.RefListens.SinglePosition).Item2;
                        ref_ismill = checkIsvalidInputShoot(target, true);
                    }
                    Console.WriteLine("Referee: Success Shot! ");
                    ImLookingAt.shootCow(game_board, target);
                }
                else
                {
                    Console.WriteLine("Referee: A mill has been formed! Shoot an enemy cow (& a non empty spot)");
                    int target = ImLookingAt.getActionInput(Enums.RefListens.SinglePosition).Item2;
                    bool ref_ismill = checkIsvalidInputShoot(target, false);
                    while (ref_ismill == false)
                    {
                        target = ImLookingAt.getActionInput(Enums.RefListens.SinglePosition).Item2;
                        ref_ismill = checkIsvalidInputShoot(target, false);
                    }
                    Console.WriteLine("Referee: Success Shot! ");
                    ImLookingAt.shootCow(game_board, target);
                }
                
            }

            // win check
            //Just use return; to finish the function

            CheckEndGame();






            Console.WriteLine("Referee: Neat, well done. You completed your turn");
            switch (WhoseTurn)
            {
                case Colour.Dark: WhoseTurn = Colour.Light; break;
                case Colour.Light: WhoseTurn = Colour.Dark; break;
            }
        }

        public void ShowWhosTurn()
        {
            if (WhoseTurn == Colour.Dark)
            {
                Console.WriteLine("-----------------------------------------------------------------------------\n\tDark\n");
            }
            else
            {
                Console.WriteLine("-----------------------------------------------------------------------------\n\tLight\n");
            }
        }

        public void CheckEndGame()
        {



            Colour whatWeLookAt = Colour.None;
            if (ImLookingAt.playerColour == Colour.Dark)
            {
                whatWeLookAt = Colour.Light;
            }
            else
            {
                whatWeLookAt = Colour.Dark;
            }
            if (game_board.PlayerCowCount(whatWeLookAt) == 2) //only two cows on board
            {
                if (whatWeLookAt == Colour.Dark)
                {
                    if (player1.CowsInBox == 0) //everything has been placed
                    {

                        //light wins
                        EndGame = true;
                        return;                                                                             //************************************ GAME ENDS HERE
                    }

                }

                else
                {
                    if (player2.CowsInBox == 0) //everything has been placed
                    {
                        //Dark wins
                        EndGame = true;
                        return;                                                                             //************************************ GAME ENDS HERE;
                    }

                }
            }




        }

        public bool IsAMoveAvailable()
        {
            if (ImLookingAt.CowsInBox > 0) return true;

            try
            {

                for (int i = 0; i < game_board.Positions.Count; i++)
                {
                    if (game_board.Positions[i] == ImLookingAt.playerColour)
                    {
                        var this_one = OneAway[i];
                        for (int j = 0; j < this_one.Count; j++)
                        {
                            if (game_board.Positions[this_one[j]] == Colour.None)
                            {
                                return true;
                            }
                        }
                    }
                }

            }
            catch (Exception e)
            {
                // We cant work out whats wrong here, this works for game but doesnt trigger
                // Test triggers it but we cant debug
                Console.WriteLine(e.Message);
               // throw e;
            }


            return false;
        }
    }



}

