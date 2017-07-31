using System;
using System.Linq;
using System.Reflection;
using TheTieSilincer.Models;
using TheTieSilincer.Models.Ships;

namespace TheTieSilincer.Factories
{
    public class ShipFactory
    {
        private Random rndGen;

        public ShipFactory()
        {
            this.rndGen = new Random();
        }
        public EnemyShip CreateShip(string type)
        {
            Type typeOfShip = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(v => v.Name == type);

            EnemyShip ship = (EnemyShip)Activator.CreateInstance(typeOfShip);

            ship.SetPosition(GenerateRandomShipPosition());

            return ship;
        }

        private Position GenerateRandomShipPosition()
        {
            int x = 0;
            int y = this.rndGen.Next(5, Console.WindowHeight - 1);

            Position pos = new Position(x, y);

            return pos;
        }
    }
    
}
