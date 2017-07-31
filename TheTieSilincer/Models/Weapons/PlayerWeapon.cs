using System;
using TheTieSilincer.Models.Bullets;

namespace TheTieSilincer.Models.Weapons
{
    public class PlayerWeapon : Weapon
    {
        public override void AddBullets(int x, int y)
        {
            this.Bullets.Add(new PlayerBullet(x, y));
        }

        public override void ClearBullets()
        {
            for (int i = 0; i < this.Bullets.Count; i++)
            {
                Bullet currentBullet = this.Bullets[i];
                if (currentBullet.PreviousPosition != null)
                {
                    this.Bullets[i].ClearBullet();
                }

            }
        }

        public override void DrawBullets()
        {
            for (int i = 0; i < this.Bullets.Count; i++)
            {
                if (!Bullets[i].InBounds())
                {
                    Bullets.RemoveAt(i);
                    i--;
                }
                else
                {
                    this.Bullets[i].DrawBullet();
                }
            }
        }

        public override void UpdateBullets()
        {
            for (int i = 0; i < this.Bullets.Count; i++)
            {
                Bullet currentBullet = this.Bullets[i];
                currentBullet.UpdatePosition();
            }
        }
    }
}
