using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tekus.Core.Interfaces;
using Tekus.Infrastructure.Repositories;

namespace Tekus.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderRepository _providerRepository;

        public ProviderController(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProvider()
        {
            var providers = await _providerRepository.GetProviders();
            return Ok(providers);
        }
    }
}
