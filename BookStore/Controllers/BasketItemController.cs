using BookStore.Dtos.BasketItemDtos;
using BookStore.Dtos.BasketItemDtos.BookStore.Dtos.BasketTotalDtos;
using BookStore.Services.BasketItemService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketItemsController : ControllerBase
    {
        private readonly IBasketItemService _basketItemService;

        public BasketItemsController(IBasketItemService basketItemService)
        {
            _basketItemService = basketItemService;
        }

        [HttpGet]
        public async Task<IActionResult> BasketItemList()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var basketItems = await _basketItemService.GetBasketItemsByUserIdAsync(userId);
            return Ok(basketItems);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBasketItem(CreateBasketItemDto createBasketItemDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _basketItemService.CreateBasketItemAsync(createBasketItemDto);
            return Ok("Basket item başarıyla oluşturuldu.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBasketItem(UpdateBasketItemDto updateBasketItemDto)
        {
            await _basketItemService.UpdateBasketItemAsync(updateBasketItemDto);
            return Ok("Basket item başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasketItem(int id)
        {
            await _basketItemService.DeleteBasketItemAsync(id);
            return Ok("Basket item başarıyla silindi.");
        }
    }
}
