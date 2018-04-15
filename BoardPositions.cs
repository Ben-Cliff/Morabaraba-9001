using System;
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

        public static int StringToIntPos(string s)      //Converts string board posiion to int value used in array data structures (OneAway)
        {
            switch (s)
            {                       
                //A
                case "a1": return 0;
                case "a4": return 1;
                case "a7": return 2;

                //B
                case "b2": return 3;
                case "b4": return 4;
                case "b6": return 5;

                //C
                case "c3": return 6;
                case "c4": return 7;
                case "c5": return 8;


                //D
                case "d1": return 9;
                case "d2": return 10;
                case "d3": return 11;
                case "d5": return 12;
                case "d6": return 13;
                case "d7": return 14;

                //E
                case "e3": return 15;
                case "e4": return 16;
                case "a5": return 17;

                //F
                case "f2": return 18;
                case "f4": return 19;
                case "f6": return 20;

                //G
                case "g1": return 21;
                case "g4": return 22;
                case "g7": return 23;

                    
            }

            throw new Exception("Oops that wasnt a board pos");
        }
    }
}
