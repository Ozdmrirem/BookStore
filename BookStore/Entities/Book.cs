using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.EntityLayer.Concrete
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public Category Category { get; set; }
        public Author Author { get; set; }
        public string Year { get; set; }
        public string Publisher { get; set; }
        public string TotalPage { get; set; }
        public string BookImageUrl { get; set; }
    }
}
