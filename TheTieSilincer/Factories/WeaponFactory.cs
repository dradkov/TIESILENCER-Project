using System;
using System.Linq;
using System.Reflection;
using TheTieSilincer.Models.Weapons;

namespace TheTieSilincer.Factories
{
    public class WeaponFactory
    {
        public Weapon CreateWeapon(string weaponType)
        {
            Type typeOfWeapon = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(a => a.Name == weaponType);

            Weapon weapon = (Weapon)Activator.CreateInstance(typeOfWeapon);
            // i asked where do isave em? the bullets ? in a game class orwhat
            return weapon;
        }
    }
}
