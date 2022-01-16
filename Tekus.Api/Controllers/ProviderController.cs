using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tekus.Infrastructure.Repositories;

namespace Tekus.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        [HttpGet]
        public  IActionResult GetProvider()
        {
            var providers = new ProviderRepository().GetProviders();
            return Ok(providers);
        }
    }
}
