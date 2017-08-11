using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Exceptions
{
    public class InvalidPasswordDigitException:InvalidPasswordException
    {
        public override string Message
        {
            get
            {
                return "Password must containt at least 1 digit";
            }
        }
    }
}
