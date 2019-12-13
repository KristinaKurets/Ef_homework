using System;
using System.Collections.Generic;
using System.Text;

namespace EfLesson1.Models
{
    public class Seller : BaseEntity
    {
        public string Name { get; set; }
        public virtual Shop Shop { get; set; }
    }
}
