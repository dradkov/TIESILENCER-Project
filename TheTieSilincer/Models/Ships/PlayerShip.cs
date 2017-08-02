using System;
using System.Collections.Generic;
using TheTieSilincer.Enums;
using TheTieSilincer.Models.Weapons;
using TheTieSilincer.Support;

namespace TheTieSilincer.Models
{
    public class PlayerShip : Ship
    {
        private Position nextPosition;

        public PlayerShip(List<Weapon> weapons) : base(weapons)
        {
            this.Position = new Position(Constants.WindowHeight - 8, Constants.WindowWidth / 3 + 5);
            this.CollisionAOE = 3;
            this.Armor = 999;

        }

        public event EventHandler SendData;
        public void StartSendingData()
        {
            this.SendData(this, EventArgs.Empty);

        }
        public override void ClearShip(bool destroyed = false)
        {
            if (PreviousPosition != null)
            {
                Console.SetCursorPosition(PreviousPosition.Y + 4, PreviousPosition.X);
                Console.WriteLine(" ");
                Console.SetCursorPosition(PreviousPosition.Y + 4, PreviousPosition.X + 1);
                Console.WriteLine(" ");
                Console.SetCursorPosition(PreviousPosition.Y + 3, PreviousPosition.X + 2);
                Console.WriteLine("   ");
                Console.SetCursorPosition(PreviousPosition.Y, PreviousPosition.X + 3);
                Console.WriteLine("         ");
                Console.SetCursorPosition(PreviousPosition.Y, PreviousPosition.X + 4);
                Console.WriteLine("         ");
            }
        }

        public override void DrawShip()
        {
            Console.SetCursorPosition(Position.Y + 4, Position.X);
            Console.WriteLine(@"^");
            Console.SetCursorPosition(Position.Y + 4, Position.X + 1);
            Console.WriteLine("o");
            Console.SetCursorPosition(Position.Y + 3, Position.X + 2);
            Console.WriteLine(@"|o|");
            Console.SetCursorPosition(Position.Y, Position.X + 3);
            Console.WriteLine(@"/\\\o///\");
            Console.SetCursorPosition(Position.Y, Position.X + 4);
            Console.WriteLine(@"  </o\>  ");
        }

        public override bool InBounds(Position nextDirection)
        {
            Position currPosition = this.Position;
            if (nextDirection == null) return false;
            nextPosition = new Position
               (currPosition.X + nextDirection.X, currPosition.Y + nextDirection.Y * 2);

            // and do Game.SpawnObject(new Bullet() 

            if (nextPosition.X > Console.WindowHeight - 7 || nextPosition.Y > Console.WindowWidth - 9 ||
                nextPosition.X < 0 || nextPosition.Y < 0)
            {
                return false;
            }
            
            return true;
        }


        public override void UpdateShip(Position nextDirection)
        {
            if(InBounds(nextDirection))
            {
                this.PreviousPosition = this.Position;
                this.Position = nextPosition;
            }
        }

    }
}
