using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba_9001.GameCode
{
    public class OneAway
    {
        private static List<OneAway> _opciones;
        public static List<OneAway> Options
        {
            get
            {
                if (_opciones == null)
                {
                    _opciones = new List<OneAway>();
                    //A 1 4 7
                    _opciones.Add(new OneAway(BoardPos.a1, new List<BoardPos> { BoardPos.a4, BoardPos.b2, BoardPos.d1 }));   //still need to create oneaway constructor to have its 
                    _opciones.Add(new OneAway(BoardPos.a4, new List<BoardPos> { BoardPos.a1, BoardPos.b4, BoardPos.a7 })); 
                    _opciones.Add(new OneAway(BoardPos.a7, new List<BoardPos> { BoardPos.a4, BoardPos.b6, BoardPos.d7 })); 

                    //B 2 4 6

                    _opciones.Add(new OneAway(BoardPos.b2, new List<BoardPos> { BoardPos.a1, BoardPos.b4, BoardPos.c3, BoardPos.d2 }));   
                    _opciones.Add(new OneAway(BoardPos.b4, new List<BoardPos> { BoardPos.a4, BoardPos.b2, BoardPos.b6, BoardPos.c4 })); 
                    _opciones.Add(new OneAway(BoardPos.b6, new List<BoardPos> { BoardPos.a7, BoardPos.b4, BoardPos.c5, BoardPos.d6 }));

                    // C 3 4 5        
                    _opciones.Add(new OneAway(BoardPos.c3, new List<BoardPos> { BoardPos.b2, BoardPos.c4, BoardPos.d3 }));   
                    _opciones.Add(new OneAway(BoardPos.c4, new List<BoardPos> { BoardPos.b4, BoardPos.c3, BoardPos.c5 })); 
                    _opciones.Add(new OneAway(BoardPos.c5, new List<BoardPos> { BoardPos.b6, BoardPos.c4, BoardPos.d5 })); 


                    //D 1 2 3      5 6 7

                    _opciones.Add(new OneAway(BoardPos.d1, new List<BoardPos> { BoardPos.a1, BoardPos.d2, BoardPos.g1}));   
                    _opciones.Add(new OneAway(BoardPos.d2, new List<BoardPos> { BoardPos.d1, BoardPos.d3, BoardPos.b2, BoardPos.f2 })); 
                    _opciones.Add(new OneAway(BoardPos.d3, new List<BoardPos> { BoardPos.d2, BoardPos.c3, BoardPos.e3}));
                    _opciones.Add(new OneAway(BoardPos.d5, new List<BoardPos> { BoardPos.d6, BoardPos.c5, BoardPos.e5})); 
                    _opciones.Add(new OneAway(BoardPos.d6, new List<BoardPos> { BoardPos.d7, BoardPos.d5, BoardPos.b6, BoardPos.f6 })); 
                    _opciones.Add(new OneAway(BoardPos.d7, new List<BoardPos> { BoardPos.a7, BoardPos.d6, BoardPos.g7 }));

                    //E 3 4 5
                    _opciones.Add(new OneAway(BoardPos.e3, new List<BoardPos> { BoardPos.d3, BoardPos.f2, BoardPos.e4})); 
                    _opciones.Add(new OneAway(BoardPos.e4, new List<BoardPos> { BoardPos.e3, BoardPos.f4, BoardPos.e5 })); 
                    _opciones.Add(new OneAway(BoardPos.e5, new List<BoardPos> { BoardPos.d5, BoardPos.f6, BoardPos.e4 }));

                    //F 2 4 6
                    _opciones.Add(new OneAway(BoardPos.f2, new List<BoardPos> { BoardPos.d2, BoardPos.g1, BoardPos.f4 , BoardPos.e3})); 
                    _opciones.Add(new OneAway(BoardPos.f4, new List<BoardPos> { BoardPos.e4, BoardPos.g4, BoardPos.f2, BoardPos.f6 })); 
                    _opciones.Add(new OneAway(BoardPos.f6, new List<BoardPos> { BoardPos.d6, BoardPos.g7, BoardPos.f4, BoardPos.e5}));

                   // G 1 4 7
                    _opciones.Add(new OneAway(BoardPos.g1, new List<BoardPos> { BoardPos.d1, BoardPos.f2, BoardPos.g4}));
                    _opciones.Add(new OneAway(BoardPos.g4, new List<BoardPos> { BoardPos.g1, BoardPos.f4, BoardPos.g7}));
                    _opciones.Add(new OneAway(BoardPos.g7, new List<BoardPos> { BoardPos.g4, BoardPos.f6, BoardPos.d7 }));







                    //TO BE COMPLETED
                }
                return _opciones;

            }
        }

        public BoardPos Bigme { get; private set; }
        public List<BoardPos> Spot { get; private set; }

        public OneAway(BoardPos me , List<BoardPos> spots)
        {
            Bigme = me;
            Spot = spots;
        }
    }
}
