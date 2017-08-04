using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TheTieSilincer.Enums;
using TheTieSilincer.Models;
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

        public Ship CreateShip(ShipType shipType, List<Weapon> weapons)
        {
            Type typeOfShip = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(v => v.Name == shipType.ToString());

            Ship ship = (Ship)Activator.CreateInstance(typeOfShip, weapons);

            if (ship.Position == null)
            {
                ship.SetPosition(GenerateRandomShipPosition());
            }

            return ship;
        }

        private Position GenerateRandomShipPosition()
        {
            int y = 0;
            int x = this.rndGen.Next(5, Console.WindowWidth - 25);

            Position pos = new Position(y, x);

            return pos;
        }
    }

}
