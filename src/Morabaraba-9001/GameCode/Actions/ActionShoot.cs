using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba_9001.GameCode.Actions
{
    public class ActionShoot : IAction
    {
        public void PlayAction(Game game)
        {
            // shoot
            GameCode.BoardPos target = GameInput.GetBoardPosition(game, WhichPickingOption.ExpectingEnemyCow, "You have formed a Mill! \n Enter the co ordinate of which enemy cow you would like to shoot (You cannot shoot other mills)", "You cannot shoot there. Try Again");

            game.OpponentPlayer.RemoveACow(target);     //Remove cow from player's cow list
            game.board[target] = new Cow(Player.Type.None);     //remove cow from board

            throw new NotImplementedException();
        }
    }
}
