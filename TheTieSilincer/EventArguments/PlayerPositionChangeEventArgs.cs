using System;
using TheTieSilincer.Models;

namespace TheTieSilincer.EventArguments
{
    public class PlayerPositionChangeEventArgs : EventArgs
    {
        public PlayerPositionChangeEventArgs(Position position)
        {
            this.Position = position;
        }

        public Position Position { get; private set; }
    }
}
