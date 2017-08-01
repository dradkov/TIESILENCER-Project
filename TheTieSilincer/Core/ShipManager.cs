using System;
using System.Collections.Generic;
using System.Linq;
using TheTieSilincer.Enums;
using TheTieSilincer.Factories;
using TheTieSilincer.Models.Ships;

namespace TheTieSilincer.Core
{
    public class ShipManager
    {
        private ShipFactory shipFactory;
        private WeaponFactory weaponFactory;

        private List<string> shipTypes;

        private List<EnemyShip> ships;
        private int shipAddNumber = 1;

        public ShipManager()
        {
            this.shipFactory = new ShipFactory();
            this.weaponFactory = new WeaponFactory();
            this.ships = new List<EnemyShip>();
            this.shipTypes = Enum.GetValues(typeof(ShipType)).OfType<string>().ToList();

            EnemyShip ship = this.shipFactory.CreateShip("MotherShip");
            ships.Add(ship);
        }

        public void UpdateShips()
        {
            foreach (var ship in ships)
            {
                ship.UpdateShip();
            }
        }

        public void DrawShips()
        {
            if(ships.Count == 1)
            {
                GenerateShips();
            }
            for (int i = 0; i < ships.Count; i++)
            {
                var currentShip = ships[i];
                if (!currentShip.InBounds())
                {
                    ships.RemoveAt(i);
                    i--;
                }
                else
                {
                    currentShip.DrawShip();
                }
            }
        }

        public void ClearShips()
        {
            foreach (var ship in ships)
            {
                ship.ClearShip();
            }
        }

        public void GenerateShips()
        {
            
            for (int i = 0; i < shipAddNumber; i++)
            {
                EnemyShip ship = this.shipFactory.CreateShip("WeaselShip");
                if (CheckForOverlappingCoords(ship.Position.X, ship.Position.Y))
                {
                    i--;
                }
                else
                {
                    this.ships.Add(ship);
                }              
            }
        }


        public bool CheckForOverlappingCoords(int x, int y)
        {
            int overlap = 17;

            if(ships.Any(v=> Math.Abs(v.Position.Y - y) < overlap))
            {
                return true;
            }


            return false;
        }
    }
}
