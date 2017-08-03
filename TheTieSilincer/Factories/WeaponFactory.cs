using System;
using System.Linq;
using System.Reflection;
using TheTieSilincer.Enums;
using TheTieSilincer.Models.Weapons;

namespace TheTieSilincer.Factories
{
    public class WeaponFactory
    {
        public Weapon CreateWeapon(WeaponType weaponType)
        {
            Type typeOfWeapon = Assembly.GetExecutingAssembly().
                GetTypes().FirstOrDefault(a => a.Name == weaponType.ToString());

            Weapon weapon = (Weapon)Activator.CreateInstance(typeOfWeapon);

            return weapon;
        }
    }
}
