namespace TheTieSilincer.Models
{
    public class PilotName
    {
        public PilotName(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }
}