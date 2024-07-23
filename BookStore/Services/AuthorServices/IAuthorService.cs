using BookStore.Dtos.AuthorDtos;

namespace BookStore.Services.AuthorService
{
    public interface IAuthorService
    {
        Task<List<ResultAuthorDto>> GetAllAuthorAsync();
        Task<GetByIdAuthorDto> GetByIdAuthorAsync(int id);
        Task CreateAuthorAsync(CreateAuthorDto createAuthorDto);
        Task UpdateAuthorAsync(UpdateAuthorDto updateAuthorDto);
        Task DeleteAuthorAsync(int id);
    }
}
