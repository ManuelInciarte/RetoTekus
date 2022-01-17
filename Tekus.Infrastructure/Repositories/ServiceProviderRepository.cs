using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekus.Core.Entities;
using Tekus.Core.Interfaces;
using Tekus.Infrastructure.Data;

namespace Tekus.Infrastructure.Repositories
{
    public class ServiceProviderRepository : IServiceProviderRepository
    {

        private readonly TekusContext _context;
        private readonly ProviderRepository _provider;
        private readonly ServiceRepository _service;
        public ServiceProviderRepository(TekusContext context, ProviderRepository provider, ServiceRepository service)
        {
            _context = context;
            _provider = provider;
            _service = service; 
        }

        public async Task<IEnumerable<TblServiceProvider>> GetServiceProviders()
        {
            var servicesProviders = await _context.TblServiceProviders.ToListAsync();
            return servicesProviders;
        }
        public async Task<TblServiceProvider> GetServiceProvider(int id)
        {
            var serviceProvider = await _context.TblServiceProviders.FirstOrDefaultAsync(x => x.Id == id);
            return serviceProvider;
        }
        public async Task<TblServiceProvider> GetServiceProviderNit(int Nit)
        {
            var provider = await _provider.GetProviderNit(Nit);
            var serviceProvider = await _context.TblServiceProviders.FirstOrDefaultAsync(x => x.Id == provider.Id);
            return serviceProvider;
        }

        public async Task<TblServiceProvider> GetServiceProviderId(int idService)
        {
            var service = await _service.GetService(idService);
            var serviceProvider = await _context.TblServiceProviders.FirstOrDefaultAsync(x => x.Id == service.Id);
            return serviceProvider;
        }

        public async Task InsertServiceProvider(TblServiceProvider provider)
        {
            _context.TblServiceProviders.Add(provider);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateServiceProvider(TblServiceProvider provider)
        {
            var _provider = await GetServiceProvider(provider.Id);
            if (_provider is null)
            {
                return false;
            }
            _provider.CostHour = provider.CostHour;
            _provider.CountryAvailable = provider.CountryAvailable;

            int rows = await _context.SaveChangesAsync();

            return rows > 0;
        }
        public async Task<bool> DeleteServiceProvider(int id)
        {
            var _provider = await GetServiceProvider(id);
            if (_provider is null)
            {
                return false;
            }
            _context.TblServiceProviders.Remove(_provider);

            int rows = await _context.SaveChangesAsync();

            return rows > 0;
        }

    }
}
