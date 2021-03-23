using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Fund_system.Models
{
    public partial class Funds
    {
        public Funds()
        {
            Holdings = new HashSet<Holdings>();
            InvProfile = new HashSet<InvProfile>();
            Prices = new HashSet<Prices>();
        }

        public int FundId { get; set; }
        public string FundNo { get; set; }
        public double? Fee { get; set; }
        public int? CompanyId { get; set; }
        public double? Rating { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<Holdings> Holdings { get; set; }
        public virtual ICollection<InvProfile> InvProfile { get; set; }
        public virtual ICollection<Prices> Prices { get; set; }
    }
}
