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
            {
                case "a1": return BoardPos.a1;
                case "a4": return BoardPos.a4;
                case "a7": return BoardPos.a7;
            }

            throw new Exception("Oops that wasnt a board pos");
        }
    }
}
