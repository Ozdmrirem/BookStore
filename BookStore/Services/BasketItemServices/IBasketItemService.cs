using BookStore.Dtos.BasketItemDtos;
using BookStore.Dtos.BasketItemDtos.BookStore.Dtos.BasketTotalDtos;
using BookStore.EntityLayer.Concrete;

namespace BookStore.Services.BasketItemService
{
    public interface IBasketItemService
    {
        Task<List<ResultBasketItemDto>> GetBasketItemsByUserIdAsync(string userId);
        Task<GetByIdBasketItemDto> GetBasketItemByIdAsync(int id);
        Task CreateBasketItemAsync(CreateBasketItemDto createBasketItemDto);
        Task UpdateBasketItemAsync(UpdateBasketItemDto updateBasketItemDto);
        Task DeleteBasketItemAsync(int id);
    }
}