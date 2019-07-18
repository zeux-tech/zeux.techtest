using System.Linq;
using System.Threading.Tasks;
using Zeux.Test.Models;

namespace Zeux.Test.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly IContext context;

        public UserRepository(IContext context)
        {
            this.context = context;
        }

        public async Task<User> FindUser(string user, string password)
        {
            return await Task.Run(() => context.Users.FirstOrDefault(x => x.Login == user && x.Password == password));
        }
    }
}
