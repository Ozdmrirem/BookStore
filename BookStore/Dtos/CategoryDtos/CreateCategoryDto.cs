using BookStore.EntityLayer.Concrete;

namespace BookStore.Dtos.CategoryDtos
{
    public class CreateCategoryDto
    {
        public string CategoryName { get; set; }
        public List<Book> Book { get; set; }
    }
}
