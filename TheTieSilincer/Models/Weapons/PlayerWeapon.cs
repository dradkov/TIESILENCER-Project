namespace TheTieSilincer.Models.Weapons
{
    using TheTieSilincer.Enums;
    using TheTieSilincer.EventArguments;

    public class PlayerWeapon : Weapon
    {
        private const WeaponType playerWeapon = WeaponType.PlayerWeapon;
        private const BulletType playerBullet = BulletType.PlayerBullet;

        public PlayerWeapon() : base(playerWeapon, playerBullet)
        {
        }

        public override void AddBullets(Position position)
        {
            OnGenBullets(new BulletCoordsEventArgs(playerBullet, position));
        }
    }
}