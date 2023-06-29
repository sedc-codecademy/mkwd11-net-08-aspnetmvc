
namespace Pazar4.BLL.Hashing
{
    public class DummyPasswordHasher
        : IPasswordHasher
    {
        public string Hash(string password)
        {
            return password; //TODO hash the password
        }
    }
}
