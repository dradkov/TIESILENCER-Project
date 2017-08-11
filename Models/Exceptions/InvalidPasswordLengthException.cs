using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Exceptions
{
    public class InvalidPasswordLengthException:InvalidPasswordException
    {
        public override string Message
        {
            get
            {
                return "Password must be at least 6 characters long";
            }
        }
    }
}
