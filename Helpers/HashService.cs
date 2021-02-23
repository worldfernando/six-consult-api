using SixConsultApi.Helpers.Interfaces;

namespace SixConsultApi.Helpers
{
    public class HashService : IHashService
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public bool Verify(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}
