namespace TheTieSilincer.Models.Weapons
{
    using TheTieSilincer.Enums;
    using TheTieSilincer.EventArguments;

    public class PlayerRocketLauncher : Weapon
    {
        private const WeaponType rocketLauncher = WeaponType.PlayerRocketLauncher;
        private const BulletType rocketType = BulletType.PlayerRocket;

        public PlayerRocketLauncher() : base(rocketLauncher, rocketType)
        {
        }

        public override void AddBullets(Position position)
        {
            OnGenBullets(new BulletCoordsEventArgs(rocketType, position));
        }
    }
}