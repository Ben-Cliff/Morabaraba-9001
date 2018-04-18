using Morabaraba_9001.GameCode.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba_9001.GameCode
{
    public class Game
    {
        public bool EndGame = false;
        public Dictionary<BoardPos, Cow> board = new Dictionary<BoardPos, Cow>();
       

        private List<Player> _players;
        public List<Player> Players {
            get
            {
                if (_players == null)
                {
                    // if players isnt a list of players in game we need to create the 2 players
                    _players = new List<Player>();

                    Players.Add(new Player(Player.Type.Red, 7));
                    Players.Add(new Player(Player.Type.Blue, 7));

                   
                }

                return _players;
            }
        }

        
       


            ////////////////////////////////////////--------------------------------------------------------------------------------------------------------///////////////////////////////////////////////

    
        private Player _player_used;
        public Player CurrentPlayer { get { return _player_used; }
        set { if (_player_used == null) _player_used = value; }
        }
        // We only look for the player after picking current player

        public Player OpponentPlayer { get { return Players[0]; } }


        private Dictionary<AvailableActions, IAction> _usable_actions = new Dictionary<AvailableActions, IAction>()
        {
            { AvailableActions.Place, new ActionPlace() },
            { AvailableActions.Shoot, new ActionShoot() },
            { AvailableActions.Move, new ActionMove() }
        };
        public IAction GetAction(AvailableActions act)
        {
            if (_usable_actions.ContainsKey(act))
            {
                return _usable_actions[act];
            }

            throw new Exception("We do not have that action currently: " + act.ToString());
        }

        // intances of
        //    game board
        //    player1, player2
        // F12 -> go to definition of where code is called
        public void Update()
        {
            //           # turn swap
            _player_used = Players[0];
            Players.RemoveAt(0);
            
            //           # move_posibilities check
            //           # place
            if (_player_used.CowsLeftToPlace > 0)
            {
                List<BoardPos> input = new List<BoardPos>();
                input.Add(GameInput.GetBoardPosition(this, WhichPickingOption.ExpectingEmpty, "So, where would you like to place a cow?", "Sorry but you cant make a cow stand on another cow, it has to be an empty spot... Where do you choose? (e.g. input being \"a1\" goes to the board at A1)."));

                if (Mill.IsThereAMillFor(this, input[0]))
                {
                    input.Add(GameInput.GetBoardPosition(this, WhichPickingOption.ExpectingEnemyCow, "You have formed a Mill! \n Enter the co ordinate of which enemy cow you would like to shoot (You cannot shoot other mills)", "You cannot shoot there. Try Again"));
                }

                GetAction(AvailableActions.Place).PlayAction(this, input);
            }
            else // this assumes when no cows left to place we go to move
            {
                List<BoardPos> input = new List<BoardPos>();
                if (this.CurrentPlayer.HowManyCows() == 3)         //              if 3 cows left: fly
                {
                    input.Add(GameInput.GetBoardPosition(this, WhichPickingOption.ExpectingAllyCow, "Enter the co ordinate of the cow you would like to fly", "You do not have any cows in that position. Try Again"));
                    input.Add(GameInput.GetBoardPosition(this, WhichPickingOption.ExpectingEmpty, "Enter the co ordinate you would like to fly your cow to", "You can only fly to empty spots. Try Again"));      // get choice of possibility - to

                    if (Mill.IsThereAMillFor(this, input[1]))
                    {
                        input.Add(GameInput.GetBoardPosition(this, WhichPickingOption.ExpectingEnemyCow, "You have formed a Mill! \n Enter the co ordinate of which enemy cow you would like to shoot (You cannot shoot other mills)", "You cannot shoot there. Try Again"));
                    }
                }
                else
                {
                    bool closeEnough = false;
                    OneAway proximity = new OneAway(BoardPos.a1, new List<BoardPos> { BoardPos.a4, BoardPos.b2, BoardPos.d1 });


                    while (closeEnough == false)
                    {

                        var frmm = GameInput.GetBoardPosition(this, WhichPickingOption.ExpectingAllyCow, "Enter the co ordinate of the cow you would like to move", "You do not have any cows in that position. Try Again");
                        var too = GameInput.GetBoardPosition(this, WhichPickingOption.ExpectingEmpty, "Enter the co ordinate you would like to move your cow to", "You can only move to empty spots, one unit away. Try Again");

                        int intposfrm = BoardWorker.PosToIntPos(frmm);
                        OneAway h = OneAway.Options[intposfrm];

                        if (h.Spot.Contains(too))  //OneAway.Options[0].Bigme == frmm)
                        {
                            //updating actual board

                            input.Add(frmm);
                            input.Add(too);

                            if (Mill.IsThereAMillFor(this, too))     //A check for a mill formed. Shoots if true
                            {
                                input.Add(GameInput.GetBoardPosition(this, WhichPickingOption.ExpectingEnemyCow, "You have formed a Mill! \n Enter the co ordinate of which enemy cow you would like to shoot (You cannot shoot other mills)", "You cannot shoot there. Try Again"));
                            }

                            closeEnough = true;
                        }




                    }
                }
                    //           # move
                    GetAction(AvailableActions.Move).PlayAction(this, input);
            }
            
            //           # win check

            // End of payer turn swap, put player back in behind so we keep it and dont garbage collect it and lose it
            Players.Add(_player_used);
        }


        ////////////////////////////////////////--------------------------------------------------------------------------------------------------------///////////////////////////////////////////////
        internal void EndGameMessage()
        {
            throw new NotImplementedException();
        }

        public void Draw()
        {
            // write console
            Console.WriteLine("    ---~~~===~~~---\n" + // Line between turns currently
                              "\t  \t1,2,3    4    5,6,7\n" +
                              "\t[A]\t{0}........{1}........{2}\n" +
                              "\t   \t|\\       |       /|\n" +
                              "\t[B]\t| {3}......{4}......{5} |\n" +
                              "\t   \t| |\\     |     /| |\n" +
                              "\t[C]\t| | {6}....{7}....{8} | |\n" +
                              "\t   \t| | |         | | |\n" +
                              "\t[D]\t{9}.{10}.{11}         {12}.{13}.{14}\n" +
                              "\t   \t| | |         | | | \n" +
                              "\t[E]\t| | {15}....{16}....{17} | |\n" +
                              "\t   \t| |/     |     \\| |\n" +
                              "\t[F]\t| {18}......{19}......{20} |\n" +
                              "\t   \t|/       |       \\|\n" +
                              "\t[G]\t{21}........{22}........{23}\n\n",
                              GetBoardToken(BoardPos.a1).ToString(), GetBoardToken(BoardPos.a4).ToString(), GetBoardToken(BoardPos.a7).ToString(),
                              GetBoardToken(BoardPos.b2).ToString(), GetBoardToken(BoardPos.b4).ToString(), GetBoardToken(BoardPos.b6).ToString(),
                              GetBoardToken(BoardPos.c3).ToString(), GetBoardToken(BoardPos.c4).ToString(), GetBoardToken(BoardPos.c5).ToString(),
                              GetBoardToken(BoardPos.d1).ToString(), GetBoardToken(BoardPos.d2).ToString(), GetBoardToken(BoardPos.d3).ToString(),
                              /* continued previous row */ GetBoardToken(BoardPos.d5).ToString(), GetBoardToken(BoardPos.d6).ToString(), GetBoardToken(BoardPos.d7).ToString(),
                              GetBoardToken(BoardPos.e3).ToString(), GetBoardToken(BoardPos.e4).ToString(), GetBoardToken(BoardPos.e5).ToString(),
                              GetBoardToken(BoardPos.f2).ToString(), GetBoardToken(BoardPos.f4).ToString(), GetBoardToken(BoardPos.f6).ToString(),
                              GetBoardToken(BoardPos.g1).ToString(), GetBoardToken(BoardPos.g4).ToString(), GetBoardToken(BoardPos.g7).ToString()
                              );

        }

        private string GetBoardToken(BoardPos at_pos)
        {
            if (board.ContainsKey(at_pos))
            {
                var cow = board[at_pos];
                return cow.Owner.ToString()[0].ToString();
            }

            return " ";
        }
    }
}
