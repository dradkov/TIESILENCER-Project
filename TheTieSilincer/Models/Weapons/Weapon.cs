using System.Collections.Generic;
using System.Linq;
using TheTieSilincer.Models.Bullets;

namespace TheTieSilincer.Models.Weapons
{
    public abstract class Weapon
    {
        protected Weapon()
        {
            this.Bullets = new List<Bullet>();
        }

        public List<Bullet> Bullets { get; protected set; }

        public double BulletTime { get; protected set; }

        public abstract void AddBullets(int x, int y);
                 
        public virtual void ClearBullets()
        {
            Bullets.Where(v => v.PreviousPosition != null).ToList().ForEach(v => v.ClearBullet());
        }

        public virtual void DrawBullets()
        {
            this.Bullets.RemoveAll(v => !v.InBounds());
            this.Bullets.ForEach(v => v.DrawBullet());
        }

        public virtual void UpdateBullets()
        {
            this.Bullets.ForEach(v => v.UpdatePosition());
        }
    }
}
