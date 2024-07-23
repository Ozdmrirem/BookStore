using BookStore.Context;
using BookStore.Dtos.AuthorDtos;
using Dapper;

namespace BookStore.Services.AuthorService
{
    public class AuthorService : IAuthorService
    {
        private readonly DapperContext _dapperContext;
        public AuthorService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateAuthorAsync(CreateAuthorDto createAuthorDto)
        {
            string query = "insert into Author (AuthorName,AuthorSurName,Details) values (@AuthorName,@AuthorSurname,@Details)";
            var parameters = new DynamicParameters();
            parameters.Add("@AuthorName", createAuthorDto.AuthorName);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task DeleteAuthorAsync(int id)
        {
            var query = "delete from Authors where AuthorId=@authorId";
            var parameters = new DynamicParameters();
            parameters.Add("@authorId", id);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task<List<ResultAuthorDto>> GetAllAuthorAsync()
        {
            var query = "select * from Authors";


            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultAuthorDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdAuthorDto> GetByIdAuthorAsync(int id)
        {
            var query = "select * from author where AuthorId = @AuthorId";
            var parameters = new DynamicParameters();
            parameters.Add("@AuthorId", id);

            using (var connection = _dapperContext.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdAuthorDto>(query, parameters);
                return value;
            }
        }

        public async Task UpdateAuthorAsync(UpdateAuthorDto updateAuthorDto)
        {
            var query = "update authors set AuthorName=@AuthorName where AuthorId=@AuthorId";
            var parameters = new DynamicParameters();
            parameters.Add("@AuthorName", updateAuthorDto.AuthorName);
            parameters.Add("@AuthorId", updateAuthorDto.AuthorId);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}

