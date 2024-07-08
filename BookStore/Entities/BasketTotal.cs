using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapMagaza.EntityLayer.Concrete
{
    public class BasketTotal
    {
        public string UserId { get; set; }
        public List<BasketItem> BasketItems { get; set; }
        public decimal TotalPrice { get => BasketItems.Sum(x => x.Price * x.Quantity); }
    }
}
