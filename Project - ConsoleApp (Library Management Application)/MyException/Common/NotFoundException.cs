using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project___ConsoleApp__Library_Management_Application_.MyException.Common
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
        {
            
        }
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
