using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Fund_system.Models
{
    public partial class Clients
    {
        public Clients()
        {
            Insurance = new HashSet<Insurance>();
        }

        public int ClientId { get; set; }
        public string SsnNo { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int? AddressId { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? MDate { get; set; }

        public virtual AddressBook Address { get; set; }
        public virtual ICollection<Insurance> Insurance { get; set; }
    }
}
