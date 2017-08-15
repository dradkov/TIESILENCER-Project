namespace TheTieSilincer.EventArguments
{
    using System;
    using TheTieSilincer.Models;

    public class PlayerPositionChangeEventArgs : EventArgs
    {
        public PlayerPositionChangeEventArgs(Position position)
        {
            this.Position = position;
        }

        public Position Position { get; private set; }
    }
}