using BookStore.Dtos.BasketTotalDtos;
using BookStore.Services.BasketTotalService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketTotalsController : ControllerBase
    {
        private readonly IBasketTotalService _basketTotalService;

        public BasketTotalsController(IBasketTotalService basketTotalService)
        {
            _basketTotalService = basketTotalService;
        }

        [HttpGet]
        public async Task<IActionResult> BasketTotalList()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var basketTotals = await _basketTotalService.GetBasketTotalsByUserIdAsync(userId);
            return Ok(basketTotals);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBasketTotal(CreateBasketTotalDto createBasketTotalDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _basketTotalService.CreateBasketTotalAsync(createBasketTotalDto, userId);
            return Ok("Basket total başarıyla oluşturuldu.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBasketTotal(UpdateBasketTotalDto updateBasketTotalDto)
        {
            await _basketTotalService.UpdateBasketTotalAsync(updateBasketTotalDto);
            return Ok("Basket total başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasketTotal(int id)
        {
            await _basketTotalService.DeleteBasketTotalAsync(id);
            return Ok("Basket total başarıyla silindi.");
        }
    }
}

