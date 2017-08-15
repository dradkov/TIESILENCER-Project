namespace TheTieSilincer.Support
{
    using TheTieSilincer.Models;

    public class GameService
    {
        public static void CreateCharacter(string name)
        {
            var character = new PilotName(name);
        }
    }
}