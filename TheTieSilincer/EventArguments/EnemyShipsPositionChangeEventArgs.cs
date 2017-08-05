using System;
using System.Collections.Generic;
using TheTieSilincer.Models;

namespace TheTieSilincer.EventArguments
{
    public class EnemyShipsPositionChangeEventArgs : EventArgs
    {
        public EnemyShipsPositionChangeEventArgs(List<Position> positions)
        {
            this.enemyShipPositions = positions;
        }

        public List<Position> enemyShipPositions { get; private set; }

    }
}
