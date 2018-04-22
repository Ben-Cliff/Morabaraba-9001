using System;
using Morabaraba9001.Enums;

namespace Morabaraba9001.Interfaces
{
    public interface IReferee
    {
        IPlayer player1 { get; }
        IPlayer player2 { get; }
        Colour WhoseTurn { get; }
        IBoard game_board { get; }
        IPlayer ImLookingAt { get; }
        bool EndGame {get;}

        bool checkIsvalidInputPlace(int to);
        bool checkIsvalidInputMove(int from, int to);
        bool checkIsvalidInputFly(int from, int to);
        bool checkIsvalidInputShoot(int target, bool millsAllowed);

        void ShowWhosTurn();
        bool isAMillFormd(int to);


        void playTheTurn(); //Responisble for tunrover code + swop players
        void CheckEndGame();

    }
}
