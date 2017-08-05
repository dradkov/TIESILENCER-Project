using TheTieSilincer.Enums;

namespace TheTieSilincer.Models.Weapons
{
    public abstract class Weapon
    {
        protected Weapon(WeaponType weaponType, BulletType bulletType)
        {
            this.WeaponType = weaponType;
            this.BulletType = bulletType;
        }

        public WeaponType WeaponType { get; private set; }

        public BulletType BulletType { get; private set; }       
        
        public double ShootCooldown { get; protected set; }

        public abstract void AddBullets(Position position);
                 
    }
}
