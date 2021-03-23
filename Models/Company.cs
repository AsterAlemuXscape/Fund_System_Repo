using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Fund_system.Models
{
    public partial class Company
    {
        public Company()
        {
            Funds = new HashSet<Funds>();
            Holdings = new HashSet<Holdings>();
            InvProfile = new HashSet<InvProfile>();
            Prices = new HashSet<Prices>();
            Task = new HashSet<Task>();
            TaskOnGoing = new HashSet<TaskOnGoing>();
            Tasks = new HashSet<Tasks>();
        }

        public int CompanyId { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }

        public virtual ICollection<Funds> Funds { get; set; }
        public virtual ICollection<Holdings> Holdings { get; set; }
        public virtual ICollection<InvProfile> InvProfile { get; set; }
        public virtual ICollection<Prices> Prices { get; set; }
        public virtual ICollection<Task> Task { get; set; }
        public virtual ICollection<TaskOnGoing> TaskOnGoing { get; set; }
        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
