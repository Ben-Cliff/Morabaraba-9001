using System;
using System.Collections.Generic;

namespace Morabaraba9001.Interfaces
{
    public interface IBoard
    {
        List<Colour> Positions { get; }
        List<List<int>> Mills { get; }
   

        //Player is current player peforming adjustments
        //Positions are checked by ref before actions take place
        //

        bool AdjustBoard_Place(int position, Colour player);
        bool AdjustBoard_Fly( int positionFrom, int positionTo, Colour player);
        bool AdjustBoard_Move(int positionFrom, int positionTo, Colour player);
        bool AdjustBoard_Shoot(int targer, Colour player);
        int PlayerCowCount(Colour c);


    }
}
