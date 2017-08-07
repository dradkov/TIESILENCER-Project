using System;
using System.Collections.Generic;
using TheTieSilincer.Models.Weapons;

namespace TheTieSilincer.EventArguments
{
    public class NewWeaponsEventArgs : EventArgs
    {
        public NewWeaponsEventArgs(List<Weapon> weapons)
        {
            this.Weapons = weapons;
        }

        public List<Weapon> Weapons { get; private set; }
    }
}
