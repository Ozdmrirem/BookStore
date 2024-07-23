using BookStore.EntityLayer.Concrete;

namespace BookStore.Dtos.AuthorDtos
{
    public class UpdateAuthorDto
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public string Detail { get; set; }
        public List<Book> Books { get; set; }
    }
}
