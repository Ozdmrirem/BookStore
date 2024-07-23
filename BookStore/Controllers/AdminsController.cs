using BookStore.Dtos.AdminDtos;
using BookStore.Services.AdminService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminsController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        [HttpGet]
        public async Task<IActionResult> AdminList()
        {
            var adminList = await _adminService.GetAllAdminAsync();
            return Ok(adminList);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAdmin(CreateAdminDto createAdminDto)
        {
            await _adminService.CreateAdminAsync(createAdminDto);
            return Ok("admin başarıyla oluşturuldu.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAdmin(UpdateAdminDto updateAdminDto)
        {
            await _adminService.UpdateAdminAsync(updateAdminDto);
            return Ok("admin başarıyla güncellendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            await _adminService.DeleteAdminAsync(id);
            return Ok("admin başarıyla silindi.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAdmin(int id)
        {
            var value = await _adminService.GetByIdAdminAsync(id);
            return Ok(value);
        }
    }

}
