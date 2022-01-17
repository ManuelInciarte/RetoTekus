using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekus.Core.DTOs
{
    public class ServiceProviderDto
    {
        public int Id { get; set; }
        public int IdProvider { get; set; }
        public int IdService { get; set; }
        public decimal CostHour { get; set; }
        public string CountryAvailable { get; set; }
    }
}
