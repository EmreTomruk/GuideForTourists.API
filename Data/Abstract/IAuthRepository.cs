using System.Threading.Tasks;
using TouristGuide.API.Models;

namespace TouristGuide.API.Data.Abstract
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string userName, string password);
        Task<bool> UserExists(string userName);
    }
}
