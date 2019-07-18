using System.Linq;
using Zeux.Test.Models;

namespace Zeux.Test.Repositories
{
    public interface IContext
    {
        IQueryable<User> Users { get; }

        IQueryable<AssetType> AssetTypes { get; }

        IQueryable<Asset> Assets { get; }
    }
}
