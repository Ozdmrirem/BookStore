using BookStore.EntityLayer.Concrete;

namespace BookStore.Dtos.BasketTotalDtos
{
    public class ResultBasketTotalDto
    {
        public string UserId { get; set; }
        public List<BasketItem> BasketItems { get; set; }
        public decimal TotalPrice { get => BasketItems.Sum(x => x.Price * x.Quantity); }
    }
}
