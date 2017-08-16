namespace TheTieSilincer.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using TheTieSilincer.Enums;
    using TheTieSilincer.Interfaces;
    using TheTieSilincer.Models.Weapons;

    public class WeaponFactory:IWeaponFactory
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