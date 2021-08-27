using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Exceptions
{
    public class AgeNotAllowedException : Exception
    {
        public AgeNotAllowedException(string message) : base(message)
        {
        }

        public AgeNotAllowedException(int age) : base($"User age: {age}, is not awolled")
        {
        }
    }
}
