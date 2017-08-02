using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTieSilincer.Models
{
   public class PilotName
    {
        public PilotName(string name)
        {
            this.Name = name;// i have to play around with this tool its nice yea
        }


        public string Name { get; private set; }
    }
}
