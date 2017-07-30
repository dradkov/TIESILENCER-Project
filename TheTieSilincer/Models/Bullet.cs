namespace TheTieSilincer.Models
{
    public class Bullet
    {
        public Bullet(int x, int y)
        {
            this.Position = new Position(x, y);
        }

        public Position Position { get; set; }

        public Position PreviousPosition { get; set; }

        public void UpdatePosition()
        {
            this.PreviousPosition = new Position(this.Position.X, this.Position.Y);
            this.Position.X--;
        }


    }
}
