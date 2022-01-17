using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tekus.Core.DTOs;
using Tekus.Core.Entities;
using Tekus.Core.Interfaces;

namespace Tekus.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderRepository _providerRepository;
        private readonly IMapper _mapper;

        public ProviderController(IProviderRepository providerRepository, IMapper mapper)
        {
            _providerRepository = providerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProviders()
        {
            var providers = await _providerRepository.GetProviders();
            var providerDto = _mapper.Map<IEnumerable<ProviderDto>>(providers);
            return Ok(providerDto);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetProvider(int nit)
        {
            var provider = await _providerRepository.GetProvider(nit);
            var providerDto = _mapper.Map<ProviderDto>(provider);
            return Ok(providerDto);
        }
        [HttpPost]
        public async Task<IActionResult> AddProvider(ProviderDto provider)
        {
            var providerEntitie = _mapper.Map<TblProvider>(provider);
            await _providerRepository.InserProvider(providerEntitie);
         
            return Ok(provider);
        }

    }
}
