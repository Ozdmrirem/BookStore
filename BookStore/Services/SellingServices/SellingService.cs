using BookStore.Context;
using BookStore.Dtos.SellingDtos;
using Dapper;

namespace BookStore.Services.SellingService
{
    public class SellingService : ISellingService
    {
        private readonly DapperContext _dapperContext;

        public SellingService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateSellingAsync(CreateSellingDto createSellingDto)
        {
            string query = "INSERT INTO Sellings (BookId, AppUserId, EmployeeId, BuyingDate, SellingDate) VALUES (@BookId, @AppUserId, @EmployeeId, @BuyingDate, @SellingDate)";

            var parameters = new DynamicParameters();
            parameters.Add("@BookId", createSellingDto.BookId);
            parameters.Add("@AppUserId", createSellingDto.AppUserId);
            parameters.Add("@EmployeeId", createSellingDto.EmployeeId);
            parameters.Add("@BuyingDate", createSellingDto.BuyingDate);
            parameters.Add("@SellingDate", createSellingDto.SellingDate);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteSellingAsync(int id)
        {
            var query = "DELETE FROM Sellings WHERE SellingId = @SellingId";

            var parameters = new DynamicParameters();
            parameters.Add("@SellingId", id);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultSellingDto>> GetAllSellingAsync()
        {
            var query = "select * from Sellings";

            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultSellingDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdSellingDto> GetByIdSellingAsync(int id)
        {
            var query = "SELECT * FROM Sellings WHERE SellingId = @SellingId";

            var parameters = new DynamicParameters();
            parameters.Add("@SellingId", id);

            using (var connection = _dapperContext.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdSellingDto>(query, parameters);
                return value;
            }
        }



        public async Task UpdateSellingAsync(UpdateSellingDto updateSellingDto)
        {
            var query = "UPDATE Sellings SET BookId = @BookId, AppUserId = @AppUserId, EmployeeId = @EmployeeId, BuyingDate = @BuyingDate, SellingDate = @SellingDate WHERE SellingId = @SellingId";

            var parameters = new DynamicParameters();
            parameters.Add("@BookId", updateSellingDto.BookId);
            parameters.Add("@AppUserId", updateSellingDto.AppUserId);
            parameters.Add("@EmployeeId", updateSellingDto.EmployeeId);
            parameters.Add("@BuyingDate", updateSellingDto.BuyingDate);
            parameters.Add("@SellingDate", updateSellingDto.SellingDate);
            parameters.Add("@SellingId", updateSellingDto.SellingId);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
