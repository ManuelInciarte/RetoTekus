using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekus.Core.DTOs
{
    public class ProviderDto
    {
        public int Id { get; set; }
        public int Nit { get; set; }
        public string NameProvider { get; set; }
        public string EmailProvider { get; set; }
        public string TelfProvider { get; set; }
        public string AddressProvider { get; set; }
    }
}
