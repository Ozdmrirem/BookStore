using BookStore.Context;
using BookStore.Dtos.BasketItemDtos;
using BookStore.Dtos.BasketItemDtos.BookStore.Dtos.BasketTotalDtos;
using BookStore.EntityLayer.Concrete;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.BasketItemService
{
    public class BasketItemService : IBasketItemService
    {
        private readonly DapperContext _dapperContext;

        public BasketItemService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task CreateBasketItemAsync(CreateBasketItemDto createBasketItemDto)
        {
            string query = "insert into BasketItems (BookId,BookName,BookImageUrl,Quantity,Price,UserId) values (@BookId,@BookName,@BookImageUrl,@Quantity,@Price,@UserId)";
            
            var parameters = new DynamicParameters();
            
            parameters.Add("@BookId", createBasketItemDto.BookId);
            parameters.Add("@BookName", createBasketItemDto.BookName);
            parameters.Add("@BookImageUrl", createBasketItemDto.BookImageUrl);
            parameters.Add("@Quantity", createBasketItemDto.Quantity);
            parameters.Add("@Price", createBasketItemDto.Price);
            parameters.Add("@UserId", createBasketItemDto.UserId);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
            }
        }

        public async Task DeleteBasketItemAsync(int id)
        {
            var query = "Delete from BasketItems where BookId=@BookId";

            var parameters = new DynamicParameters();
            parameters.Add("@BookId", id);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetByIdBasketItemDto> GetBasketItemByIdAsync(int id)
        {
            var query = "select * from BasketItems where Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            parameters.Add("@BookId", id);
            parameters.Add("@BookImageUrl", id);
            parameters.Add("@Quantity", id);
            parameters.Add("@Price", id);
            parameters.Add("@UserId", id);


            using (var connection = _dapperContext.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdBasketItemDto>(query, parameters);
                return value;
            }
        }

        public async Task<List<ResultBasketItemDto>> GetBasketItemsByUserIdAsync(string userId)
        {
            var query = "select * from BasketItems";

            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultBasketItemDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateBasketItemAsync(UpdateBasketItemDto updateBasketItemDto)
        {
            var query = "update Admins set AdminName=@adminName where AdminId=@adminId";

            var parameters = new DynamicParameters();
            parameters.Add("@Id", updateBasketItemDto.Id);
            parameters.Add("@BookId", updateBasketItemDto.BookId);
            parameters.Add("@BookName", updateBasketItemDto.BookName);
            parameters.Add("@BookImageUrl", updateBasketItemDto.BookImageUrl);
            parameters.Add("@Quantity", updateBasketItemDto.Quantity);
            parameters.Add("@Price", updateBasketItemDto.Price);
            parameters.Add("@UserId", updateBasketItemDto.UserId);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
