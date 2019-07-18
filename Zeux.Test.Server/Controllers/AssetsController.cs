using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zeux.Test.Models;
using Zeux.Test.Services;

namespace Zeux.Test.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class AssetsController : Controller
    {
        private readonly IAssetService assetService;

        public AssetsController(IAssetService assetService)
        {
            this.assetService = assetService;
        }

        [HttpGet()]
        public async Task<IEnumerable<Asset>> Get([FromQuery]string type)
        {
            return await assetService.Get(type);
        }

        [HttpGet("types")]
        public async Task<IEnumerable<AssetType>> GetTypes()
        {
            return await assetService.GetTypes();
        }
    }
}
