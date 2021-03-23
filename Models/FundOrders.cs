using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Fund_system.Models
{
    public partial class FundOrders
    {
        public int FundOrderId { get; set; }
        public string OrderNoUnits { get; set; }
        public int? FundId { get; set; }
        public double? FundPrice { get; set; }
        public string DateOrder { get; set; }
        public double? OrderAmount { get; set; }
        public string TypeOrder { get; set; }
        public int? FundOrderNo { get; set; }
        public string FundOrderStatus { get; set; }
    }
}
