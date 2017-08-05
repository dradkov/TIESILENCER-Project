using System;
using TheTieSilincer.Models.Bullets;
using TheTieSilincer.Enums;
using TheTieSilincer.Core.Managers;
using TheTieSilincer.EventArguments;

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
            OnGenBullets(new BulletCoordsEventArgs(msBullet, position));
            //BulletManager.AddBullet(msBullet, position);
        }
    }
}
