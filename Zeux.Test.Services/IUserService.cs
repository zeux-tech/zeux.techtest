using System.Threading.Tasks;
using Zeux.Test.Models;

namespace Zeux.Test.Services
{
    public interface IUserService
    {
        Task<User> FindUser(string user, string password);
    }
}