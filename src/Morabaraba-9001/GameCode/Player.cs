using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba_9001.GameCode
{
    public class Player
    {
        List<BoardPos> MyCowsPos = new List<BoardPos>();
    //Place cow

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
