namespace TheTieSilincer.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TheTieSilincer.Enums;
    using TheTieSilincer.Interfaces;
    using TheTieSilincer.Models;
    using TheTieSilincer.Models.Weapons;

    public class ShipFactory : IShipFactory
    {
        private Random rndGen;

        public ShipFactory()
        {
            this.rndGen = new Random();
        }

        public IShip CreateShip(ShipType shipType, IList<Weapon> weapons)
        {
            Type typeOfShip = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(v => v.Name == shipType.ToString());

            IShip ship = (IShip)Activator.CreateInstance(typeOfShip, weapons);

            if (ship.Position == null)
            {
                ship.Position = (GenerateRandomShipPosition());
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