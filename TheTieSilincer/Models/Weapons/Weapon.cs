using System.Collections.Generic;
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

        public abstract void AddBullets(int x, int y);

        public abstract void DrawBullets();

        public abstract void ClearBullets();

        public abstract void UpdateBullets();
    }
}
