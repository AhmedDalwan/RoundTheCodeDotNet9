using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Hybrid;

namespace RoundTheCodeDotNet9.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CacheController : ControllerBase
    {
        private readonly HybridCache _hybridCache;

        public CacheController(HybridCache hybridCache)
        {
            _hybridCache = hybridCache;
        }

        // [HttpGet]
        // public async Task<string> MyCache()
        // {
        //     return await _hybridCache.GetOrCreateAsync("product")
        // }
    }
}