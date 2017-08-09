using TheTieSilincer.Models;

namespace TheTieSilincer.Interfaces
{
    public interface IPosition
    {
        Position Position { get; set; }

        Position PreviousPosition { get; set; }

    }
}
