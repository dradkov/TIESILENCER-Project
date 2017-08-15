namespace TheTieSilincer.Models
{
    using TheTieSilincer.EventArguments;

    public delegate void PlayerPositionChangeEventHandler(object sender, PlayerPositionChangeEventArgs args);

    public delegate void EnemyShipsPositionChangeEventHandler(object sender, EnemyShipsPositionChangeEventArgs args);

    public delegate void NewWeaponsEventHandler(object sender, NewWeaponsEventArgs args);

    public delegate void BulletCollisionEventHandler(object sender, BulletCollisionEventArgs args);

    public delegate void GenerateBulletsEventHandler(object sender, BulletCoordsEventArgs args);

    public delegate void ShipCollisionEventHandler(object sender, ShipCollisionEventArgs args);
}