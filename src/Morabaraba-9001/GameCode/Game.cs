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
                Players.Add(new Player(Player.Type.Red));
                Players.Add(new Player(Player.Type.Blue));
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
        }

        public bool IsThereAMillAt(BoardPos b)
        {
            return true;
        }
    }
}
