using Morabaraba_9001.GameCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba_9001
{
    public class Mill
    {
        private BoardPos _a, _b, _c;
        public BoardPos A { get { return _a; } }
        public BoardPos B { get { return _b; } }
        public BoardPos C { get { return _c; } }
        public Mill(BoardPos a, BoardPos b, BoardPos c)
        {
            _a = a;
            _b = b;
            _c = c;
        }

        private static List<Mill> _mills;
        public static List<Mill> GetAll { get
            {
                if (_mills == null)
                {
                    _mills = new List<Mill>();

                    _mills.Add(new Mill(BoardPos.a1, BoardPos.a4, BoardPos.a7));
                    _mills.Add(new Mill(BoardPos.b2, BoardPos.b4, BoardPos.b6));
                    _mills.Add(new Mill(BoardPos.c3, BoardPos.c4, BoardPos.c5));
                    _mills.Add(new Mill(BoardPos.d1, BoardPos.d2, BoardPos.d3));

                    _mills.Add(new Mill(BoardPos.d5, BoardPos.d6, BoardPos.d7));
                    _mills.Add(new Mill(BoardPos.e3, BoardPos.e4, BoardPos.e5));
                    _mills.Add(new Mill(BoardPos.f2, BoardPos.f4, BoardPos.f6));
                    _mills.Add(new Mill(BoardPos.g1, BoardPos.g4, BoardPos.g7));

                    _mills.Add(new Mill(BoardPos.a1, BoardPos.d1, BoardPos.g1));
                    _mills.Add(new Mill(BoardPos.b2, BoardPos.d2, BoardPos.f2));
                    _mills.Add(new Mill(BoardPos.c3, BoardPos.d3, BoardPos.e3));
                    _mills.Add(new Mill(BoardPos.a4, BoardPos.b4, BoardPos.c4));

                    _mills.Add(new Mill(BoardPos.e4, BoardPos.f4, BoardPos.g4));
                    _mills.Add(new Mill(BoardPos.c5, BoardPos.d5, BoardPos.e5));
                    _mills.Add(new Mill(BoardPos.b6, BoardPos.d6, BoardPos.f6));
                    _mills.Add(new Mill(BoardPos.a7, BoardPos.d7, BoardPos.g7));

                    _mills.Add(new Mill(BoardPos.a1, BoardPos.b2, BoardPos.c3));
                    _mills.Add(new Mill(BoardPos.c5, BoardPos.b6, BoardPos.a7));
                    _mills.Add(new Mill(BoardPos.g1, BoardPos.f2, BoardPos.e3));
                    _mills.Add(new Mill(BoardPos.e5, BoardPos.f6, BoardPos.g7));
                }

                return _mills;
            }
        }
    }
}
