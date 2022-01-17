using System.Collections.Generic;

#nullable disable

namespace Tekus.Core.Entities
{
    public partial class TblService
    {
        public TblService()
        {
            TblServiceProviders = new HashSet<TblServiceProvider>();
        }

        public int Id { get; set; }
        public string NameService { get; set; }

        public virtual ICollection<TblServiceProvider> TblServiceProviders { get; set; }
    }
}
