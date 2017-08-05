using TheTieSilincer.Models.Bullets;
using TheTieSilincer.Core.Managers;
using System.Collections.Generic;

namespace TheTieSilincer.Collisions
{
    public class BulletCollision : Collision
    {
        private PlayerManager playerManager;
        private BulletManager bulletManager;

        public BulletCollision(ShipManager shipManager , PlayerManager playerManager
            , BulletManager bulletManager) : base(shipManager)
        {
            this.playerManager = playerManager;
            this.bulletManager = bulletManager;
        }

        public void CheckPlayerBulletCollisions()
        {

            for (int y = 0; y < shipManager.Ships.Count; y++)
            {
                var enemyShip = this.shipManager.Ships[y];

                for (int x = 0; x < bulletManager.bullets.Count; x++)
                {
                    var currentBullet = bulletManager.bullets[x];

                    if (!currentBullet.BulletType.ToString().StartsWith("Player")) continue;

                    distance = Distance(currentBullet.Position, enemyShip.Position);

                    if (IsHit(distance, enemyShip.CollisionAOE))
                    {
                        this.shipManager.DecreaseArmor(enemyShip);
                        currentBullet.Clear();
                        bulletManager.bullets.RemoveAt(x);
                        x--;
                    }
                }

                if (!enemyShip.IsAlive())
                {
                    enemyShip.Clear(true);
                    this.shipManager.Ships.RemoveAt(y);
                    y--;
                }
            }
        }

        public void CheckEnemyBulletCollisions()
        {
            var playerShip = this.playerManager.Player.Ship;

            for (int y = 0; y < bulletManager.bullets.Count; y++)
            {
                var currentBullet = bulletManager.bullets[y];

                if (currentBullet.BulletType.ToString().StartsWith("Player")) continue;

                distance = Distance(currentBullet.Position, playerShip.Position);

                if (IsHit(distance, playerShip.CollisionAOE))
                {
                    currentBullet.Clear();
                    bulletManager.bullets.RemoveAt(y);
                    y--;
                }


            }
        }


        private bool IsHit(double distance, int aoe)
        {
            if(distance < aoe)
            {
                return true;
            }

            return false;
        }


        public override void CheckForCollisions()
        {
           CheckEnemyBulletCollisions();
           CheckPlayerBulletCollisions();
        }

    }
}
