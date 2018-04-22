using Morabaraba9001.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

/*
 * How to create an instance of the interface:
 *  - Create new class
 *  - Inherit from the interface be adding requirements -> e.g. ": IBoard" for this one
 *    - e.g:
 *      -> Add text " : IBoard" after "public class GameBoard"
 *      -> Put the cursor (marker where you are typing) inside IBoard, press "crtl + ."
 *          -> implement interface is what you select
 *      -> For the data we added to the interface (e.g. Positions) here is what it makes:
 *         public List<Colour> Positions => throw new NotImplementedException();
 *         This is called an "accessor" that is implemented "without block body"
 *          -> more on that "settings" -> "text editor" -> "c#" -> "code style" -> "general"
 *         We wont need more on that, we replace " => throw new NotImplementedException();" with " { get; private set; }"
 *         In the past I was making a private instance but this isn't needed currently
 *      -> lastly create the constructor sharing what it needs to inherit
 *         -> remember the structure needed for potential tests
 *         -> e.g. the board takes a list of the current board, an empty list = an empty board
 *         -> In the constructor create the necessary data thats needed
 *           -> Note: Notes will be using "Note:" and can be potential changes, adjustments and/or fixes we want in the project, this just maps them in our code for us
 */

namespace Morabaraba9001
{
    public class GameBoard : IBoard
    {
        public List<Colour> Positions { get; private set; }

        public List<List<int>> Mills { get; private set; }

        public List<string> PositionNames { get; private set; }

        public GameBoard(List<Colour> newPositions)
        {
            Positions = newPositions;
            PositionNames = new List<string>() { "a1", "a4", "a7", "d7", "g7", "g4", "g1", "d1", "b2" , "b4", "b6", "d6", "f6", "f4", "f2", "d2", "c3", "c4", "c5", "d5", "e5" , "e4" , "e3", "d3"  };




            // Create the mills this board uses
            // Note: should we also input it like the board's current state for testing? Since technically we never change mills.
            Mills = new List<List<int>>();

            // Horizontal
            Mills.Add(new List<int>() { 0, 1, 2 });
            Mills.Add(new List<int>() { 8, 9, 10});
            Mills.Add(new List<int>() { 16, 17, 18 });
            Mills.Add(new List<int>() { 7, 15, 23 });
            Mills.Add(new List<int>() { 19, 11, 3 });
            Mills.Add(new List<int>() { 22, 21, 20 });
            Mills.Add(new List<int>() { 14, 13, 12 });
            Mills.Add(new List<int>() { 6, 5, 4 });

            // Vertical
            Mills.Add(new List<int>() { 0, 7, 6 });
            Mills.Add(new List<int>() { 8, 15, 14 });
            Mills.Add(new List<int>() { 16, 23, 22 });
            Mills.Add(new List<int>() { 1, 9, 17 });
            Mills.Add(new List<int>() { 21, 13, 5 });
            Mills.Add(new List<int>() { 18, 19, 20 });
            Mills.Add(new List<int>() { 10, 11, 12 });
            Mills.Add(new List<int>() { 2, 3, 4 });

            // Diagonal
            Mills.Add(new List<int>() { 0, 8, 16 });
            Mills.Add(new List<int>() { 18, 10, 2 });
            Mills.Add(new List<int>() { 6, 14, 22 });
            Mills.Add(new List<int>() { 4, 12, 20 });
        }

        public bool AdjustBoard_Fly(int positionFrom, int positionTo, Colour player)
        {
            Positions[positionFrom] = Colour.None;
            Positions[positionTo] = player;
            return true;
        }

        public bool AdjustBoard_Move(int positionFrom, int positionTo, Colour player)
        {
            Positions[positionFrom] = Colour.None;
            Positions[positionTo] = player;
            return true;
        }

        public bool AdjustBoard_Place(int position, Colour player)
        {
            Positions[position] = player;
            return true;
        }

        public bool AdjustBoard_Shoot(int targer, Colour player)
        {
            throw new NotImplementedException();
        }

        public int PlayerCowCount(Colour c)
        {
            throw new NotImplementedException();
        }
    }
}
