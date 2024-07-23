using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.EntityLayer.Concrete
{
    public class CashBox
    {
        public int CashBoxId { get; set; }
        public string Month { get; set; }
        public decimal Amount { get; set; }
    }
}
