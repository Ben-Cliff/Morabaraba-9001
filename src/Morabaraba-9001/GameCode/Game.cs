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

        // intances of
        //    game board
        //    player1, player2
        public void Update()
        {
//           # turn swap
//           # move_posibilities check
//
//           # place
//           # move

//           # win check
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
