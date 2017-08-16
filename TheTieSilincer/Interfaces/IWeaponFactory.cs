using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTieSilincer.Interfaces
{
    using TheTieSilincer.Enums;
    using TheTieSilincer.Models.Weapons;

    public interface IWeaponFactory
    {
        Weapon CreateWeapon(WeaponType weaponType);
    }
}
