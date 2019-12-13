using System;
using System.Collections.Generic;
using System.Text;

namespace EfLesson1.Models
{
    public class Shop : BaseEntity
    {
        public virtual Address Address { get; set; }
        public string ShopName { get; set; }
        public virtual List<ShopItem> Stock { get; set; }

    }
}
