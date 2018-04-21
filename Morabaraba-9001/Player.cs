using Morabaraba9001.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba9001
{
    class Player : IPlayer
    { 

        public Colour playerColour { get; private set; }

        public int CowsInBox { get; private set; }

        public Player(Colour player_id, int how_many)
        {
            playerColour = player_id;
            CowsInBox = how_many;
        }

        public void flyCow(IBoard board, int from, int to)
        {
            throw new NotImplementedException();
        }

        public (int, int) getActionInput()
        {
            throw new NotImplementedException();
        }

        public void moveCow(IBoard board, int from, int to)
        {
            throw new NotImplementedException();
        }

        public void placeCow(IBoard board, int to)
        {
            throw new NotImplementedException();
        }

        public void shootCow(IBoard board, int target)
        {
            throw new NotImplementedException();
        }
    }
}
