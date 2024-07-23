using BookStore.Context;
using BookStore.Dtos.CategoryDtos;
using Dapper;

namespace BookStore.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly DapperContext _dapperContext;

        public CategoryService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            string query = "insert into Categories (CategoryName) values (@CategoryName)";

            var parameters = new DynamicParameters();
            parameters.Add("@CategoryName", createCategoryDto.CategoryName);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var query = "Delete from Categories where CategoryId=@CategoryId";

            var parameters = new DynamicParameters();
            parameters.Add("@CategoryId", id);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var query = "select * from Categories";

            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(int id)
        {
            var query = "select * from Categories where CategoryId = @CategoryId";

            var parameters = new DynamicParameters();
            parameters.Add("@CategoryId", id);

            using (var connection = _dapperContext.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdCategoryDto>(query, parameters);
                return value;
            }
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var query = "update Categories set CategoryName=@CategoryName where CategoryId=@CategoryId";

            var parameters = new DynamicParameters();
            parameters.Add("@CategoryName", updateCategoryDto.CategoryName);
            parameters.Add("@CategoryId", updateCategoryDto.CategoryId);


            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
