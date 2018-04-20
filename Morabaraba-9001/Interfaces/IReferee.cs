using System;
namespace Morabaraba9001.Interfaces
{
    public interface IReferee
    {
        IPlayer player1 { get; }
        IPlayer player2 { get; }
        Colour WhoseTurn{ get; }

        bool checkIsvalidInputPlace(int to);
        bool checkIsvalidInputMove(int from, int to);
        bool checkIsvalidInputFly(int from, int to);
        bool checkIsvalidInputShoot(int from, int to);


        bool isAMillFormd(int to);


        void playTheTurn(); //Responisble for tunrover code + swop players

    }
}
