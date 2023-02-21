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
        public int StatusCode
        {
            get
            {
                return (int)HttpStatusCode.NotFound;
            }
        }
        public NotFoundException(string message) : base(message)
        {
        }
        public NotFoundException() : base("Not found")
        {
        }
    }
}
