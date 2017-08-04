using TheTieSilincer.Models.Bullets;
using TheTieSilincer.Enums;
using TheTieSilincer.Core.Managers;

namespace TheTieSilincer.Models.Weapons
{
    public class PlayerWeapon : Weapon
    {
        private const WeaponType playerWeapon = WeaponType.PlayerWeapon;
        private const BulletType playerBullet = BulletType.PlayerBullet;

        public PlayerWeapon() : base(playerWeapon, playerBullet)
        {
           
        }

        public override void AddBullets(Position position)
        {
            BulletManager.AddBullet(playerBullet, position);
          
        }
    }
}
