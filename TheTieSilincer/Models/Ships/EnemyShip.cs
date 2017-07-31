namespace TheTieSilincer.Models.Ships
{
    public abstract class EnemyShip : Ship
    {
        protected EnemyShip()
        {       

        }

        public abstract void GenerateBullets();
               
    }
}
