using BookStore.Context;
using BookStore.Dtos.AdminDtos;
using Dapper;

namespace BookStore.Services.AdminService
{
    public class AdminService : IAdminService
    {
        private readonly DapperContext _dapperContext;

        public AdminService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateAdminAsync(CreateAdminDto createAdminDto)
        {
            string query = "insert into Admins (AdminName) values (@AdminName)";
            
            var parameters = new DynamicParameters();
            parameters.Add("@AdminName", createAdminDto.AdminName);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
            }
        }

        public async Task DeleteAdminAsync(int id)
        {
            var query = "Delete from Admins where AdminId=@adminId";

            var parameters = new DynamicParameters();
            parameters.Add("@adminId", id);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultAdminDto>> GetAllAdminAsync()
        {
            var query = "select * from Admins";

            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultAdminDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdAdminDto> GetByIdAdminAsync(int id)
        {
            var query = "select * from Admins where AdminId = @adminId";

            var parameters = new DynamicParameters();
            parameters.Add("@adminId",id);

            using (var connection = _dapperContext.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdAdminDto>(query,parameters);
                return value;
            }
        }

        public async Task UpdateAdminAsync(UpdateAdminDto updateAdminDto)
        {
            var query = "update Admins set AdminName=@adminName where AdminId=@adminId";

            var parameters = new DynamicParameters();
            parameters.Add("@adminName",updateAdminDto.AdminName);
            parameters.Add("@adminId",updateAdminDto.AdminId);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
            }
        }
    }
}
