using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Fund_system.Models
{
    public partial class Insurance
    {
        public Insurance()
        {
            InvProfile = new HashSet<InvProfile>();
            TaskOnGoing = new HashSet<TaskOnGoing>();
        }

        public int InsuranceId { get; set; }
        public string InsuranceNo { get; set; }
        public string Nominee { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ZDate { get; set; }
        public DateTime? ZEndDate { get; set; }
        public int? ClientId { get; set; }
        public int? ProductId { get; set; }
        public int? StatusId { get; set; }
        public DateTime? EndDate { get; set; }
        public int? HoldingId { get; set; }

        public virtual Clients Client { get; set; }
        public virtual Holdings Holding { get; set; }
        public virtual InsStatus Status { get; set; }
        public virtual ICollection<InvProfile> InvProfile { get; set; }
        public virtual ICollection<TaskOnGoing> TaskOnGoing { get; set; }
    }
}
