namespace TheTieSilincer.Models
{
    public abstract class GameObject
    {
        public Position Position { get; protected set; }

        public Position PreviousPosition { get; protected set; }

        public abstract void Draw();

        public abstract void Update(Position nextDirection = null);

        public abstract void Clear(bool destroyed = false);

        public abstract bool InBounds(Position nextDirection = null);

        public void SetPosition(Position pos)
        {
            this.Position = pos;
        }

        public void SetPreviousPosition(Position pos)
        {
            this.PreviousPosition = pos;
        }
    }
}
