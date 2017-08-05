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

        public  List<Bullet> bullets;

        public BulletManager()
        {
            bulletFactory = new BulletFactory();
            bullets = new List<Bullet>();
        }

        public void ReceiveShipsPositions(object sender, EnemyShipsPositionChangeEventArgs args)
        {          
            bullets.Where(v => v.BulletType == BulletType.PlayerRocket).Select(v=> (PlayerRocket)v)
                .ToList().ForEach(v => v.UpdatePositionByY(args.enemyShipPositions));  
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
