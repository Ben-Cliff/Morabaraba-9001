using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba_9001.GameCode.Actions
{
    public class ActionPlace : IAction
    {
        // also requires update players cow positions
        public void PlayAction(Game game, List<BoardPos> input)
        {
            game.board[input[0]] = new Cow(game.CurrentPlayer.MyType);

            // So we can store the number of cows placed
            game.CurrentPlayer.CowWasPlaced(input[0]);
            if (Mill.IsThereAMillFor(game, input[0])) 
            {
                input.RemoveAt(0);
                game.GetAction(AvailableActions.Shoot).PlayAction(game, input);
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
