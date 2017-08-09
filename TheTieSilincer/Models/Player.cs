using System;
using System.Collections.Generic;
using System.Text;
using TheTieSilincer.Interfaces;

namespace TheTieSilincer.Models
{
    public class Player
    {
        public Player(IShip ship)
        {
            this.Ship = ship;
        }

        public IShip Ship { get; private set; }

    }
}
