using BookStore.Dtos.EmployeeDtos;
using BookStore.Services.EmployeeService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeesService;

        public EmployeesController(IEmployeeService employeesService)
        {
            _employeesService = employeesService;
        }

        [HttpGet]
        public async Task<IActionResult> EmployeesList()
        {
            var employeesList = await _employeesService.GetAllEmployeesAsync();
            return Ok(employeesList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployees([FromBody] CreateEmployeeDto createEmployeesDto)
        {
            await _employeesService.CreateEmployeeAsync(createEmployeesDto);
            return Ok("Personel başarıyla oluşturuldu.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployees([FromBody] UpdateEmployeeDto updateEmployeesDto)
        {
            await _employeesService.UpdateEmployeeAsync(updateEmployeesDto);
            return Ok("Personeller başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployees(int id)
        {
            await _employeesService.DeleteEmployeeAsync(id);
            return Ok("Personel başarıyla silindi.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdEmployees(int id)
        {
            var value = await _employeesService.GetByIdEmployeeAsync(id);
            return Ok(value);
        }
    }
}