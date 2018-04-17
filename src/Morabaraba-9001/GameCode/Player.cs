using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba_9001.GameCode
{
    public class Player
    {
        public enum Type
        {
            Red,
            Blue,
            None
        }
        
        // This is weird just for the naming, etc
        private Player.Type _type;
        public Player.Type MyType { get { return _type; } }

        public Player(Player.Type t, int _cows_to_place)
        {
            _type = t;
            CowsLeftToPlace = _cows_to_place;
        }

        List<BoardPos> MyCowsPos = new List<BoardPos>();
        //Place cow

        public int CowsLeftToPlace { get; private set; }
        public void CowWasPlaced(BoardPos where_placed)
        {
            if (CowsLeftToPlace == 0)
            {
                throw new Exception("There were no cows left I could place.");
            }
            else
            {
                MyCowsPos.Add(where_placed);
                CowsLeftToPlace -= 1;
            }
        }

        public void AddCow(BoardPos pos)
        {
            if (MyCowsPos.Contains(pos))
            {
                throw new Exception("There is already have a cow there!");
            }

            MyCowsPos.Add(pos);
        }

        public bool DoIHaveACowAt(BoardPos pos)
        {
            return MyCowsPos.Contains(pos);
        }

        public void RemoveACow(BoardPos pos)
        {
            if (!MyCowsPos.Contains(pos))
            {
                throw new Exception("We dont actually have a cow there by the way");
            }

            MyCowsPos.Remove(pos);
        }
    }
}
