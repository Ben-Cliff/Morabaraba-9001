using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba_9001.GameCode
{
    public enum WhichPickingOption
    {
        ExpectingEmpty,
        ExpectingAllyCow,
        ExpectingEnemyCow
    }

    public class GameInput
    {
        public static BoardPos GetBoardPosition(Game game, WhichPickingOption opt, string message, string error_message)
        {
            //switch is the options in python pick_valid_spot
            switch (opt)
            {
                // obviously expect empty
                case WhichPickingOption.ExpectingEmpty:
                    {
                        // we work out available spots, they are all blank in python
                        //  here we just dont have anything at that spot in board
                        var availableOpts = new List<BoardPos>();
                        foreach (BoardPos bp in Enum.GetValues(typeof(BoardPos)))
                        {
                            if (game.board.ContainsKey(bp))
                                availableOpts.Add(bp);
                        }

                        // because its enum we cant have null for first value
                        // however we only use it for output, the tests look at the arrays/choices rather than this position
                        BoardPos acceptMePls = BoardPos.a1; // use this so we have a variable to store the translated input in except when an exception is thrown, this is default option we look at inpput strings and board position empty below


                        bool failureTest = false;
                        // tell the player to pick
                        Console.WriteLine(message);
                        var userGives = Console.ReadLine();
                        try
                        {
                            // this gets "acceptmeplx" and if it isnt a correct input or if an exception throws - failure is set to true because we failed
                            acceptMePls = BoardWorker.StringToBoardPos(userGives);
                            if (game.board.ContainsKey(acceptMePls))
                                failureTest = true;
                        }
                        catch
                        {
                            failureTest = true;
                        }
                        
                        // while we are failing we need to re-enter input
                        while (failureTest == true)
                        {
                            // lets assume this will succeed
                            failureTest = false;

                            Console.WriteLine(error_message);
                            var thenUserGives = Console.ReadLine();
                            // if it has something in it (not empty)
                            // or if exception thrown
                            //    -> we still have failure so loop continues
                            try
                            {
                                acceptMePls = BoardWorker.StringToBoardPos(thenUserGives);
                                if (game.board.ContainsKey(acceptMePls))
                                    failureTest = true;
                            }
                            catch
                            {
                                failureTest = true;
                            }
                        }

                        // we finally found something that was correct
                        // pass it back
                        return acceptMePls;
                    }
                case WhichPickingOption.ExpectingAllyCow:
                    {
                        // expecting to encounter case above to move
                    }
                    break;
                case WhichPickingOption.ExpectingEnemyCow:
                    {
                        // expecting to encounter case above to move
                    }
                    break;
            }

            throw new Exception("Cases didnt match for get board position.");
        }
    }
}
