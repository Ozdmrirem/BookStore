using BookStore.EntityLayer.Concrete;

namespace BookStore.Dtos.CategoryDtos
{
    public class ResultCategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Book> Book { get; set; }
    }
}
