using BookStore.Dtos.BasketTotalDtos;
using BookStore.EntityLayer.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Services.BasketTotalService
{
    public interface IBasketTotalService
    {
        Task<IEnumerable<BasketTotal>> GetBasketTotalsByUserIdAsync(string userId);
        Task<BasketTotal> GetBasketTotalByIdAsync(int id);
        Task CreateBasketTotalAsync(CreateBasketTotalDto createBasketTotalDto, string userId);
        Task UpdateBasketTotalAsync(UpdateBasketTotalDto updateBasketTotalDto);
        Task DeleteBasketTotalAsync(int id);
    }
}
