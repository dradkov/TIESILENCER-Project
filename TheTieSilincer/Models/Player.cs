namespace TheTieSilincer.Models
{
    using TheTieSilincer.Interfaces;

    public class Player
    {
        public Player(IShip ship)
        {
            this.Ship = ship;
        }

        public IShip Ship { get; private set; }
    }
}