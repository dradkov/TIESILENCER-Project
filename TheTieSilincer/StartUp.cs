namespace TheTieSilincer
{
    using System;
    using TheTieSilincer.Core;
    using TheTieSilincer.Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
          // Position pos = new Position(3, 2);
          //
          // while (true)
          // {
          //     Console.SetCursorPosition(pos.X, pos.Y);
          //     Console.WriteLine("^");
          //     pos.Y--;
          //     Console.WriteLine(" ");
          // }

            var engine = new Engine();
            engine.Run();

        }
    }
}
