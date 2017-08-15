namespace TheTieSilincer.Models.Weapons
{
    using TheTieSilincer.Enums;

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
                OnGenBullets(new EventArguments.BulletCoordsEventArgs(weaselBullet, position));
                ShootCooldown = 0;
            }
            ShootCooldown += 0.25;
        }
    }
}