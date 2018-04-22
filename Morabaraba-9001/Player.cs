using Morabaraba9001.Enums;
using Morabaraba9001.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

// Reminder for Ernest: Ctrl+K, Ctrl+F -> line code up

namespace Morabaraba9001
{
    class Player : IPlayer
    {

        public Colour playerColour { get; private set; }

        public int CowsInBox { get; private set; }

        public IBoard PlayBoard { get; private set; }


        public Player(Colour player_id, int how_many, IBoard playMove)
        {
            playerColour = player_id;
            CowsInBox = how_many;
            PlayBoard = playMove;

        }

        public void flyCow(IBoard board, int from, int to)
        {
            board.AdjustBoard_Fly(from, to, this.playerColour);
            Console.WriteLine("Player's Cow Flown");
        }


        public void moveCow(IBoard board, int from, int to)
        {
            board.AdjustBoard_Move(from, to, this.playerColour);
            Console.WriteLine("Player's Cow Moved");
        }

        public void placeCow(IBoard board, int to)
        {
            board.AdjustBoard_Place(to, this.playerColour);
            Console.WriteLine("Player's Cow was placed");
        }

        public void shootCow(IBoard board, int target)
        {
            board.AdjustBoard_Shoot(target);
            Console.WriteLine("Enemy Player's Cow was Shot");
        }

        public (int, int) getActionInput(RefListens to)
        {
            if (RefListens.DoublePosition == to)
            {
                bool inputOne = false;
                int numeroUno = -1;
                Console.WriteLine("Which spot do you want to pick from?");
                while (inputOne == false)
                {
                    var userGives = Console.ReadLine();
                    try
                    {

                        if (PlayBoard.PositionNames.Contains(userGives.ToLower()))
                        {

                            numeroUno = (PlayBoard.PositionNames.IndexOf(userGives.ToLower()));
                            inputOne = true;

                        }
                        else
                        {
                            Console.WriteLine("Player: Sorry that isnt a board positions, try again");
                        }

                    }
                    catch
                    {
                        Console.WriteLine("Player: please input correct co-ordinate you would like to move from. Eg a4");
                    }


                }
                Console.WriteLine("Which spot do you want to go to?");
                while (true)
                {
                    var userGives = Console.ReadLine();
                    try
                    {

                        if (PlayBoard.PositionNames.Contains(userGives.ToLower()))
                        {

                            return (numeroUno, PlayBoard.PositionNames.IndexOf(userGives.ToLower()));


                        }
                        else
                        {
                            Console.WriteLine("Player: Sorry that isnt a board positions, try again");
                        }

                    }
                    catch
                    {
                        Console.WriteLine("Player: please input correct co-ordinate you would like to move to. Eg d7");
                    }


                }







            }
            else if (RefListens.SinglePosition == to)
            {
                // tell the player to pick
                Console.WriteLine("Which spot do you want to pick?");


                while (true)
                {

                    var userGives = Console.ReadLine();
                    try
                    {

                        if (PlayBoard.PositionNames.Contains(userGives.ToLower()))
                        {

                            return ( -1, PlayBoard.PositionNames.IndexOf(userGives.ToLower()));

                        }
                        else
                        {
                            Console.WriteLine("Player: Sorry that isnt a board positions, try again");
                        }


                    }
                    catch
                    {
                        Console.WriteLine("Player: please input correct co-ordinate. Eg a7");
                    }

                }
            }

            return (-1, -1);
        }
    }
}
