using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekus.Core.Entities;

namespace Tekus.Core.Interfaces
{
    public interface IServiceProviderRepository
    {
        Task<IEnumerable<TblServiceProvider>> GetServiceProviders();
        Task<TblServiceProvider> GetServiceProvider(int id);
        Task<List<TblServiceProvider>> GetServiceProviderNit(int idProvider);
        Task<List<TblServiceProvider>> GetServiceProviderId(int idService);
        Task InsertServiceProvider(TblServiceProvider provider);
        Task<bool> UpdateServiceProvider(TblServiceProvider provider);
        Task<bool> DeleteServiceProvider(int id);
    }
}
