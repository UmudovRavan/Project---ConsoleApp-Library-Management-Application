using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Project___ConsoleApp__Library_Management_Application_.MyException.Common
{
    public class NotValidException : Exception
    {
        public NotValidException()
        {
            
        }
        public NotValidException(string message) : base(message)
        {
        }

       
    }
}
