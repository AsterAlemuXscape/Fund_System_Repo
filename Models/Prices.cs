using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Fund_system.Models
{
    public partial class Prices
    {
        public int PriceId { get; set; }
        public int? FundId { get; set; }
        public int? CompanyId { get; set; }
        public double? FindPrice { get; set; }
        public double? DatePrice { get; set; }

        public virtual Company Company { get; set; }
        public virtual Funds Fund { get; set; }
    }
}
