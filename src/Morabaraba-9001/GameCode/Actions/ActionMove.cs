using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba_9001.GameCode.Actions
{
    public class ActionMove : IAction
    {
        public void PlayAction(Game game)
            {
                GameCode.BoardPos frmm;
                GameCode.BoardPos too;
                if (game.CurrentPlayer.HowManyCows() == 3)         //              if 3 cows left: fly
                    {
                    GameCode.BoardPos frm = GameInput.GetBoardPosition(game, WhichPickingOption.ExpectingAllyCow, "Enter the co ordinate of the cow you would like to fly", "You do not have any cows in that position. Try Again");
                    GameCode.BoardPos to = GameInput.GetBoardPosition(game, WhichPickingOption.ExpectingEmpty, "Enter the co ordinate you would like to fly your cow to", "You can only fly to empty spots. Try Again");      // get choice of possibility - to

                    game.CurrentPlayer.RemoveACow(to);
                    game.CurrentPlayer.AddCow(to);    // updating player's list of cows

                    game.board[frm] = new Cow(Player.Type.None);
                    game.board[to] = new Cow(game.CurrentPlayer.MyType);    //updating actual board

                    if (Mill.IsThereAMillFor(game, to))     //A check for a mill formed. Shoots if true
                    { game.GetAction(AvailableActions.Shoot).PlayAction(game); }
                }

                else
                    { bool closeEnough = false;
                    OneAway proximity = new OneAway(BoardPos.a1, new List<BoardPos> { BoardPos.a4, BoardPos.b2, BoardPos.d1 });

                
                    while (closeEnough == false)
                        {
                        
                        frmm = GameInput.GetBoardPosition(game, WhichPickingOption.ExpectingAllyCow, "Enter the co ordinate of the cow you would like to move", "You do not have any cows in that position. Try Again");
                        too = GameInput.GetBoardPosition(game, WhichPickingOption.ExpectingEmpty, "Enter the co ordinate you would like to move your cow to", "You can only move to empty spots, one unit away. Try Again");

                    int intposfrm = BoardWorker.PosToIntPos(frmm);
                    OneAway h = OneAway.Options[intposfrm];

                    if (h.Spot.Contains(too))  //OneAway.Options[0].Bigme == frmm)
                    {


                        game.CurrentPlayer.RemoveACow(too);
                        game.CurrentPlayer.AddCow(too);    // updating player's list of cows

                        game.board[frmm] = new Cow(Player.Type.None);
                        game.board[too] = new Cow(game.CurrentPlayer.MyType);    //updating actual board

                        if (Mill.IsThereAMillFor(game, too))     //A check for a mill formed. Shoots if true
                        { game.GetAction(AvailableActions.Shoot).PlayAction(game); }

                        closeEnough = true;
                    }
                    
                   


                        }


                
                }



            


                //                  # check
                //                      # shoot
                throw new NotImplementedException();
            }

        public void Test(Game g, BoardPos b)
        {

        }
    }
}
