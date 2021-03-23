using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Fund_system.Models
{
    public partial class TaskOrders
    {
        public TaskOrders()
        {
            TaskOnGoing = new HashSet<TaskOnGoing>();
        }

        public int TaskOrderId { get; set; }
        public string TaskOrderNo { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TaskOnGoing> TaskOnGoing { get; set; }
    }
}
