using TheTieSilincer.Models.Bullets;
using System.Collections.Generic;
using TheTieSilincer.Models;
using TheTieSilincer.EventArguments;

namespace TheTieSilincer.Collisions
{
    public class BulletCollision : Collision
    {
        public event BulletCollisionEventHandler bulletCollision;
        public event ShipCollisionEventHandler bulletCollidesWithAShip;

        private void OnBulletCollision(BulletCollisionEventArgs args)
        {
            bulletCollision?.Invoke(this, args);
        }

        private void OnBulletCollidesWithAShip(ShipCollisionEventArgs args)
        {
            bulletCollidesWithAShip?.Invoke(this, args);
        }

        private void CheckPlayerBulletCollisions(IList<Bullet> bullets, IList<Ship> ships)
        {
            for (int y = 0; y < ships.Count; y++)
            {
                var enemyShip = ships[y];

                for (int x = 0; x < bullets.Count; x++)
                {
                    var currentBullet = bullets[x];

                    if (!currentBullet.BulletType.ToString().StartsWith("Player")) continue;

                    distance = Distance(currentBullet.Position, enemyShip.Position);

                    if (IsHit(distance, enemyShip.CollisionAOE))
                    {
                        OnBulletCollision(new BulletCollisionEventArgs(currentBullet));
                        OnBulletCollidesWithAShip(new ShipCollisionEventArgs(enemyShip, false));
                        bullets.RemoveAt(x);
                        x--;
                    }
                }
            }
        }

        public void CheckEnemyBulletCollisions(IList<Bullet> bullets, Ship playerShip)
        {

            for (int y = 0; y < bullets.Count; y++)
            {
                var currentBullet = bullets[y];

                if (currentBullet.BulletType.ToString().StartsWith("Player")) continue;

                distance = Distance(currentBullet.Position, playerShip.Position);

                if (IsHit(distance, playerShip.CollisionAOE))
                {
                    OnBulletCollision(new BulletCollisionEventArgs(currentBullet));
                    OnBulletCollidesWithAShip(new ShipCollisionEventArgs(playerShip, false));
                    bullets.RemoveAt(y);
                    y--;
                }
            }

        }


        private bool IsHit(double distance, int aoe)
        {
            if (distance < aoe)
            {
                return true;
            }

            return false;
        }

        public void CheckForCollisions(IList<Bullet> bullets, IList<Ship> ships, Ship playerShip)
        {
            CheckPlayerBulletCollisions(bullets, ships);
            CheckEnemyBulletCollisions(bullets, playerShip);
        }

    }
}
