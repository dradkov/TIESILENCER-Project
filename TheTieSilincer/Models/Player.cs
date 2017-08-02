using System;
using System.Collections.Generic;
using System.Text;

namespace TheTieSilincer.Models
{
    public class Player
    {
        public Player(PlayerShip ship)
        {
            this.Ship = ship;
        }

        public PlayerShip Ship { get; private set; }

    }
}
