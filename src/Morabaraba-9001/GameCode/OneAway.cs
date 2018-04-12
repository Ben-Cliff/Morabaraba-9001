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
                    _opciones.Add(new OneAway(BoardPos.a1, new List<BoardPos> { BoardPos.a4, BoardPos.b2, BoardPos.d1 }));   //still need to create oneaway constructor to have its 

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
