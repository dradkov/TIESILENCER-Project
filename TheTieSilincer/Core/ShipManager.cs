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

        private List<string> shipTypes;
        private List<string> weaponTypes;

        public List<EnemyShip> Ships { get; private set; }

        private List<string> enemySh;

        private int shipAddNumber = 3;

        private double spawnTimeInterval;

        private Random rnd;

        


        public ShipManager()
        {
            this.shipFactory = new ShipFactory();
            this.weaponFactory = new WeaponFactory();
            this.Ships = new List<EnemyShip>();
            this.shipTypes = Enum.GetValues(typeof(ShipType)).OfType<ShipType>().Select(v => v.ToString()).ToList();
            this.weaponTypes = Enum.GetValues(typeof(WeaponType)).Cast<WeaponType>().Select(v => v.ToString()).ToList();
            this.rnd = new Random();

            enemySh = Assembly.GetExecutingAssembly().GetTypes().Where(a => a != typeof(MotherShip) &&
            a.BaseType == typeof(EnemyShip)).Select(v => v.Name.ToString()).ToList();
                
            
                
            
  
        }


        public void ListenPlayerShipCoords(Satellite satellite)
        {
            satellite.SendData2 -= PlayerShipSendCoords;
            satellite.SendData2 += PlayerShipSendCoords;
        }

        public void PlayerShipSendCoords(object sender, EventArgs e)
        {
            Position position = ((Satellite)sender).Position;

            foreach (var ship in this.Ships)
            {
                if (ship.GetType() == typeof(KamikazeShip))
                {
                    (ship as KamikazeShip).Pos = position;
                }
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
            if (Ships.Count == 0)
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
           
            for (int i = 0; i < shipAddNumber; i++)
            {
                EnemyShip ship = BuildEnemyShip(this.enemySh[rnd.Next(0, enemySh.Count)]);
               
                if (CheckForOverlappingCoords(ship.Position.X, ship.Position.Y))
                {
                    i--;
                }
                else
                {
                    this.Ships.Add(ship);
                }              
            }
       }

        public EnemyShip BuildEnemyShip(string shipType)
        {

            if (shipTypes.Contains(shipType))
            {
                Type t = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(a => a.Name == shipType);

                List<Weapon> weapons = GetShipWeapons(t);

                return this.shipFactory.CreateEnemyShip(t, weapons);
            }

            return null;
        }

        public PlayerShip BuildPlayerShip(string shipType)
        {
            if (shipTypes.Contains(shipType))
            {
                Type t = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(a => a.Name == shipType);

                List<Weapon> weapons = GetShipWeapons(t);

                return this.shipFactory.CreatePlayerShip(t, weapons);
            }

            return null;
        }

        public List<Weapon> GetShipWeapons(Type shipType)
        {
            List<Weapon> weapons = new List<Weapon>();

            foreach (var weapon in weaponTypes.Where(v=> v.Contains(shipType.Name.Substring(0, 
                shipType.Name.Length - 4))))
                
            {
                  weapons.Add(weaponFactory.CreateWeapon(weapon));
            }

            return weapons;
        }


        public bool CheckForOverlappingCoords(int x, int y)
        {
            int overlap = 7;

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
                    this.Ships.Add(BuildEnemyShip("MotherShip"));
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
