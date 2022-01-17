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
        public async Task<IActionResult> GetProviderId(int id)
        {
            var provider = await _providerRepository.GetProviderId(id);
            var providerDto = _mapper.Map<ProviderDto>(provider);
            return Ok(providerDto);
        }
        [HttpGet("nit")]
        public async Task<IActionResult> GetProviderNit(int nit)
        {
            var provider = await _providerRepository.GetProviderNit(nit);
            var providerDto = _mapper.Map<ProviderDto>(provider);
            return Ok(providerDto);
        }
        [HttpPost]
        public async Task<IActionResult> AddProvider(ProviderDto providerDto)
        {
            var providerEntitie = _mapper.Map<TblProvider>(providerDto);
            await _providerRepository.InsertProvider(providerEntitie);
         
            return Ok(providerEntitie);
        }
        [HttpPut]
        public async Task<IActionResult> PutProvider(int id, ProviderDto providerDto)
        {
            var tblProvider = _mapper.Map<TblProvider>(providerDto);
            tblProvider.Id = providerDto.Id;
            await _providerRepository.UpdateProvider(tblProvider);

            return Ok(tblProvider);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProvider(int id)
        {         
            var result = await _providerRepository.DeleteProvider(id);

            return Ok(result);
        }


    }
}
