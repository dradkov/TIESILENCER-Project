using TheTieSilincer.Collisions;
using TheTieSilincer.Core.Managers;

namespace TheTieSilincer.Models.Satellite
{
    public class Satellite
    {
        public void StartTransmittingData(PlayerManager playerManager, ShipManager shipManager
            , BulletManager bulletManager, BulletCollision bulletCollision, ShipCollision shipCollision)
        {
            playerManager.SendPlayerPosition += shipManager.ReceivePlayerPosition;
            shipManager.SendShipsPositions += bulletManager.ReceiveShipsPositions;
            shipManager.SendNewWeapons += bulletManager.SubscribeForNewWeapons;
            bulletCollision.bulletCollision += bulletManager.OnBulletCollision;
            bulletCollision.bulletCollidesWithAShip += shipManager.OnBulletCollision;
            bulletCollision.bulletCollidesWithAShip += playerManager.OnBulletCollision;
            shipCollision.shipCollidesWithAnotherShip += shipManager.OnShipCollision;
            
        }
    }
}
