using Morabaraba9001.Enums;

namespace Morabaraba9001.Interfaces
{
    public interface IPlayer
    {
        Colour playerColour { get; } //check colour of player
        int CowsInBox { get; }
        IBoard PlayBoard { get; }

        (int, int) getActionInput(RefListens to); //for place and Shoot, second int will be null
        //Ref will check legality
        void placeCow(IBoard board, int to);
        void moveCow(IBoard board, int from, int to);
        void flyCow(IBoard board, int from, int to);
        void shootCow(IBoard board, int target);
    }
}
