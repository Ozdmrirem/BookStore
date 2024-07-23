using BookStore.EntityLayer.Concrete;

namespace BookStore.Dtos.SellingDtos
{
    public class SellingDto
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

    public class CreateSellingDto
    {
        public int BookId { get; set; }
        public int AppUserId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime BuyingDate { get; set; }
        public DateTime SellingDate { get; set; }
        public Book Book { get; set; }
        //public AppUser AppUser { get; set; }
        public Employee Employee { get; set; }
    }
}
