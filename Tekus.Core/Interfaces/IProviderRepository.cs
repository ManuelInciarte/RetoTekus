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
        Task<TblProvider> GetProvider(int nit);
        Task InserProvider(TblProvider provider);
    }
}
