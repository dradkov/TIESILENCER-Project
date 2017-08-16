namespace TheTieSilincer.EventArguments
{
    using System;
    using System.Collections.Generic;
    using TheTieSilincer.Models.Weapons;

    public class NewDestroyShipEventArgs : EventArgs
    {
        public NewDestroyShipEventArgs(int points)
        {
            this.Points = points;
        }

        public int Points { get; private set; }
    }
}