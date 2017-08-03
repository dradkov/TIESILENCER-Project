using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTieSilincer.Models;

namespace TheTieSilincer.Support
{
   public class GameService
    {
        public static void CreateCharacter(string name)
        {
            var character = new PilotName(name);

        }
    }
}
