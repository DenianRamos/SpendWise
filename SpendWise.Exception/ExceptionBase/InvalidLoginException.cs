using System.Net;

namespace SpendWise.Exception.ExceptionBase
{
    public class InvalidLoginException : SpendWiseException
    {
        public InvalidLoginException() : base(ResourceErrorMessages.EMAIL_AND_PASSWORD_ERROR)
        {
        }

        public override int StatusCode => (int)HttpStatusCode.Unauthorized;
        public override List<string> GetErrorList()
        {
            return [Message];
        }
    }
}
