using BookStore.Dtos.SellingDtos;
using BookStore.Services.SellingService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellingsController : ControllerBase
    {
        private readonly ISellingService _sellingService;
        private object _sellingServices;

        public SellingsController(ISellingService sellingService)
        {
            _sellingService = sellingService;
        }
        [HttpGet]
        public async Task<IActionResult> SellingList()
        {
            var SellingList = await _sellingService.GetAllSellingAsync();
            return Ok(SellingList);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSelling(CreateSellingDto createSellingDto)
        {
            await _sellingService.CreateSellingAsync(createSellingDto);
            return Ok("satış başarıyla oluşturuldu.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSelling(UpdateSellingDto updateSellingDto)
        {
            await _sellingService.UpdateSellingAsync(updateSellingDto);
            return Ok("satış başarıyla güncellendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSelling(int id)
        {
            await _sellingService.DeleteSellingAsync(id);
            return Ok("satış başarıyla silindi.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdSelling(int id)
        {
            var value = await _sellingService.GetByIdSellingAsync(id);
            return Ok(value);
        }
    }
}
