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

        public BulletCollision(ShipManager shipManager , PlayerManager playerManager) : base(shipManager)
        {
            this.playerManager = playerManager;
        }

        public void CheckPlayerBulletCollisions()
        {
            for (int x = 0; x < this.shipManager.Ships.Count; x++)
            {
                var enemyShip = this.shipManager.Ships[x];

                foreach (Weapon weapon in this.playerManager.Player.Ship.Weapons)
                {
                    for (int y = 0; y < weapon.Bullets.Count; y++)
                    {
                        Bullet bullet = weapon.Bullets[y];
                        double distance = Distance(bullet.Position, enemyShip.Position);

                        if(IsHit(distance, enemyShip.CollisionAOE))
                        {
                            this.shipManager.DecreaseArmor(enemyShip);
                            if(!enemyShip.IsAlive())
                            {
                                this.shipManager.DestroyShip(enemyShip);
                                
                               // y--;
                               // x--;
                            }

                            bullet.ClearBullet();
                            weapon.Bullets.RemoveAt(y);
                        }
                    }
                }
            }

        }


        public bool IsHit(double distance, int aoe)
        {
            if(distance < aoe)
            {
                return true;
            }

            return false;
        }


        public override void CheckForCollisions()
        {
            throw new NotImplementedException();
        }

        public override bool Intersect()
        {
            throw new NotImplementedException();
        }
    }
}
