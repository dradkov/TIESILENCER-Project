using TheTieSilincer.Models.Bullets;

namespace TheTieSilincer.Models.Weapons
{
    public class WeaselWeapon : Weapon
    {
        public override void AddBullets(int x, int y)
        {
            if (BulletTime % 2 == 0)
            {
                this.Bullets.Add(new WeaselBullet(x, y));
            }
            BulletTime += 0.25;
        }
    }
}
