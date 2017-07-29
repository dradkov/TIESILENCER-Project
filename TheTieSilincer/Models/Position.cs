namespace TheTieSilincer.Models
{
    public class Position
    {
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; protected set; }
        public int Y { get; protected set; }
    }
}
