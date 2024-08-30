using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SpendWise.Exception.ExceptionBase
{
    public class NotFoundException : SpendWiseException
    {
        public NotFoundException(string message) : base (message)
        {
                
        }

        public override int StatusCode => (int)HttpStatusCode.NotFound;
        public override List<string> GetErrorList()
        {
            return new List<string>() {Message};
        }
    }
}
