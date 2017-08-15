using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Exceptions
{
    public class InvalidNameAndPasswordMatchException:CustomLogInException
    {
        public override string Message
        {
            get
            {
                return "Name And Password don't match!";
            }
        }
    }
}
