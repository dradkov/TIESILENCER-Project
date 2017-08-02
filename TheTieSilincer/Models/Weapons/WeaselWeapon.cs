using TheTieSilincer.Models.Bullets;

namespace TheTieSilincer.Models.Weapons
{
    public class WeaselWeapon : Weapon
    {
        public override void AddBullets(int x, int y)
        {
            if (ShootCooldown >= 2)
            {
                this.Bullets.Add(new WeaselBullet(x, y));
                ShootCooldown = 0;
            }
            ShootCooldown += 0.25;
        }
    }
}
