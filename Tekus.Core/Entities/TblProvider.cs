using System;
using System.Collections.Generic;

#nullable disable

namespace Tekus.Core.Entities
{
    public partial class TblProvider
    {
        public int Id { get; set; }
        public int Nit { get; set; }
        public string NameProvider { get; set; }
        public string EmailProvider { get; set; }
        public string TelfProvider { get; set; }
        public string AddressProvider { get; set; }
    }
}
