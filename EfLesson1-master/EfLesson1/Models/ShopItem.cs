using System;
using System.Collections.Generic;
using System.Text;

namespace EfLesson1.Models
{
    public class ShopItem : BaseEntity
    {
        public int Price { get; set; }
        public int Size { get; set; }
        public string Brand { get; set; }
    }
}
