using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba_9001.GameCode.Actions
{
    public class ActionMove : IAction
    {
        public void PlayAction(Game game)
        {
            //              #if 3 cows left: fly
            //                  # pick where from
            //                  # pick anywhere open to
            //                  # move there
            //                  # check mill
            //                      # shoot
            //              # else
            GameCode.BoardPos frm = GameInput.GetBoardPosition(game, WhichPickingOption.ExpectingAllyCow, "Enter the co ordinate of the cow you would like to move", "You do not have any cows in that position. Try Again");
            GameCode.BoardPos to = GameInput.GetBoardPosition(game, WhichPickingOption.ExpectingAllyCow, "Enter the co ordinate you would like to move your cow to", "You can only move to empty spots, one unit away. Try Again");      // get choice of possibility - to

            game.CurrentPlayer.RemoveACow(to);
            game.CurrentPlayer.AddCow(to);    // move there

            game.board[frm] = new Cow(Player.Type.None); 
            game.board[to] = new Cow(game.CurrentPlayer.MyType);    //update board

            if (Mill.IsThereAMillFor(game, to))
            { game.GetAction(AvailableActions.Shoot).PlayAction(game); }


            //                  # check
            //                      # shoot
            throw new NotImplementedException();
        }
    }
}
