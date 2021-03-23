using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Fund_system.Models
{
    public partial class ProductRules
    {
        public int ProductRulesId { get; set; }
        public string ProductName { get; set; }
        public string Nominee { get; set; }
        public int? ZAge { get; set; }
        public string ClaimPeriod { get; set; }
        public string MoveAbility { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
