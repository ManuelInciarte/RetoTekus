using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekus.Core.DTOs;
using Tekus.Core.Entities;

namespace Tekus.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile 
    {
        public AutomapperProfile()
        {
            CreateMap<TblProvider, ProviderDto>();
            CreateMap<ProviderDto, TblProvider>();
            CreateMap<TblService, ServiceDto>();
            CreateMap<ServiceDto, TblService>();
            CreateMap<TblServiceProvider, ServiceProviderDto>();
            CreateMap<ServiceProviderDto, TblServiceProvider>();
        }
    }
}
