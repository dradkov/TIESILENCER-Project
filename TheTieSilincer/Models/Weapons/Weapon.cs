using System.Collections.Generic;
using System.Linq;
using TheTieSilincer.Enums;
using TheTieSilincer.Models.Bullets;

namespace TheTieSilincer.Models.Weapons
{
    public abstract class Weapon
    {
        protected Weapon(WeaponType weaponType, BulletType bulletType)
        {
            this.Bullets = new List<Bullet>();
            this.WeaponType = weaponType;
            this.BulletType = bulletType;
        }

        public WeaponType WeaponType { get; private set; }

        public BulletType BulletType { get; private set; }
       
        public List<Bullet> Bullets { get; protected set; }
        
        public double ShootCooldown { get; protected set; }

        public abstract void AddBullets(Position position);
                 
     // public virtual void ClearBullets()
     // {
     //     Bullets.Where(v => v.PreviousPosition != null).ToList().ForEach(v => v.Clear());
     // }
     //
     // public virtual void DrawBullets()
     // {
     //     this.Bullets.RemoveAll(v => !v.InBounds());
     //     this.Bullets.ForEach(v => v.Draw());
     // }
     //
     // public virtual void UpdateBullets()
     // {
     //     this.Bullets.ForEach(v => v.UpdatePositionByX());
     //    // this.Bullets.ForEach(v => v.UpdatePositionByY());
     // }
    }
}
