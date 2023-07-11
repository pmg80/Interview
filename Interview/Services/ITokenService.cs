using Interview.Models;

namespace Interview.Services
{
    public interface ITokenService
    {
        public string CreateToken(User user);
    }
}
