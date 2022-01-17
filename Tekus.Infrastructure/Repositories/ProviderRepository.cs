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
    public class ProviderRepository : IProviderRepository
    {

        private readonly TekusContext _context;
        public ProviderRepository(TekusContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TblProvider>> GetProviders()
        {
            var providers = await _context.TblProviders.ToListAsync();            
            return providers;
        }
        public async Task<TblProvider> GetProviderId(int id)
        {
            var provider = await _context.TblProviders.FirstOrDefaultAsync(x => x.Id == id);
            return provider;
        }
        public async Task<TblProvider> GetProviderNit(int nit)
        {
            var provider = await _context.TblProviders.FirstOrDefaultAsync(x => x.Nit == nit);
            return provider;
        }

        public async Task InsertProvider(TblProvider provider)
        {
            _context.TblProviders.Add(provider);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateProvider(TblProvider provider)
        {
            var _provider = await GetProviderNit(provider.Nit);
            if (_provider is null)
            {
                return false;
            }

            _provider.Nit = provider.Nit;
            _provider.NameProvider = provider.NameProvider;
            _provider.TelfProvider = provider.TelfProvider;
            _provider.EmailProvider = provider.EmailProvider;
            _provider.AddressProvider = provider.AddressProvider;

            int rows = await _context.SaveChangesAsync();

            return rows > 0;
        }
        public async Task<bool> DeleteProvider(int id)
        {
            var _provider = await GetProviderId(id);
            if (_provider is null)
            {
                return false;
            }
            _context.TblProviders.Remove(_provider);            

            int rows = await _context.SaveChangesAsync();

            return rows > 0;
        }
    }
}
