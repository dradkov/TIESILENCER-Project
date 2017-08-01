namespace TheTieSilincer.Models.Ships
{
    public abstract class EnemyShip : Ship
    {
        protected EnemyShip()
        {       

        }

        public double MovementTime { get; protected set;  }

        public abstract void GenerateBullets();   


               
    }
}
