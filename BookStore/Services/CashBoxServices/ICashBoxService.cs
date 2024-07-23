using BookStore.Dtos.CashBoxDtos;

namespace BookStore.Services.CashBoxService
{
    public interface ICashBoxService
    {
        Task<List<ResultCashBoxDto>> GetAllCashBoxAsync();
        Task<GetByIdCashBoxDto> GetByIdCashBoxAsync(int id);
        Task CreateCashBoxAsync(CreateCashBoxDto createCashBoxDto);
        Task UpdateCashBoxAsync(UpdateCashBoxDto updateCashBoxDto);
        Task DeleteCashBoxAsync(int id);
        
    }
}
