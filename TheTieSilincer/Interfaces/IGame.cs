namespace TheTieSilincer.Interfaces
{
    public interface IGame : IGameObject
    {
        void InitialiseSettings();

        void CheckForCollisions();
    }
}