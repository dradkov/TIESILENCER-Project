using System;
using System.Text;

namespace TheTieSilincer.Models
{
    public class Field
    {
        public static void LevelBuild()
        {
            Console.CursorVisible = false;

            var directions = new Position[]
            {
                new Position(0,1), //moving right
                new Position( 0,-1), // moving left
                new Position( 1,0), // moving down
                new Position(-1,0), // moving up

            };



            Console.SetWindowSize(100, 30);
            Console.SetBufferSize(100, 60);




            var movement = 0;


            var player = new Position(0, 0);


            Console.SetCursorPosition(player.Y, player.X);


           // var sb = new StringBuilder();
           // sb.AppendLine(@"    ^    ");
           // sb.AppendLine(@"    o    ");
           // sb.AppendLine(@"   |o|   ");
           // sb.AppendLine(@"/\\\o///\");
           // sb.AppendLine(@"  </o\>  ");


            //Console.WriteLine(sb.ToString());

            while (true)
            { 
                var userDirection = Console.ReadKey();

                if (userDirection.Key == ConsoleKey.RightArrow)
                {
                    movement = 0;
                }
                if (userDirection.Key == ConsoleKey.LeftArrow)
                {
                    movement = 1;
                }
                if (userDirection.Key == ConsoleKey.DownArrow)
                {
                    movement = 2;
                }
                if (userDirection.Key == ConsoleKey.UpArrow)
                {
                    movement = 3;
                }


                Position currPosition = player;

                var nextDirection = directions[movement];
                var nextPosition = new Position
                    (currPosition.X + nextDirection.X, currPosition.Y + nextDirection.Y);

                if (nextPosition.X >= Console.BufferHeight || nextPosition.Y >= Console.BufferHeight ||
                    nextPosition.X < 0 || nextPosition.Y < 0)
                {
                    continue;
                }

                else
                {
                    player = nextPosition;

                }
                

                Console.Clear();


                Console.SetCursorPosition(player.Y+4, player.X);

                Console.WriteLine(@"^");

                Console.SetCursorPosition(player.Y + 4, player.X+1);
                Console.WriteLine("o");

                Console.SetCursorPosition(player.Y + 3, player.X + 2);

                Console.WriteLine(@"|o|");

                Console.SetCursorPosition(player.Y, player.X + 3);

                Console.WriteLine( @"/\\\o///\");

                Console.SetCursorPosition(player.Y , player.X + 4);

                Console.WriteLine( @"  </o\>  ");

            }

        }
    }
}