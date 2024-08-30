namespace SpendWise.Exception.ExceptionBase
{
    public abstract class SpendWiseException : System.Exception
    {
       protected SpendWiseException(string message) : base (message)
        {
            
        }

       public abstract int StatusCode { get; }

       public abstract List<string> GetErrorList();
    }
}
