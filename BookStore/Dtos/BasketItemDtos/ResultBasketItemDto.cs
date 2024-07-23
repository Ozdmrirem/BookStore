namespace BookStore.Dtos.BasketItemDtos
{
    public class ResultBasketItemDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookImageUrl { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string UserId { get; set; }
    }
}
