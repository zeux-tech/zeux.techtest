using System.Threading.Tasks;
using Zeux.Test.Models;

namespace Zeux.Test.Repositories
{
    public interface IUserRepository
    {
        Task<User> FindUser(string user, string password);
    }
}
