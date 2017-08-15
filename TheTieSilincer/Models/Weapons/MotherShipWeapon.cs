namespace TheTieSilincer.Models.Weapons
{
    using TheTieSilincer.Enums;
    using TheTieSilincer.EventArguments;

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
        }
    }
}