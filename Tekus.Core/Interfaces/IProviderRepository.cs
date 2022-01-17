using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekus.Core.Entities;

namespace Tekus.Core.Interfaces
{
    public interface IProviderRepository
    {
        Task<IEnumerable<TblProvider>> GetProviders();
        Task<TblProvider> GetProviderId(int id);
        Task<TblProvider> GetProviderNit(int nit);
        Task InserProvider(TblProvider provider);
        Task<bool> UpdateProvider(TblProvider provider);
        Task<bool> DeleteProvider(int id);
    }
}
