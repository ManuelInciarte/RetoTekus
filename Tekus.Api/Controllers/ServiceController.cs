using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tekus.Core.DTOs;
using Tekus.Core.Entities;
using Tekus.Core.Interfaces;

namespace Tekus.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;

        public ServiceController(IServiceRepository sewrviceRepository, IMapper mapper)
        {
            _serviceRepository = sewrviceRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetServices()
        {
            var services = await _serviceRepository.GetServices();
            var servicesDto = _mapper.Map<IEnumerable<ServiceDto>>(services);
            return Ok(servicesDto);
        }

        [HttpGet ("id")]
        public async Task<IActionResult> GetServices(int id)
        {
            var service = await _serviceRepository.GetService(id);
            var serviceDto = _mapper.Map<ServiceDto>(service);
            return Ok(serviceDto);
        }
        [HttpPost]
        public async Task<IActionResult> AddService (ServiceDto service)
        {
            var serviceEntitie = _mapper.Map<TblService>(service);
            await _serviceRepository.InsertService(serviceEntitie);
            return Ok(serviceEntitie);
        }

        [HttpPut]
        public async Task<IActionResult> PutService(ServiceDto serviceDto)
        {
            var tblService = _mapper.Map<TblService>(serviceDto);          
            await _serviceRepository.UpdateService(tblService);

            return Ok(tblService);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteService(int id)
        {
            var result = await _serviceRepository.DeleteService(id);

            return Ok(result);
        }


    }
}
