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
    public class ServiceRepository : IServiceRepository
    {
        private readonly TekusContext _context;
        public ServiceRepository(TekusContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<TblService>> GetServices()
        {
            var services = await _context.TblServices.ToListAsync();
            return services;
        }
        public async Task<TblService> GetService(int id)
        {
            var service = await _context.TblServices.FirstOrDefaultAsync(x => x.Id == id);
            return service;
        }
   
        public async Task InsertService(TblService service)
        {
            _context.TblServices.Add(service);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateService(TblService service)
        {
            var _service = await GetService(service.Id);
            if (_service is null)
            {
                return false;
            }

            _service.NameService = service.NameService;

            int rows = await _context.SaveChangesAsync();

            return rows > 0;
        }
        public async Task<bool> DeleteService(int id)
        {
            var _service = await GetService(id);
            if (_service is null)
            {
                return false;
            }
            _context.TblServices.Remove(_service);

            int rows = await _context.SaveChangesAsync();

            return rows > 0;
        }
    }
}
