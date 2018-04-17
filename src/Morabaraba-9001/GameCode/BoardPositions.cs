﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba_9001.GameCode
{
    public enum BoardPos
    {
        a1,                    a4,                         a7,
                b2,            b4,                  b6,
                           c3, c4, c5,
        d1,     d2,        d3,     d5,              d6,     d7,
                           e3, e4, e5,
                f2,            f4,                  f6,
        g1,                    g4,                          g7
    }

    public static class BoardWorker
    {
        public static BoardPos StringToBoardPos(string s)
        {
            switch (s)
            {                       //If edit to accept caps, look_here
                //A
                case "a1": return BoardPos.a1;
                case "a4": return BoardPos.a4;
                case "a7": return BoardPos.a7;

                //B
                case "b2": return BoardPos.b2;
                case "b4": return BoardPos.b4;
                case "b6": return BoardPos.b6;

                //C
                case "c3": return BoardPos.c3;
                case "c4": return BoardPos.c4;
                case "c5": return BoardPos.c5;


                //D
                case "d1": return BoardPos.d1;
                case "d2": return BoardPos.d2;
                case "d3": return BoardPos.d3;
                case "d5": return BoardPos.d5;
                case "d6": return BoardPos.d6;
                case "d7": return BoardPos.d7;

                //E
                case "e3": return BoardPos.e3;
                case "e4": return BoardPos.e4;
                case "a5": return BoardPos.e5;

                //F
                case "f2": return BoardPos.f2;
                case "f4": return BoardPos.f4;
                case "f6": return BoardPos.f6;

                //G
                case "g1": return BoardPos.g1;
                case "g4": return BoardPos.g4;
                case "g7": return BoardPos.g7;

                    /* NOTE: No IKE A G6 ;]*/
            }

            throw new Exception("Oops that wasnt a board pos");
        }

        public static int PosToIntPos(BoardPos s)      //Converts string board posiion to int value used in array data structures (OneAway)
        {
            switch (s)
            {
                //A
                case BoardPos.a1: return 0;
                case BoardPos.a4: return 1;
                case BoardPos.a7: return 2;

                //B
                case BoardPos.b2: return 3;
                case BoardPos.b4: return 4;
                case BoardPos.b6: return 5;

                //C
                case BoardPos.c3: return 6;
                case BoardPos.c4: return 7;
                case BoardPos.c5: return 8;


                //D
                case BoardPos.d1: return 9;
                case BoardPos.d2: return 10;
                case BoardPos.d3: return 11;
                case BoardPos.d5: return 12;
                case BoardPos.d6: return 13;
                case BoardPos.d7: return 14;

                //E
                case BoardPos.e3: return 15;
                case BoardPos.e4: return 16;
                case BoardPos.e5: return 17;
                    
                //F
                case BoardPos.f2: return 18;
                case BoardPos.f4: return 19;
                case BoardPos.f6: return 20;
                    
                //G
                case BoardPos.g1: return 21;
                case BoardPos.g4: return 22;
                case BoardPos.g7: return 23;


            }

            throw new Exception("Oops that wasnt a board pos");
        }
        //public  bool IsThereAMillAt(BoardPos p)
        //    {
        //    List<BoardPos[]> Mills = new List<BoardPos[]>();
        //    Mills = [[ BoardPos.a1, BoardPos.a4, BoardPos.a7],[BoardPos.b2, BoardPos.b4, BoardPos.b6],[BoardPos.c3, BoardPos.c4, BoardPos.c5],[BoardPos.d1, BoardPos.d2, BoardPos.d3],[BoardPos.d5, BoardPos.d6, BoardPos.d7],[BoardPos.e3, BoardPos.e4, BoardPos.e4],[BoardPos.f2, BoardPos.f4, BoardPos.f6],[BoardPos.g1, BoardPos.g4, BoardPos.g7],
        //        [BoardPos.a1, BoardPos.d1, BoardPos.g1],[BoardPos.b2, BoardPos.d2, BoardPos.f2],[BoardPos.c3, BoardPos.d3, BoardPos.e3],[BoardPos.a4, BoardPos.b4, BoardPos.c4],[BoardPos.e4, BoardPos.f4, BoardPos.g4],[BoardPos.c5, BoardPos.d5, BoardPos.e5],[BoardPos.b6, BoardPos.d6, BoardPos.f6],[BoardPos.a7, BoardPos.d7, BoardPos.g7],
        //        [BoardPos.a1, BoardPos.b2, BoardPos.c3],[BoardPos.a7, BoardPos.b6, BoardPos.c5],[BoardPos.e5, BoardPos.f6, BoardPos.g7],[BoardPos.e3, BoardPos.f2, BoardPos.g1]];
        //    //Mill List above
        //
        //    //Checking these mills based on input needs to be finished
        //    }
    }
}
