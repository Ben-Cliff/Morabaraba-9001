using Morabaraba9001.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba9001
{
    public class Referee : IReferee
    {
        public IPlayer player1 { get; private set; }

        public IPlayer player2 { get; private set; }

        public Colour WhoseTurn { get; private set; }

        public IBoard game_board { get; private set; }

        public bool EndGame { get; private set; }

        public Referee(IBoard board, IPlayer firstPlayer, IPlayer secondPlayer)
        {
            game_board = board;
            if (player1.playerColour == Colour.Light)
            {
                Console.WriteLine("Referee: Sorry light player, you cant be first.");
                player2 = firstPlayer;
                player1 = secondPlayer;
            }
            else
            {
                player1 = firstPlayer;
                player2 = secondPlayer;
            }

            WhoseTurn = Colour.Dark;
        }

        public bool checkIsvalidInputFly(int from, int to)
        {
            throw new NotImplementedException();
        }

        public bool checkIsvalidInputMove(int from, int to)
        {
            throw new NotImplementedException();
        }

        public bool checkIsvalidInputPlace(int to)
        {
            throw new NotImplementedException();
        }

        public bool checkIsvalidInputShoot(int from, int to)
        {
            throw new NotImplementedException();
        }

        public bool isAMillFormd(int to)
        {
            // First find all mills containing "to"
            List<List<int>> final_checks = new List<List<int>>();
            foreach (var m in game_board.Mills)
            {
                if (m.Contains(to))
                {
                    final_checks.Add(m);
                }
            }

            // Go through final_checks for that point
            while (!(final_checks.Count == 0))
            {
                var this_check = final_checks[0];
                this_check.RemoveAt(0);
                if ((game_board.Positions[to] == game_board.Positions[this_check[0]]) &&
                    (game_board.Positions[to] == game_board.Positions[this_check[1]]) &&
                    (game_board.Positions[to] == game_board.Positions[this_check[2]]))
                    {
                        return true;
                    }

            }

            return false;
        }

        public void playTheTurn()
        {
            IPlayer ImLookingAt = null;
            switch (WhoseTurn)
            {
                case Colour.Dark:
                    ImLookingAt = player1;
                    Console.WriteLine("Referee: It is your turn Ms. Dark.");
                    break;
                case Colour.Light:
                    ImLookingAt = player2;
                    Console.WriteLine("Referee: Ah, Mr. Light, step forwards since it's you!");
                    break;
            }

            //Check player can acutally move

            Console.WriteLine("Referee: Cool, so lets see what you can do...");
            if (ImLookingAt.CowsInBox > 0)
            {
                Console.WriteLine("Referee: you still have cows in your box, so you are going to place one in an open spot on the board, where shall that be?");
                var userGave = ImLookingAt.getActionInput(Enums.RefListens.SinglePosition);
                bool ref_test1 = false;
                if (game_board.Positions[userGave.Item1] != Colour.None)
                {
                    ref_test1 = true;
                }

                while (ref_test1)
                {
                    Console.WriteLine("Referee: Erm... No, it has to be empty please, pick another spot!");
                    userGave = ImLookingAt.getActionInput(Enums.RefListens.SinglePosition);
                    if (game_board.Positions[userGave.Item1] == Colour.None)
                    {
                        ref_test1 = false;
                    }
                }

                Console.WriteLine("Referee: I have accepted that, you can take a cow from your box and put it on the game board, go, go");
                ImLookingAt.placeCow(game_board, userGave.Item1);
            }
            else if (game_board.PlayerCowCount(ImLookingAt.playerColour) == 3)
            {
                throw new Exception("Fly move not implemented yet.");
            }
            else
            {
                throw new Exception("Normal move not implemented yet.");
            }

            // Mill check

            // win check
            //Just use return; to finish the function

            Console.WriteLine("Referee: Neat, well done. You completed your turn");
            switch (WhoseTurn)
            {
                case Colour.Dark: WhoseTurn = Colour.Light; break;
                case Colour.Light: WhoseTurn = Colour.Dark; break;
            }
        }
    }
}
