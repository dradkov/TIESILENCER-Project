using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TheTieSilincer.Enums;
using TheTieSilincer.Factories;
using TheTieSilincer.Models;
using TheTieSilincer.Models.Ships;
using TheTieSilincer.Models.Weapons;

namespace TheTieSilincer.Core
{
    public class ShipManager
    {
        private ShipFactory shipFactory;
        private WeaponFactory weaponFactory;

        private ShipType[] shipTypes;
        private WeaponType[] weaponTypes;

        public List<EnemyShip> Ships { get; private set; }

        private int shipAddNumber = 5;
        private int overlap = 10;

        private double spawnTimeInterval;

        private Random rnd;

        public ShipManager()
        {
            this.shipFactory = new ShipFactory();
            this.weaponFactory = new WeaponFactory();
            this.Ships = new List<EnemyShip>();
            this.shipTypes = (ShipType[])Enum.GetValues(typeof(ShipType));
            this.weaponTypes = (WeaponType[])Enum.GetValues(typeof(WeaponType));
            this.rnd = new Random();
        }


        public void ListenPlayerShipCoords(Satellite satellite)
        {
            satellite.SendData -= PlayerShipSendCoords;
            satellite.SendData += PlayerShipSendCoords;
        }

        public void PlayerShipSendCoords(object sender, EventArgs e)
        {
            Position position = ((Satellite)sender).PlayerManager.Player.Ship.Position;

            foreach (var ship in this.Ships)
            {
                if (ship.GetType() == typeof(KamikazeShip))
                {
                    (ship as KamikazeShip).Pos = position;
                }
            }
        }

        public event EventHandler SendData;

        public void StartSendingDataFromEnemyShips()
        {
            if(SendData != null)
            {
                this.SendData(this, EventArgs.Empty);
            }
            
        }

        public void UpdateShips()
        {
            foreach (var ship in Ships)
            {
                ship.UpdateShip();
                ship.Weapons.ForEach(a => a.UpdateBullets());
            }

            SpawnMotherShip();
        }

        public void DrawShips()
        {
             if (Ships.Count <= 1)
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
                    currentShip.GenerateBullets();
                    currentShip.Weapons.ForEach(v => v.DrawBullets());
                }
            }
        }

        public void ClearShips()
        {
            this.Ships.ForEach(v => v.ClearShip());
            this.Ships.ForEach(v => v.Weapons.ForEach(a => a.ClearBullets()));
        }

        public void GenerateShips()
        {
            int a = 0;
            for (int i = 0; i < shipAddNumber; i++)
            {
                EnemyShip ship = null;
                ShipType shipType = this.shipTypes[rnd.Next(0, shipTypes.Length)];

                if(shipType != ShipType.MotherShip && shipType != ShipType.PlayerShip)
                {
                    ship = BuildEnemyShip(shipType);

                    if (CheckForOverlappingCoords(ship.Position.X, ship.Position.Y))
                    {
                        i--;
                        a++;
                    }
                    else
                    {
                        this.Ships.Add(ship);
                    }

                    if (a == 50)
                        break;
                }
                else
                {
                    i--;
                }
            }
       }

        public EnemyShip BuildEnemyShip(ShipType shipType)
        {
            if (shipTypes.Contains(shipType))
            {
                List<Weapon> weapons = GetShipWeapons(shipType);

                return this.shipFactory.CreateEnemyShip(shipType, weapons);
            }

            return null;
        }

        public PlayerShip BuildPlayerShip(ShipType shipType)
        {
            if (shipTypes.Contains(shipType))
            {                
                List<Weapon> weapons = GetShipWeapons(shipType);

                return this.shipFactory.CreatePlayerShip(shipType, weapons);
            }

            return null;
        }

        public List<Weapon> GetShipWeapons(ShipType shipType)
        {
            List<Weapon> weapons = new List<Weapon>();

            foreach (var weapon in weaponTypes.Where(v=> v.ToString().Contains(shipType.ToString().Substring(0, 
                shipType.ToString().Length - 4))))
                
            {
                  weapons.Add(weaponFactory.CreateWeapon(weapon));
            }

            return weapons;
        }


        public bool CheckForOverlappingCoords(int x, int y)
        {
           
            if(Ships.Any(v=> Math.Abs(v.Position.Y - y) < overlap))
            {
                return true;
            }


            return false;
        }

        public void DestroyShip(EnemyShip ship)
        {
            ship.ClearShip(true);
            this.Ships.Remove(ship);
        }

        private void SpawnMotherShip()
        {
            
            if(!Ships.Any(v=> v.GetType().Name == "MotherShip"))
            {
                if (spawnTimeInterval == 50)
                {
                    this.Ships.Add(BuildEnemyShip(ShipType.MotherShip));
                    spawnTimeInterval = 0;
                }
            }

            spawnTimeInterval++;
        }

        public void DecreaseArmor(EnemyShip ship)
        {
            ship.Armor--;
        }


    }
}
