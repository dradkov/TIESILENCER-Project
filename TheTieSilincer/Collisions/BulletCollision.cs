using TheTieSilincer.Models.Bullets;
using TheTieSilincer.Core.Managers;
using System.Collections.Generic;

namespace TheTieSilincer.Collisions
{
    public class BulletCollision : Collision
    {
        private PlayerManager playerManager;

        public BulletCollision(ShipManager shipManager , PlayerManager playerManager) : base(shipManager)
        {
            this.playerManager = playerManager;
        }

        public void CheckPlayerBulletCollisions(List<Bullet> bullets)
        {

            for (int y = 0; y < shipManager.Ships.Count; y++)
            {
                var enemyShip = this.shipManager.Ships[y];

                for (int x = 0; x < bullets.Count; x++)
                {
                    var currentBullet = bullets[x];

                    if (!currentBullet.BulletType.ToString().StartsWith("Player")) continue;

                    distance = Distance(currentBullet.Position, enemyShip.Position);

                    if (IsHit(distance, enemyShip.CollisionAOE))
                    {
                        this.shipManager.DecreaseArmor(enemyShip);
                        currentBullet.Clear();
                        bullets.RemoveAt(x);
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

        public void CheckEnemyBulletCollisions(List<Bullet> bullets)
        {
            var playerShip = this.playerManager.Player.Ship;

            for (int y = 0; y < bullets.Count; y++)
            {
                var currentBullet = bullets[y];

                if (currentBullet.BulletType.ToString().StartsWith("Player")) continue;

                distance = Distance(currentBullet.Position, playerShip.Position);

                if (IsHit(distance, playerShip.CollisionAOE))
                {
                    currentBullet.Clear();
                    bullets.RemoveAt(y);
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


        public override void CheckForCollisions(List<Bullet> bullets = null)
        {
           CheckEnemyBulletCollisions(bullets);
           CheckPlayerBulletCollisions(bullets);
        }

    }
}
