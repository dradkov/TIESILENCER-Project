namespace TheTieSilincer.EventArguments
{
    using System;
    using System.Collections.Generic;
    using TheTieSilincer.Models.Weapons;

    public class NewWeaponsEventArgs : EventArgs
    {
        public NewWeaponsEventArgs(IList<Weapon> weapons)
        {
            this.Weapons = weapons;
        }

        public IList<Weapon> Weapons { get; private set; }
    }
}