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
        private int shipAddNumber = 2;

        public List<EnemyShip> Ships
        {
            get
            {
                return ships;
            }

            set
            {
                ships = value;
            }
        }

        public ShipManager()
        {
            this.shipFactory = new ShipFactory();
            this.weaponFactory = new WeaponFactory();
            this.Ships = new List<EnemyShip>();
            this.shipTypes = Enum.GetValues(typeof(ShipType)).OfType<string>().ToList();

            EnemyShip ship = this.shipFactory.CreateShip("MotherShip");
            Ships.Add(ship);
        }

        public void UpdateShips()
        {
            foreach (var ship in Ships)
            {
                ship.UpdateShip();
            }
        }

        public void DrawShips()
        {
            if(Ships.Count == 1)
            {
                GenerateShips();
            }
            for (int i = 0; i < Ships.Count; i++)
            {
                var currentShip = Ships[i];
                if (!currentShip.InBounds())
                {
                    Ships.RemoveAt(i);
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
            foreach (var ship in Ships)
            {
                ship.ClearShip();
            }
        }

        public void GenerateShips()
        {
            
            //for (int i = 0; i < shipAddNumber; i++)
            //{
            //    EnemyShip ship = this.shipFactory.CreateShip("WeaselShip");
            //    if (CheckForOverlappingCoords(ship.Position.X, ship.Position.Y))
            //    {
            //        i--;
            //    }
            //    else
            //    {
            //        this.Ships.Add(ship);
            //    }              
            //}

            for (int i = 0; i < shipAddNumber; i++)
            {
                EnemyShip ship1 = this.shipFactory.CreateShip("KamikazeShip");

                this.Ships.Add(ship1);

            }
        }


        public bool CheckForOverlappingCoords(int x, int y)
        {
            int overlap = 17;

            if(Ships.Any(v=> Math.Abs(v.Position.Y - y) < overlap))
            {
                return true;
            }


            return false;
        }
    }
}
