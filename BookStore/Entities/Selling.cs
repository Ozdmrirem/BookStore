using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.EntityLayer.Concrete
{
    public class Selling
    {
        public int SellingId { get; set; }
        public int BookId { get; set; }
        public int AppUserId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime BuyingDate { get; set; }
        public DateTime SellingDate { get; set; }
        public Book Book { get; set; }
        public Employee Employee { get; set; }
    }
}
