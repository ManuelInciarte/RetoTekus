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

        public ServiceProviderRepository(TekusContext context)
        {
            _context = context;

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
        public async Task<List<TblServiceProvider>> GetServiceProviderNit(int idProvider)
        {
            List<TblServiceProvider> serviceProviderList = await (from d in _context.TblServiceProviders where d.IdProvider == idProvider
                                                                  select new TblServiceProvider
                                                                  {
                                                                      Id = d.Id,
                                                                      IdProvider = d.IdProvider,
                                                                      IdService = d.IdService,
                                                                      CostHour = d.CostHour,
                                                                      CountryAvailable = d.CountryAvailable
                                                                  }).ToListAsync();  
            return serviceProviderList;
        }

        public async Task<List<TblServiceProvider>> GetServiceProviderId(int idService)
        {
            List<TblServiceProvider> serviceProviderList = await (from d in _context.TblServiceProviders
                                                                  where d.IdService == idService
                                                                  select new TblServiceProvider
                                                                  {
                                                                      Id = d.Id,
                                                                      IdProvider = d.IdProvider,
                                                                      IdService = d.IdService,
                                                                      CostHour = d.CostHour,
                                                                      CountryAvailable = d.CountryAvailable
                                                                  }).ToListAsync();
            return serviceProviderList;
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
