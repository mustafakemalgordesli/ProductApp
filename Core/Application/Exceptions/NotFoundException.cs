using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
        public NotFoundException() : this("Not found")
        {
        }
        public NotFoundException(Exception ex) : this(ex.Message) 
        {
        }
    }
}
