﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TheTieSilincer.Factories;
using TheTieSilincer.Models.Ships;

namespace TheTieSilincer.Core
{
    public class ShipManager
    {
        private ShipFactory shipFactory;
        private List<EnemyShip> ships;
        private int shipAddNumber = 2;

        public ShipManager()
        {
            this.shipFactory = new ShipFactory();
            this.ships = new List<EnemyShip>();
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
            if(ships.Count == 0)
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
            int overlap = 7;

            if(ships.Any(v=> Math.Abs(v.Position.Y - y) < overlap))
            {
                return true;
            }


            return false;
        }
    }
}