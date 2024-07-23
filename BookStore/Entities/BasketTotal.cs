using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.EntityLayer.Concrete
{
    public class BasketTotal
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<BasketItem> BasketItems { get; set; }
        public decimal TotalPrice => BasketItems?.Sum(x => x.Price * x.Quantity) ?? 0;
        public DateTime CreatedDate { get; set; }
    }
}
