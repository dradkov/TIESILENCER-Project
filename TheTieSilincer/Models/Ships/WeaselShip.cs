using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTieSilincer.Models.Ships
{
    public class WeaselShip : EnemyShip
    {
        // \(|X|)/
        //    V
        public WeaselShip()
        {
            GenerateRandomPosition();
        }

        public override void ClearShip()
        {
            if (this.PreviousPosition != null)
            {
                Console.SetCursorPosition(this.PreviousPosition.Y, this.PreviousPosition.X);
                Console.WriteLine(@"       ");
                Console.SetCursorPosition(this.PreviousPosition.Y + 3, this.PreviousPosition.X + 1);
                Console.WriteLine(" ");
            }

        }

        public override void DrawShip()
        {
            Console.SetCursorPosition(this.Position.Y, this.Position.X);
            Console.WriteLine(@"\(|X|)/");
            Console.SetCursorPosition(this.Position.Y+3, this.Position.X+1);
            Console.WriteLine("V");
        }

        public override void UpdateShip()
        {
            this.PreviousPosition = new Position(this.Position.X, this.Position.Y);
            this.Position.X++;
            
        }

        public override void GenerateRandomPosition()
        {
            int x = this.rndGen.Next(0);
            int y = this.rndGen.Next(5, Console.WindowHeight - 1);

            this.Position = new Position(x, y);
        }

        public override bool InBounds(Position nextDirection)
        {
            throw new NotImplementedException();
        }

    }
}
