using System;
using TheTieSilincer.Models.Weapons;

namespace TheTieSilincer.Models
{
    public class PlayerShip : Ship
    {
        public PlayerShip()
        {
            this.Weapon = new PlayerWeapon();
            this.Position = new Position(Console.WindowHeight - 8, Console.WindowWidth / 3 + 5);
        }

        public event EventHandler SendData;
        public void StartSendingData()
        {
            this.SendData(this, EventArgs.Empty);

        }
        public override void ClearShip()
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

            var nextPosition = new Position
                (currPosition.X + nextDirection.X, currPosition.Y + nextDirection.Y);

            if (nextPosition.X > Console.WindowHeight - 7 || nextPosition.Y > Console.WindowWidth - 9 ||
                nextPosition.X < 0 || nextPosition.Y < 0)
            {
                return false;
            }

            this.PreviousPosition = this.Position;
            this.Position = nextPosition;

            return true;
        }

        public void DrawBullets()
        {
            this.Weapon.DrawBullets();
        }

        public void UpdateBullets()
        {
            this.Weapon.UpdateBullets();
        }

        public void ClearBullets()
        {
            this.Weapon.ClearBullets();
        }

        private bool CheckBulletPosition(int i)
        {
            //  return !(Bullets[i].Position.X >= Console.BufferHeight || Bullets[i].Position.Y >= Console.BufferHeight
            //  || Bullets[i].Position.X < 0 || Bullets[i].Position.Y < 0);

            return false;
        }

        public override void UpdateShip()
        {
            throw new NotImplementedException();
        }
    }
}
