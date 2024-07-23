using BookStore.Dtos.SellingDtos;

namespace BookStore.Services.SellingService
{
    public interface ISellingService
    {
        Task<List<ResultSellingDto>> GetAllSellingAsync();
        Task<GetByIdSellingDto> GetByIdSellingAsync(int id);
        Task CreateSellingAsync(CreateSellingDto createSellingDto);
        Task UpdateSellingAsync(UpdateSellingDto updateSellingDto);
        Task DeleteSellingAsync(int id);
    }
}
