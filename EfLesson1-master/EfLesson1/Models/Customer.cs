using System;
using System.Collections.Generic;
using System.Text;

namespace EfLesson1.Models
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }

        public DateTime LastVisit { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}
