using System.Security.Cryptography.X509Certificates;
using SpendWise.Domain.Security.Criptography;
using BC = BCrypt.Net.BCrypt;

namespace SpendWise.Infrastructure.Security.Cryptography
{
    public class BCrypt : IPasswordEncripter
    {
        public string Encrypt(string password)
        {
            string passwordHash = BC.HashPassword(password);


            
            return passwordHash;

            
        }
        public bool Verify(string password, string passwordHash) => BC.Verify(password, passwordHash);
    }
}
