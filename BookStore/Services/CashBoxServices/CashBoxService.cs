using BookStore.Context;
using BookStore.Dtos.CashBoxDtos;
using Dapper;


namespace BookStore.Services.CashBoxService
{
    public class CashBoxService : ICashBoxService
    {
        private readonly DapperContext _dapperContext;

        public CashBoxService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateCashBoxAsync(CreateCashBoxDto createCashBoxDto)
        {
            string query = "insert into CashBox (Month,Amount) values (@Month,@Amount)";

            var parameters = new DynamicParameters();
            parameters.Add("@Month", createCashBoxDto.Month);
            parameters.Add("@Amount", createCashBoxDto.Amount);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCashBoxAsync(int id)
        {
            var query = "Delete from CashBox where CashBoxId=@CashBoxId";
            var parameters = new DynamicParameters();
            parameters.Add("@CashBox", id);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }


        public async Task<GetByIdCashBoxDto> GetByIdCashBoxAsync(int id)
        {
            var query = "select * from CashBox where CashBoxId = @CashBoxId";
            var parameters = new DynamicParameters();
            parameters.Add("@CashBoxId", id);

            using (var connection = _dapperContext.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdCashBoxDto>(query, parameters);
                return value;
            }
        }

        public async Task<List<ResultCashBoxDto>> GetResultCashBoxAsync()
        {
            var query = "select * from CashBox";

            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCashBoxDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateCashBoxAsync(UpdateCashBoxDto updateCashBoxDto)
        {
            var query = "update CashBox set CashBox=@CashBox where CashBoxId=@CashBoxId";

            var parameters = new DynamicParameters();
            parameters.Add("@CashBoxId", updateCashBoxDto.CashBoxId);
            parameters.Add("@Month", updateCashBoxDto.Month);
            parameters.Add("@Amount", updateCashBoxDto.Amount);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCashBoxDto>> GetAllCashBoxAsync()
        {
            var query = "select * from CashBox";

            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCashBoxDto>(query);
                return values.ToList();
            }
        }
    }
}
