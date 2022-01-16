using System;
using System.Collections.Generic;

#nullable disable

namespace Tekus.Core.Entities
{
    public partial class TblServiceProvider
    {
        public int Id { get; set; }
        public int IdProvider { get; set; }
        public int IdService { get; set; }
        public decimal CostHour { get; set; }
        public string CountryAvailable { get; set; }

        public virtual TblProvider IdProviderNavigation { get; set; }
        public virtual TblService IdServiceNavigation { get; set; }
    }
}
