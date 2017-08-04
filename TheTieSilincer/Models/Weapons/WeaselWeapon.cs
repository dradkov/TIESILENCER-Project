using TheTieSilincer.Models.Bullets;
using TheTieSilincer.Enums;
using TheTieSilincer.Core.Managers;

namespace TheTieSilincer.Models.Weapons
{
    public class WeaselWeapon : Weapon
    {
        private const WeaponType weaselWeapon = WeaponType.WeaselWeapon;
        private const BulletType weaselBullet = BulletType.WeaselBullet;

        public WeaselWeapon() : base(weaselWeapon, BulletType.WeaselBullet)
        {
            
        }

        public override void AddBullets(Position position)
        {
            if (ShootCooldown >= 2)
            {
                BulletManager.AddBullet(weaselBullet, position);
                ShootCooldown = 0;
            }
            ShootCooldown += 0.25;
        }
    }
}
