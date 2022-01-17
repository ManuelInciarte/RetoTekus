using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekus.Core.Entities;

namespace Tekus.Core.Interfaces
{
    public interface IServiceRepository
    {
        Task<IEnumerable<TblService>> GetServices();
        Task<TblService> GetService(int id);
        Task InsertService(TblService service);
        Task<bool> UpdateService(TblService service);
        Task<bool> DeleteService(int id);

    }
}
