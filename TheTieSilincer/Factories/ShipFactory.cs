using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TheTieSilincer.Models;
using TheTieSilincer.Models.Ships;
using TheTieSilincer.Models.Weapons;

namespace TheTieSilincer.Factories
{
    public class ShipFactory
    {
        private Random rndGen;

        public ShipFactory()
        {
            this.rndGen = new Random();
        }
        public EnemyShip CreateEnemyShip(Type typeOfShip, List<Weapon> weapons)
        {
           // Type typeOfShip = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(v => v.Name == type);

            EnemyShip ship = (EnemyShip)Activator.CreateInstance(typeOfShip, weapons);

            if(ship.Position == null)
            {
                ship.SetPosition(GenerateRandomShipPosition());
            }
           
            return ship;
        }

        public PlayerShip CreatePlayerShip(Type typeOfShip, List<Weapon> weapons)
        {

            PlayerShip ship = (PlayerShip)Activator.CreateInstance(typeOfShip, weapons);

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
