using System;
using System.Collections.Generic;
using System.Text;

namespace TheTieSilincer.Models
{
    public class Player
    {
        public Player()
        {
            this.Ship = new PlayerShip();
        }

        public PlayerShip Ship { get; private set; }

    }
}
