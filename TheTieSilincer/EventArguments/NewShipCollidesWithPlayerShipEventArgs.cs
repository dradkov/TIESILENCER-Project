using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTieSilincer.EventArguments
{
    public class NewShipCollidesWithPlayerShipEventEventArgs : EventArgs
    {
        public NewShipCollidesWithPlayerShipEventEventArgs(int demage)
        {
            this.Demage = demage;
        }

        public int Demage { get; private set; }
    }
}
