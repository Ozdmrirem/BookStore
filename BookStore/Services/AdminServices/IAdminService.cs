using BookStore.Dtos.AdminDtos;

namespace BookStore.Services.AdminService
{
    public interface IAdminService
    {
        Task<List<ResultAdminDto>> GetAllAdminAsync();
        Task<GetByIdAdminDto> GetByIdAdminAsync(int id);
        Task CreateAdminAsync(CreateAdminDto createAdminDto);
        Task UpdateAdminAsync(UpdateAdminDto updateAdminDto);
        Task DeleteAdminAsync(int id);
    }
}
