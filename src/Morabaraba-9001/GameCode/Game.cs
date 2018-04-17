﻿using Morabaraba_9001.GameCode.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba_9001.GameCode
{
    public class Game
    {
        public bool EndGame = false;
        public Dictionary<BoardPos, Cow> board = new Dictionary<BoardPos, Cow>();

        public List<Player> Players;

        private Player _player_used;
        public Player CurrentPlayer { get { return _player_used; } }
        // We only look for the player after picking current player
        public Player OpponentPlayer { get { return Players[0]; } }

        private ActionPlace _action_place;
        public ActionPlace ActionPlace
        {
            get
            {
                if (_action_place == null)
                {
                    _action_place = new ActionPlace();
                }

                return _action_place;
            }
        }

        private ActionShoot _action_shoot;
        public ActionShoot ActionShoot
        {
            get
            {
                if (_action_shoot == null)
                {
                    _action_shoot = new ActionShoot();
                }

                return _action_shoot;
            }
        }

        // intances of
        //    game board
        //    player1, player2
        public void Update()
        {
            if (Players == null)
            {
                Players = new List<Player>();
                Players.Add(new Player(Player.Type.Red, 7));
                Players.Add(new Player(Player.Type.Blue, 7));
            }

            //           # turn swap
            _player_used = Players[0];
            Players.RemoveAt(0);

            // Helper for playing actions
            PlayOption answer = PlayOption.None;

            //           # move_posibilities check

            //           # place
            if (true) // TODO: move_possibilities
                answer = ActionPlace.PlayAction(this);
            //           # move

            // Check if anything else needs to run
            switch (answer)
            {
                case PlayOption.Shoot: ActionShoot.PlayAction(this); break;
            }

            //           # win check

            // End of payer turn swap
            Players.Add(_player_used);
        }

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

        public bool IsThereAMillAt(BoardPos b)
        {
            return false;
        }
    }
}
