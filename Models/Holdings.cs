using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Fund_system.Models
{
    public partial class Holdings
    {
        public Holdings()
        {
            Insurance = new HashSet<Insurance>();
        }

        public int HoldingId { get; set; }
        public int? CompanyId { get; set; }
        public int? FundId { get; set; }
        public string NoOfUnits { get; set; }
        public DateTime? DateHolding { get; set; }
        public double? FundPrice { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Company Company { get; set; }
        public virtual Funds Fund { get; set; }
        public virtual ICollection<Insurance> Insurance { get; set; }
    }
}
