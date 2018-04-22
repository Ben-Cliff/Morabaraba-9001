﻿using Morabaraba9001.Interfaces;
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

            WhoseTurn = Colour.Dark;
        }

        public bool checkIsvalidInputFly(int from, int to)
        {
            throw new NotImplementedException();
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
                Console.WriteLine("Haibo! This appears to be filled. Chose a non-bovine affiliated spot to move from");
                return false;

            }

            Console.WriteLine("Referee: From coordinate accepted");




            if (game_board.Positions[to] != Colour.None)
            {
                Console.WriteLine("Haibo! This appears to be filled. Chose a non-bovine affiliated spot to move to");
                return false;

            }


            Console.WriteLine("Referee: 'To' coordinate accepted");

            Console.WriteLine("Referee: Now checking for if your desired coordinates is adjacent to eachother \n ......... \n ......... \n .........");



            //creating one away list
            //PositionNames = list of all inputs 1 (a1) - 23 (d3)
            List<List<int>> OneAway = new List<List<int>> {
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

        public bool checkIsvalidInputShoot(int from, int to)
        {
            throw new NotImplementedException();
        }

        public bool isAMillFormd(int to)
        {
            // First find all mills containing "to"
            List<List<int>> final_checks = new List<List<int>>();
            foreach (var m in game_board.Mills)
            {
                if (m.Contains(to))
                {
                    final_checks.Add(m);
                }
            }

            // Go through final_checks for that point
            while (!(final_checks.Count == 0))
            {
                var this_check = final_checks[0];
                this_check.RemoveAt(0);
                if ((game_board.Positions[to] == game_board.Positions[this_check[0]]) &&
                    (game_board.Positions[to] == game_board.Positions[this_check[1]]) &&
                    (game_board.Positions[to] == game_board.Positions[this_check[2]]))
                    {
                        return true;
                    }

            }

            return false;
        }

        public IPlayer ImLookingAt { get; private set; }
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

            Console.WriteLine("Referee: Cool, so lets see what you can do...");
            if (ImLookingAt.CowsInBox > 0)
            {
                Console.WriteLine("Referee: you still have cows in your box, so you are going to place one in an open spot on the board, where shall that be?");
                var userGave = ImLookingAt.getActionInput(Enums.RefListens.SinglePosition);
                bool ref_test1 = checkIsvalidInputPlace(userGave.Item1); //**************************************************************************
                while (ref_test1 == false)
                {
                    userGave = ImLookingAt.getActionInput(Enums.RefListens.SinglePosition);
                    ref_test1 = checkIsvalidInputPlace(userGave.Item1);
                }
                
                ImLookingAt.placeCow(game_board, userGave.Item1);
            }



            else if (game_board.PlayerCowCount(ImLookingAt.playerColour) == 3)
            {
                throw new Exception("Fly move not implemented yet.");
            }
            else // ******************************************************************************MOVE STATE
            {
                var UserGave = ImLookingAt.getActionInput(Enums.RefListens.DoublePosition);
                bool ref_test1 = checkIsvalidInputMove(UserGave.Item1 , UserGave.Item2);
                while (ref_test1 == false)
                {
                    UserGave = ImLookingAt.getActionInput(Enums.RefListens.DoublePosition);
                    ref_test1 = checkIsvalidInputMove(UserGave.Item1 , UserGave.Item2);
                }

                ImLookingAt.moveCow(game_board, UserGave.Item1, UserGave.Item2);

            }

            // Mill check

            // win check
            //Just use return; to finish the function

            Console.WriteLine("Referee: Neat, well done. You completed your turn");
            switch (WhoseTurn)
            {
                case Colour.Dark: WhoseTurn = Colour.Light; break;
                case Colour.Light: WhoseTurn = Colour.Dark; break;
            }
        }
    }
}
