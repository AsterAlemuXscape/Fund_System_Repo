using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Fund_system.Models
{
    public partial class TaskOnGoing
    {
        public int TaskOnGoingId { get; set; }
        public int? CompanyId { get; set; }
        public string InsuranceNo { get; set; }
        public string TaskNo { get; set; }
        public int? FundId { get; set; }
        public DateTime? TaskStartDate { get; set; }
        public DateTime? TaskEndDate { get; set; }
        public string TypeOfTask { get; set; }
        public double? TaskAmount { get; set; }
        public string TaskNoOfUnits { get; set; }
        public double? FundPrice { get; set; }
        public int? InsuranceId { get; set; }
        public int? TaskOrderId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Insurance Insurance { get; set; }
        public virtual TaskOrders TaskOrder { get; set; }
    }
}
