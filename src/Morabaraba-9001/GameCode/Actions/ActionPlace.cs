using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba_9001.GameCode.Actions
{
    public class ActionPlace : IAction
    {
        // also requires update players cow positions
        public PlayOption PlayAction(Game game)
        {
            var user_chose = GameInput.GetBoardPosition(game, WhichPickingOption.ExpectingEmpty, "So, where would you like to place a cow?", "Sorry but you cant make a cow stand on another cow, it has to be an empty spot... Where do you choose? (e.g. input being \"a1\" goes to the board at A1).");
            game.board[user_chose] = new Cow(game.CurrentPlayer.MyType);
            if (game.IsThereAMillAt(user_chose))
            {
                return PlayOption.Shoot;
            }

            return PlayOption.None;
        }
    }
}
