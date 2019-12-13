using System;
using System.Collections.Generic;
using System.Text;

namespace EfLesson1.Models
{
    public class Address : BaseEntity
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
    }
}
