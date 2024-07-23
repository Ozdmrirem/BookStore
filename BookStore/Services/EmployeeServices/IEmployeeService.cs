using BookStore.Dtos.EmployeeDtos;

namespace BookStore.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task<List<ResultEmployeeDto>> GetAllEmployeesAsync();
        Task<GetByIdEmployeeDto> GetByIdEmployeeAsync(int id);
        Task CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto);
        Task UpdateEmployeeAsync(UpdateEmployeeDto updateEmployeeDto);
        Task DeleteEmployeeAsync(int id);
    }
}
