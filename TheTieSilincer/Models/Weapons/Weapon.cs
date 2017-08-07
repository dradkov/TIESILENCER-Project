using TheTieSilincer.Enums;
using TheTieSilincer.EventArguments;

namespace TheTieSilincer.Models.Weapons
{
    public abstract class Weapon
    {
        public event GenerateBulletsEventHandler GenBullets;

        protected Weapon(WeaponType weaponType, BulletType bulletType)
        {
            this.WeaponType = weaponType;
            this.BulletType = bulletType;
        }

        protected virtual void OnGenBullets(BulletCoordsEventArgs args)
        {
            GenBullets?.Invoke(this, args);
        }

        public WeaponType WeaponType { get; private set; }

        public BulletType BulletType { get; private set; }       
        
        public double ShootCooldown { get; protected set; }

        public abstract void AddBullets(Position position);
                 
    }
}
