using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Fund_system.Models
{
    public partial class InvProfile
    {
        public int InvProfileId { get; set; }
        public int? CompanyId { get; set; }
        public string InsuranceNo { get; set; }
        public double? Percent { get; set; }
        public int? FundId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? InsuranceId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Funds Fund { get; set; }
        public virtual Insurance Insurance { get; set; }
    }
}
