using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Exceptions;

namespace TheTieSilincer.Exceptions
{
    public class InvalidNameLengthException:CustomRegisterException
    {
        public override string Message
        {
            get
            {
                return "Name must be at least 6 characters long";
            }
        }
    }
}
