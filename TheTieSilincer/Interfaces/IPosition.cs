namespace TheTieSilincer.Interfaces
{
    using TheTieSilincer.Models;

    public interface IPosition
    {
        Position Position { get; set; }

        Position PreviousPosition { get; set; }
    }
}