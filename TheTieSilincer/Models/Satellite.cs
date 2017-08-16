namespace TheTieSilincer.Models
{
    using TheTieSilincer.Collisions;
    using TheTieSilincer.Interfaces;

    public class Satellite
    {
        public void StartTransmittingData(IPlayerManager playerManager, IShipManager shipManager
            , IBulletManager bulletManager, BulletCollision bulletCollision, ShipCollision shipCollision)
        {
            playerManager.SendPlayerPosition += shipManager.ReceivePlayerPosition;
            shipManager.SendShipsPositions += bulletManager.ReceiveShipsPositions;
            shipManager.SendNewWeapons += bulletManager.SubscribeForNewWeapons;
            bulletCollision.bulletCollision += bulletManager.OnBulletCollision;
            bulletCollision.bulletCollidesWithAShip += shipManager.OnBulletCollision;
            bulletCollision.bulletCollidesWithAShip += playerManager.OnBulletCollision;
            shipCollision.shipCollidesWithAnotherShip += shipManager.OnShipCollision;

            shipManager.SendMessageWhenShipDestroyed += playerManager.UpdateScore;


        }
    }
}