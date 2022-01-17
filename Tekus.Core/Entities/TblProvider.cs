using System.Collections.Generic;

#nullable disable

namespace Tekus.Core.Entities
{
    public partial class TblProvider
    {
        public TblProvider()
        {
            TblServiceProviders = new HashSet<TblServiceProvider>();
        }

        public int Id { get; set; }
        public int Nit { get; set; }
        public string NameProvider { get; set; }
        public string EmailProvider { get; set; }
        public string TelfProvider { get; set; }
        public string AddressProvider { get; set; }

        public virtual ICollection<TblServiceProvider> TblServiceProviders { get; set; }
    }
}
