using System;
using TheTieSilincer.Core;
using TheTieSilincer.Models.Bullets;
using TheTieSilincer.Models.Ships;
using TheTieSilincer.Models.Weapons;

namespace TheTieSilincer.Collisions
{
    public class BulletCollision : Collision
    {
        private PlayerManager playerManager;

        private double distance;

        public BulletCollision(ShipManager shipManager , PlayerManager playerManager) : base(shipManager)
        {
            this.playerManager = playerManager;
        }

        private void CheckPlayerBulletCollisions()
        {
            for (int x = 0; x < this.shipManager.Ships.Count; x++)
            {
                var enemyShip = this.shipManager.Ships[x];

                foreach (Weapon weapon in this.playerManager.Player.Ship.Weapons)
                {
                    for (int y = 0; y < weapon.Bullets.Count; y++)
                    {
                        Bullet bullet = weapon.Bullets[y];
                        distance = Distance(bullet.Position, enemyShip.Position);

                        if(IsHit(distance, enemyShip.CollisionAOE))
                        {
                            this.shipManager.DecreaseArmor(enemyShip);
                            bullet.ClearBullet();
                            weapon.Bullets.RemoveAt(y);
                          //  y--;                       
                        }
                    }
                }
                if (!enemyShip.IsAlive())
                {

                    enemyShip.ClearShip(true); 


                    this.shipManager.Ships.RemoveAt(x);


                    x--;
                }
            }

        }

        private void CheckEnemyBulletCollisions()
        {
            var playerShip = this.playerManager.Player.Ship;

            foreach (var ship in this.shipManager.Ships)
            {
                foreach (var weapon in ship.Weapons)
                {
                    for (int i = 0; i < weapon.Bullets.Count; i++)
                    {
                        var currentBullet = weapon.Bullets[i];

                        distance = Distance(currentBullet.Position, playerShip.Position);

                        if (IsHit(distance, playerShip.CollisionAOE))
                        {
                           currentBullet.ClearBullet();
                           weapon.Bullets.RemoveAt(i);
                           i--;
                        }
                    }

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

        public override bool Intersect()
        {
            throw new NotImplementedException();
        }
    }
}
