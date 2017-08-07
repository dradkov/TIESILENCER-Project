namespace TheTieSilincer
{
    using TheTieSilincer.Core;
    using TheTieSilincer.Interfaces;

    public class StartUp
    {
        public static void Main()
        {
            IEngine engine = new Engine();

            engine.Run();

        }
    }
}
