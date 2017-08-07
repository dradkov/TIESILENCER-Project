using TheTieSilincer.Enums;
using TheTieSilincer.Core.Managers;
using TheTieSilincer.EventArguments;

namespace TheTieSilincer.Models.Weapons
{
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
