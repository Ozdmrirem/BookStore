using BookStore.EntityLayer.Concrete;

namespace BookStore.Dtos.AuthorDtos
{
    public class ResultAuthorDto
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public string Detail { get; set; }
    }
}
