using TheTieSilincer.Models.Bullets;

namespace TheTieSilincer.Models.Weapons
{
    public class WeaselWeapon : Weapon
    {
        private double bulletTime = 0;

        public override void AddBullets(int x, int y)
        {
            if(bulletTime % 2 == 0)
            {
                this.Bullets.Add(new WeaselBullet(x, y));
            }

            bulletTime += 0.25;
        }

        public override void ClearBullets()
        {
            this.Bullets.ForEach(v => v.ClearBullet());
        }

        public override void DrawBullets()
        {
            this.Bullets.RemoveAll(v => !v.InBounds());
            this.Bullets.ForEach(v => v.DrawBullet());
        }

        public override void UpdateBullets()
        {
            this.Bullets.ForEach(v => v.UpdatePosition());
        }
    }
}
