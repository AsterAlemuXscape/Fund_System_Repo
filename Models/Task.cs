using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Fund_system.Models
{
    public partial class Task
    {
        public int TaskId { get; set; }
        public int? CompanyId { get; set; }
        public string TaskStartId { get; set; }
        public string TaskNo { get; set; }
        public DateTime? TaskDate { get; set; }
        public double? TaskAmount { get; set; }
        public double? TaskFee { get; set; }
        public string TaskStatus { get; set; }
        public DateTime? TaskEndDate { get; set; }
        public string TaskOrderNum { get; set; }
        public int? TaskOrderId { get; set; }

        public virtual Company Company { get; set; }
    }
}
