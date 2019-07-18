using System;
using System.Linq;
using System.Threading.Tasks;
using Zeux.Test.Models;

namespace Zeux.Test.Repositories
{
    public class AssetRepository: IAssetRepository
    {
        private readonly IContext context;

        public AssetRepository(IContext context)
        {
            this.context = context;
        }

        public async Task<IQueryable<Asset>> Get(string type = null)
        {
            return await Task.Run(() => context.Assets
                .Where(row => string.IsNullOrWhiteSpace(type) || string.Equals(row.Type.Name, type, StringComparison.OrdinalIgnoreCase))
                .OrderBy(x => x.Name));
        }

        public async Task<IQueryable<AssetType>> GetTypes()
        {
            return await Task.Run(() => context.AssetTypes);
        }
    }
}
