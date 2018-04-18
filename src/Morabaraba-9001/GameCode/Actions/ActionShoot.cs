using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba_9001.GameCode.Actions
{
    public class ActionShoot : IAction
    {
        public void PlayAction(Game game, List<BoardPos> input)
        {
            // shoot
            game.OpponentPlayer.RemoveACow(input[0]);     //Remove cow from player's cow list
            game.board[input[0]] = new Cow(Player.Type.None);     //remove cow from board

            input.RemoveAt(0);
        }
    }
}
