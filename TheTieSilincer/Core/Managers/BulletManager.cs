using System.Collections.Generic;
using System.Linq;
using TheTieSilincer.Enums;
using TheTieSilincer.EventArguments;
using TheTieSilincer.Factories;
using TheTieSilincer.Models;
using TheTieSilincer.Models.Bullets;

namespace TheTieSilincer.Core.Managers
{
    public class BulletManager : Manager
    {
        private BulletFactory bulletFactory;

        private List<Bullet> bullets;
      
        public BulletManager()
        {
            bulletFactory = new BulletFactory();
            bullets = new List<Bullet>();
        }

        public IList<Bullet> Bullets
        {
            get
            {
                return new List<Bullet>(bullets);
            }
        }
 

        public void ReceiveShipsPositions(object sender, EnemyShipsPositionChangeEventArgs args)
        {
            bullets.Where(v => v.BulletType == BulletType.PlayerRocket).Select(v=> (PlayerRocket)v)
                .ToList().ForEach(v => v.UpdatePositionByY(args.enemyShipPositions));  
        }

        public void SubscribeForNewWeapons(object sender, NewWeaponsEventArgs args)
        {
            args.Weapons.ForEach(v => v.GenBullets += this.GeneratingBullets);
        }

        public void OnBulletCollision(object sender, BulletCollisionEventArgs args)
        {
            Bullet bullet = args.Bullet;

            bullet.Clear();
            bullets.Remove(bullet);
        }

        public void GeneratingBullets(object sender, BulletCoordsEventArgs args)
        {
            bullets.Add(bulletFactory.CreateBullet(args.BulletType, args.Position));
        }

        public override void Clear()
        {
            bullets.Where(v => v.PreviousPosition != null).ToList().ForEach(v => v.Clear());            
        }

        public override void Draw()
        {
            bullets.RemoveAll(v => !v.InBounds());
            bullets.ForEach(v => v.Draw());
        }   

        public override void Update()
        {
            bullets.ForEach(v => v.Update());
        }
        
    }
}
