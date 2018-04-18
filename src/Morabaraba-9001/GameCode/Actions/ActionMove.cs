using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba_9001.GameCode.Actions
{
    public class ActionMove : IAction
    {
        public void PlayAction(Game game, List<BoardPos> input)
            {
                GameCode.BoardPos frmm = input[0];
                GameCode.BoardPos too = input[1];
            input.RemoveAt(0);
            input.RemoveAt(0);
            if (game.CurrentPlayer.CowsLeftToPlace > 0)
            { throw new Exception("Error"); }


                if (game.CurrentPlayer.HowManyCows() == 3)         //              if 3 cows left: fly
                    {
                    game.CurrentPlayer.RemoveACow(frmm);
                    game.CurrentPlayer.CowWasPlaced(too);    // updating player's list of cows

                    game.board[frmm] = new Cow(Player.Type.None);
                    game.board[too] = new Cow(game.CurrentPlayer.MyType);    //updating actual board

                    if (Mill.IsThereAMillFor(game, too))     //A check for a mill formed. Shoots if true
                    {
                    input.RemoveAt(0);
                    game.GetAction(AvailableActions.Shoot).PlayAction(game, input); }
                }

                else
                    {

                game.CurrentPlayer.RemoveACow(too);
                game.CurrentPlayer.CowWasPlaced(too);    // updating player's list of cows

                game.board[frmm] = new Cow(Player.Type.None);
                game.board[too] = new Cow(game.CurrentPlayer.MyType);

                if (Mill.IsThereAMillFor(game, too))     //A check for a mill formed. Shoots if true
                {
                    game.GetAction(AvailableActions.Shoot).PlayAction(game, input);
                }
                

            }



            


                //                  # check
                //                      # shoot
          
            }

        public void Test(Game g, BoardPos b)
        {
            if (g.CurrentPlayer.CowsLeftToPlace > 0)
            { throw new Exception("Error"); }
        }
    }
}
