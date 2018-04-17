using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba_9001.GameCode.Actions
{
    public class ActionPlace : IAction
    {
        // also requires update players cow positions
        public void PlayAction(Game game)
        {
            var user_chose = GameInput.GetBoardPosition(game, WhichPickingOption.ExpectingEmpty, "So, where would you like to place a cow?", "Sorry but you cant make a cow stand on another cow, it has to be an empty spot... Where do you choose? (e.g. input being \"a1\" goes to the board at A1).");
            game.board[user_chose] = new Cow(game.CurrentPlayer.MyType);

            // So we can store the number of cows placed
            game.CurrentPlayer.CowWasPlaced(user_chose);
            game.CurrentPlayer.AddCow(user_chose);
            if (Mill.IsThereAMillFor(game, user_chose)) 
            {
                game.GetAction(AvailableActions.Shoot).PlayAction(game);
            }

            //BEN: 
            //  -> current player: game.CurrentPlayer
            //  -> then we also have the opponent: game.OpponentPlayer
            //  Both of them have
            //    -> their name/type
            //    -> current list of cows
            //  Cows belonging to player
            //    -> Player (current or opponent above) .MyCowsPos -> positions I have cows
            //         OR
            //    -> search through game.board -> looking at Cow.Owner == Player.Type.<which ever options>
        }
    }
}
