using BookStore.Dtos.BookDtos;

namespace BookStore.Services.BookService
{
    public interface IBookService
    {
        Task<List<ResultBookDto>> GetResultBookAsync();
        Task<GetByIdBookDto> GetByIdBookAsync(int id);
        Task CreateBookAsync(CreateBookDto createBookDto);
        Task UpdateBookAsync(UpdateBookDto updateBookDto);
        Task DeleteBookAsync(int id);
    }
}
