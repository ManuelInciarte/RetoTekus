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
        public async Task<TblProvider> GetProvider(int nit)
        {
            var provider = await _context.TblProviders.FirstOrDefaultAsync(x => x.Nit == nit);
            return provider;
        } 
        
        public async Task InserProvider(TblProvider provider)
        {
            _context.TblProviders.Add(provider);
            await _context.SaveChangesAsync();
        }


    }
}
