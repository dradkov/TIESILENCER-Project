using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTieSilincer.Models.Bullets;
using TheTieSilincer.Enums;
using TheTieSilincer.Core.Managers;

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
            BulletManager.AddBullet(rocketType, position);
        }
    }
}
