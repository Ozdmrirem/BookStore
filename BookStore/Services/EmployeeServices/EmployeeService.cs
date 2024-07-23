using BookStore.Context;
using BookStore.Dtos.EmployeeDtos;
using Dapper;

namespace BookStore.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DapperContext _dapperContext;

        public EmployeeService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto)
        {
            string query = "insert into Employees (EmployeeName) values (@EmployeeName)";

            var parameters = new DynamicParameters();
            parameters.Add("@EmployeName", createEmployeeDto.EmployeeName);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var query = "Delete from Employees where EmployeeId=@EmployeeId";

            var parameters = new DynamicParameters();
            parameters.Add("@EmployeeId", id);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }



        public async Task<GetByIdEmployeeDto> GetByIdEmployeeAsync(int id)
        {
            var query = "select * from Admins where EmployeeId = @EmployeeId";

            var parameters = new DynamicParameters();
            parameters.Add("@EmployeeId", id);

            using (var connection = _dapperContext.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdEmployeeDto>(query, parameters);
                return value;
            }
        }

        public async Task<List<ResultEmployeeDto>> GetAllEmployeesAsync()
        {
            var query = "select * from Employees";

            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultEmployeeDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateEmployeeAsync(UpdateEmployeeDto updateEmployeeDto)
        {
            var query = "update Employees set EmployeeName=@EmployeeName where EmployeeId=@EmployeeId";

            var parameters = new DynamicParameters();
            parameters.Add("@EmployeeName", updateEmployeeDto.EmployeeName);
            parameters.Add("@EmployeeId", updateEmployeeDto.EmployeeId);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
