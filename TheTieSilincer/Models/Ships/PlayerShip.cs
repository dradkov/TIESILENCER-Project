using System;
using System.Collections.Generic;
using TheTieSilincer.Models.Bullets;

namespace TheTieSilincer.Models
{
    public class PlayerShip : Ship
    {
        public PlayerShip()
        {
           
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
            for (int i = 0; i < this.Bullets.Count; i++)
            {
                if (!Bullets[i].InBounds())
                {
                    Bullets.RemoveAt(i);
                    i--;
                }
                else
                {
                    this.Bullets[i].DrawBullet();
                }
            }
        }

        public void UpdateBullets()
        {
            for (int i = 0; i < this.Bullets.Count; i++)
            {
                Bullet currentBullet = this.Bullets[i];
                currentBullet.UpdatePosition();
            }

        }

        public void ClearBullets()
        {
            for (int i = 0; i < this.Bullets.Count; i++)
            {
                Bullet currentBullet = this.Bullets[i];
                if (currentBullet.PreviousPosition != null)
                {
                    this.Bullets[i].ClearBullet();
                }

            }
        }

        private bool CheckBulletPosition(int i)
        {
            return !(Bullets[i].Position.X >= Console.BufferHeight || Bullets[i].Position.Y >= Console.BufferHeight
                                      || Bullets[i].Position.X < 0 || Bullets[i].Position.Y < 0);
        }

        public override void UpdateShip()
        {
            throw new NotImplementedException();
        }
    }
}
