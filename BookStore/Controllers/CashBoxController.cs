using BookStore.Dtos.CashBoxDtos;
using BookStore.Services.CashBoxService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashBoxController : ControllerBase
    {
        private readonly ICashBoxService _cashboxService;

        public CashBoxController(ICashBoxService cashboxService)
        {
            _cashboxService = cashboxService;
        }

        [HttpGet]
        public async Task<IActionResult> CashBoxList()
        {
            var CashBoxList = await _cashboxService.GetAllCashBoxAsync();
            return Ok(CashBoxList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCashBox(CreateCashBoxDto createCashBoxDto)
        {
            await _cashboxService.CreateCashBoxAsync(createCashBoxDto);
            return Ok("kasa başarıyla oluşturuldu.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCashBox(UpdateCashBoxDto updateCashBoxDto)
        {
            await _cashboxService.UpdateCashBoxAsync(updateCashBoxDto);
            return Ok("kasa başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCashBox(int id)
        {
            await _cashboxService.DeleteCashBoxAsync(id);
            return Ok("kasa başarıyla silindi.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCashBox(int id)
        {
            var value = await _cashboxService.GetByIdCashBoxAsync(id);
            return Ok(value);
        }
    }
}