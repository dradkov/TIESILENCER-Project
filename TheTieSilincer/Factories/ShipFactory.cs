using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TheTieSilincer.Models.Ships;

namespace TheTieSilincer.Factories
{
    public class ShipFactory
    {
        public EnemyShip CreateShip(string type)
        {
            Type typeOfShip = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(v => v.Name == type);

            EnemyShip ship = (EnemyShip)Activator.CreateInstance(typeOfShip);

            return ship;
        }
    }
    
}
