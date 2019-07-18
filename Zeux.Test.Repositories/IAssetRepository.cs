using System.Linq;
using System.Threading.Tasks;
using Zeux.Test.Models;

namespace Zeux.Test.Repositories
{
    public interface IAssetRepository
    {
        Task<IQueryable<Asset>> Get(string type = null);

        Task<IQueryable<AssetType>> GetTypes();
    }
}