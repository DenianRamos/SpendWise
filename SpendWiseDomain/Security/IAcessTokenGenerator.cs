namespace SpendWise.Domain.Security
{
    public interface IAcessTokenGenerator
    {
        string Generate(Entities.User user);
    }
}
