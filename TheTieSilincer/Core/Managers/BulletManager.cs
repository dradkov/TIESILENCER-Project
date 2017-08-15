namespace TheTieSilincer.Core.Managers
{
    using System.Collections.Generic;
    using System.Linq;
    using TheTieSilincer.Enums;
    using TheTieSilincer.EventArguments;
    using TheTieSilincer.Factories;
    using TheTieSilincer.Interfaces;
    using TheTieSilincer.Models.Bullets;

    public class BulletManager : IBulletManager
    {
        private IBulletFactory bulletFactory;

        private List<IBullet> bullets;

        public BulletManager()
        {
            bulletFactory = new BulletFactory();
            bullets = new List<IBullet>();
        }

        public IList<IBullet> Bullets
        {
            get
            {
                return new List<IBullet>(bullets);
            }
        }

        public void ReceiveShipsPositions(object sender, EnemyShipsPositionChangeEventArgs args)
        {
            bullets.Where(v => v.BulletType == BulletType.PlayerRocket).Select(v => (PlayerRocket)v)
                .ToList().ForEach(v => v.UpdatePositionByY(args.enemyShipPositions));
        }

        public void SubscribeForNewWeapons(object sender, NewWeaponsEventArgs args)
        {
            args.Weapons.ToList().ForEach(v => v.GenBullets += this.GeneratingBullets);
        }

        public void OnBulletCollision(object sender, BulletCollisionEventArgs args)
        {
            IBullet bullet = args.Bullet;

            bullet.Clear();
            bullets.Remove(bullet);
        }

        public void GeneratingBullets(object sender, BulletCoordsEventArgs args)
        {
            bullets.Add(bulletFactory.CreateBullet(args.BulletType, args.Position));
        }

        public void Clear()
        {
            bullets.Where(v => v.PreviousPosition != null).ToList().ForEach(v => v.Clear());
        }

        public void Draw()
        {
            bullets.RemoveAll(v => !v.InBounds());
            bullets.ForEach(v => v.Draw());
        }

        public void Update()
        {
            bullets.ForEach(v => v.Update());
        }
    }
}