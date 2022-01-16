using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekus.Core.Entities;

namespace Tekus.Infrastructure.Repositories
{
    public class ProviderRepository
    {
        public IEnumerable<Provider> GetProviders()
        {
            var providers = Enumerable.Range(1, 10).Select(x => new Provider
            {
                IdProvider=x,
                NitProvider= x+x,
                NameProvider = $"Name {x}",
                EmailProvider = $"Email {x}",
                TelfProvider = $"Telf {x}",
                AddressProvider = $"Address {x}"
            });
            return providers;
        }
    }
}
