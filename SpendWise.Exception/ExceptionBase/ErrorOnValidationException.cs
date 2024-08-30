using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SpendWise.Exception.ExceptionBase

{
    public class ErrorOnValidationException : SpendWiseException
    {

        private  readonly List<string> _Erros ;
        public ErrorOnValidationException(List<string> errorMessages)  : base (string.Empty)
        {
            _Erros = errorMessages;
        }

        public override int StatusCode => (int)HttpStatusCode.BadRequest;
        public override List<string> GetErrorList()
        {
            return _Erros;
        }
    }
}
