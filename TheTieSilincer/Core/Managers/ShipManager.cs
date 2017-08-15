namespace TheTieSilincer.Core.Managers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TheTieSilincer.Enums;
    using TheTieSilincer.EventArguments;
    using TheTieSilincer.Factories;
    using TheTieSilincer.Interfaces;
    using TheTieSilincer.Models;
    using TheTieSilincer.Models.Ships;
    using TheTieSilincer.Models.Weapons;

    public class ShipManager : IShipManager
    {
        public event EnemyShipsPositionChangeEventHandler SendShipsPositions;

        public event NewWeaponsEventHandler SendNewWeapons;

        private IShipFactory shipFactory;
        private WeaponFactory weaponFactory;

        private ShipType[] shipTypes;
        private WeaponType[] weaponTypes;

        private List<IShip> ships;

        private int shipAddNumber = 5;
        private int overlap = 10;

        private double motherShipSpawnTime;

        private Random rnd;

        public ShipManager()
        {
            this.shipFactory = new ShipFactory();
            this.weaponFactory = new WeaponFactory();
            this.ships = new List<IShip>();
            this.shipTypes = (ShipType[])Enum.GetValues(typeof(ShipType));
            this.weaponTypes = (WeaponType[])Enum.GetValues(typeof(WeaponType));
            this.rnd = new Random();
        }

        public IList<IShip> Ships
        {
            get
            {
                return new List<IShip>(ships);
            }
        }

        private void OnEnemyShipsPositionChange(EnemyShipsPositionChangeEventArgs args)
        {
            SendShipsPositions?.Invoke(this, args);
        }

        private void OnNewWeaponsCreated(NewWeaponsEventArgs args)
        {
            SendNewWeapons?.Invoke(this, args);
        }

        public void OnShipCollision(object sender, ShipCollisionEventArgs args)
        {
            var f = ships.FirstOrDefault(v => v.Position.X == args.Ship.Position
            .X && v.Position.Y == args.Ship.Position.Y);

            if (f != null)
            {
                if (args.ShipCollidesWithPlayerShip)
                {
                    DestroyShip(f);
                }
                else
                {
                    f.PreviousPosition = f.Position;
                    f.Clear();

                    if (args.Ship.Position.Y <= args.Ship2.Position.Y)
                    {
                        f.Position.Y--;
                    }
                    else
                    {
                        f.Position.Y++;
                    }
                }
            }
        }

        public void OnBulletCollision(object sender, ShipCollisionEventArgs args)
        {
            IShip ship = args.Ship;

            if (ship.GetType().BaseType == typeof(EnemyShip))
            {
                if (!ship.IsAlive())
                {
                    DestroyShip(ship);
                }
                else
                {
                    DecreaseArmor(ship);
                }
            }
        }

        public void ReceivePlayerPosition(object sender, PlayerPositionChangeEventArgs args)
        {
            foreach (var ship in this.ships)
            {
                if (ship.GetType() == typeof(KamikazeShip))
                {
                    (ship as KamikazeShip).Pos = args.Position;
                }
            }
        }

        public void Update()
        {
            foreach (var IShip in ships)
            {
                IShip.Update();
            }

            List<Position> shipsPositions = this.ships.Select(v => v.Position).ToList();
            OnEnemyShipsPositionChange(new EnemyShipsPositionChangeEventArgs(shipsPositions));

            SpawnMotherShip();
        }

        public void Draw()
        {
            if (ships.Count <= 1)
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
                    currentShip.Draw();
                }
            }
        }

        public void Clear()
        {
            this.ships.ForEach(v => v.Clear());
        }

        public void GenerateShips()
        {
            int a = 0;
            for (int i = 0; i < shipAddNumber; i++)
            {
                IShip ship = null;
                ShipType shipType = this.shipTypes[rnd.Next(0, shipTypes.Length)];

                if (shipType != ShipType.MotherShip && shipType != ShipType.PlayerShip)
                {
                    ship = BuildShip(shipType);

                    if (CheckForOverlappingCoords(ship.Position.X, ship.Position.Y))
                    {
                        i--;
                        a++;
                    }
                    else
                    {
                        this.ships.Add(ship);
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

        public IShip BuildShip(ShipType shipType)
        {
            if (shipTypes.Contains(shipType))
            {
                IList<Weapon> weapons = GetShipWeapons(shipType);

                OnNewWeaponsCreated(new NewWeaponsEventArgs(weapons));

                return this.shipFactory.CreateShip(shipType, weapons);
            }

            return null;
        }

        private List<Weapon> GetShipWeapons(ShipType shipType)
        {
            List<Weapon> weapons = new List<Weapon>();

            string s = shipType.ToString().Substring(0,
                shipType.ToString().Length - 4);

            foreach (var weapon in weaponTypes.Where(v => v.ToString().Contains(s)))
            {
                weapons.Add(weaponFactory.CreateWeapon(weapon));
            }

            return weapons;
        }

        private bool CheckForOverlappingCoords(int x, int y)
        {
            if (ships.Any(v => Math.Abs(v.Position.Y - y) < overlap))
            {
                return true;
            }

            return false;
        }

        private void DestroyShip(IShip ship)
        {
            ship.ClearCurrentPosition();
            this.ships.Remove(ship);
        }

        private void SpawnMotherShip()
        {
            if (!ships.Any(v => v.ShipType == ShipType.MotherShip))
            {
                if (motherShipSpawnTime >= 50)
                {
                    IShip motherShip = BuildShip(ShipType.MotherShip);
                    if (CheckForOverlappingCoords(motherShip.Position.X, motherShip.Position.Y))
                    {
                        this.ships.Add(motherShip);
                        motherShipSpawnTime = 0;
                    }
                }
            }
            else
            {
                motherShipSpawnTime = 0;
            }

            motherShipSpawnTime++;
        }

        private void DecreaseArmor(IShip ship)
        {
            ship.Armor--;
        }
    }
}