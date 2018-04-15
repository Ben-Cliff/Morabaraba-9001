using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba_9001.GameCode
{
    public class Cow
    {
        private Player.Type _owner;
        public Player.Type Owner { get { return _owner; } }
        public Cow(Player.Type owner)
        {
            _owner = owner;
        }
    }
}
