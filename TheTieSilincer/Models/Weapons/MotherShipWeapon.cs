using System;
using TheTieSilincer.Models.Bullets;
using TheTieSilincer.Enums;
using TheTieSilincer.Core.Managers;

namespace TheTieSilincer.Models.Weapons
{
    public class MotherShipWeapon : Weapon
    {
        private const WeaponType msWeapon = WeaponType.MotherShipWeapon;
        private const BulletType msBullet = BulletType.MSBullet;

        public MotherShipWeapon() : base(msWeapon, msBullet)
        {
           
        }

        public override void AddBullets(Position position)
        {
            BulletManager.AddBullet(msBullet, position);
        }
    }
}
