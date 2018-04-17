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

    class GameInput
    {
        public static BoardPos GetBoardPosition(Game game, WhichPickingOption opt, string message, string error_message)
        {
            switch (opt)
            {
                case WhichPickingOption.ExpectingEmpty:
                    {
                        var availableOpts = new List<BoardPos>();
                        foreach (BoardPos bp in Enum.GetValues(typeof(BoardPos)))
                        {
                            if (game.board.ContainsKey(bp))
                                availableOpts.Add(bp);
                        }

                        BoardPos acceptMePls = BoardPos.a1; // a1 means input, we use this so we have a variable to store the translated input in except when an exception is thrown
                        bool failureTest = false;
                        Console.WriteLine(message);
                        var userGives = Console.ReadLine();
                        try
                        {
                            acceptMePls = BoardWorker.StringToBoardPos(userGives);
                            if (game.board.ContainsKey(acceptMePls))
                                failureTest = true;
                        }
                        catch
                        {
                            failureTest = true;
                        }
                        
                        while (failureTest == true)
                        {
                            failureTest = false;

                            Console.WriteLine(error_message);
                            var thenUserGives = Console.ReadLine();
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

                        return acceptMePls;
                    }
                case WhichPickingOption.ExpectingAllyCow:
                    {

                    } break;
                case WhichPickingOption.ExpectingEnemyCow:
                    {

                    } break;
            }

            throw new Exception("Cases didnt match for get board position.");
        }
    }
}
