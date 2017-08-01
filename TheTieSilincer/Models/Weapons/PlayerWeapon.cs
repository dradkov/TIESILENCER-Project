using TheTieSilincer.Models.Bullets;

namespace TheTieSilincer.Models.Weapons
{
    public class PlayerWeapon : Weapon
    {
        public override void AddBullets(int x, int y)
        {
            this.Bullets.Add(new PlayerBullet(x, y));
        }
    }
}
