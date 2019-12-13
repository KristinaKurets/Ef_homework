using System;
using System.Collections.Generic;
using System.Text;

namespace EfLesson1.Models
{
    public class Order : BaseEntity
    {
        public virtual List<ShopItem> Items {get;set;}
        public DateTime OrderDate { get; set; }

        public virtual Shop Shop { get; set; }
    }
}
