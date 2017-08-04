using System;
using System.Collections.Generic;
using System.Text;

namespace TheTieSilincer.Models
{
    public class Player
    {
        public Player(Ship ship)
        {
            this.Ship = ship;
        }

        public Ship Ship { get; private set; }

    }
}
