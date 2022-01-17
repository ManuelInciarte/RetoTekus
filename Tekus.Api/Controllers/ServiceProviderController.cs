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
    public class ServiceProviderController : ControllerBase
    {
        private readonly IServiceProviderRepository _serviceProviderRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IProviderRepository _providerRepository;
        private readonly IMapper _mapper;

        public ServiceProviderController(IServiceProviderRepository serviceProviderRepository, IServiceRepository serviceRepository,
            IProviderRepository providerRepository, IMapper mapper)
        {
            _serviceProviderRepository = serviceProviderRepository;
            _serviceRepository = serviceRepository;
            _providerRepository = providerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetServicesProviders()
        {
            var servicesProviders = await _serviceProviderRepository.GetServiceProviders();
            var servicesProvidersDto = _mapper.Map<IEnumerable<ServiceProviderDto>>(servicesProviders);
            return Ok(servicesProvidersDto);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetServiceProvider(int id)
        {
            var servicesProviders = await _serviceProviderRepository.GetServiceProvider(id);
            var servicesProvidersDto = _mapper.Map<ServiceProviderDto>(servicesProviders);
            return Ok(servicesProvidersDto);
        }
        [HttpGet("nitProvider")]
        public async Task<IActionResult> GetServiceProviderNit(int nitProvider)
        {
            var provider = await _providerRepository.GetProviderNit(nitProvider);
            var servicesProviders = await _serviceProviderRepository.GetServiceProviderNit(provider.Id);
            var servicesProvidersDto = _mapper.Map<IEnumerable<ServiceProviderDto>>(servicesProviders);
            return Ok(servicesProvidersDto);
        }
        [HttpGet("idService")]
        public async Task<IActionResult> GetServiceProviderId(int idService)
        {
            var servicesProviders = await _serviceProviderRepository.GetServiceProviderId(idService);
            var servicesProvidersDto = _mapper.Map<IEnumerable<ServiceProviderDto>>(servicesProviders);
            return Ok(servicesProvidersDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddServiceProvider(ServiceProviderDto serviceProvider)
        {
            var tblServicesProviders = _mapper.Map<TblServiceProvider>(serviceProvider);
            await _serviceProviderRepository.InsertServiceProvider(tblServicesProviders);
            return Ok(tblServicesProviders);
        }

        [HttpPut]
        public async Task<IActionResult> PutServiceProvider(ServiceProviderDto serviceProvider)
        {
            var tblServicesProviders = _mapper.Map<TblServiceProvider>(serviceProvider);
            await _serviceProviderRepository.UpdateServiceProvider(tblServicesProviders);

            return Ok(tblServicesProviders);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteServiceProvider(int id)
        {
            var result = await _serviceProviderRepository.DeleteServiceProvider(id);

            return Ok(result);
        }

    }
}
