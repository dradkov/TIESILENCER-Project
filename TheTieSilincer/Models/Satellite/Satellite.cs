using TheTieSilincer.Core.Managers;
using TheTieSilincer.EventArguments;

namespace TheTieSilincer.Models.Satellite
{
    public delegate void PlayerPositionChangedEventHandler(object sender, PlayerPositionChangeEventArgs args);
    public delegate void EnemyShipsPositionChangedEventHandler(object sender, EnemyShipsPositionChangeEventArgs args);

    public class Satellite
    {
        public event PlayerPositionChangedEventHandler SendPlayerPosition;
        public event EnemyShipsPositionChangedEventHandler SendShipsPositions;

        public void OnPlayerPositionChange(PlayerPositionChangeEventArgs args)
        {
            SendPlayerPosition?.Invoke(this, args);
        }

        public void OnEnemyShipsPositionChange(EnemyShipsPositionChangeEventArgs args)
        {
            SendShipsPositions?.Invoke(this, args);
        }

        public void ReicevePlayerPosition(object sender, PlayerPositionChangeEventArgs args)
        {
            OnPlayerPositionChange(args);
        }

        public void ReceiveShipsPositions(object sender, EnemyShipsPositionChangeEventArgs args)
        {
            OnEnemyShipsPositionChange(args);
        }

        public void StartTransmittingMessages(PlayerManager playerManager, ShipManager shipManager
            , BulletManager bulletManager)
        {
            playerManager.SendPlayerPosition += this.ReicevePlayerPosition;
            this.SendPlayerPosition += shipManager.ReceivePlayerPosition;
            shipManager.SendShipsPositions += this.ReceiveShipsPositions;
            this.SendShipsPositions += bulletManager.ReceiveShipsPositions;
        }
    }
}
