using System.Threading.Tasks;
using coddez.API.Models;

namespace coddez.API.Data
{
    public interface IAuthRepository
    {
         Task<User> Register(User user, string password);
         Task<User> Login(string emailAddress, string password);
         Task<bool> UserExits(string emailAddress); 
    }
}