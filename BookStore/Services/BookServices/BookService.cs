using BookStore.Context;
using BookStore.Dtos.BookDtos;
using Dapper;

namespace BookStore.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly DapperContext _dapperContext;

        public BookService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateBookAsync(CreateBookDto createBookDto)
        {
            string query = "insert into Book (BookName,CategoryId,AuthorId,Category,Author,Year,Publisher,TotalPage,BookImageUrl) values (@BookName,@CategoryId,@AuthorId,@Category,@Author,@Year,@Publisher,@TtotalPage,@BookImageUrl)";

            var parameters = new DynamicParameters();
            parameters.Add("@BookName", createBookDto.BookName);
            parameters.Add("@Category", createBookDto.Category);
            parameters.Add("@Author", createBookDto.Author);
            parameters.Add("@Year", createBookDto.Year);
            parameters.Add("@Publisher", createBookDto.Publisher);
            parameters.Add("@TotalPage", createBookDto.TotalPage);
            parameters.Add("@BookImageUrl", createBookDto.BookImageUrl);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task DeleteBookAsync(int id)
        {
            var query = "Delete from Books where BookId=@BookId";

            var parameters = new DynamicParameters();
            parameters.Add("@BookId", id);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }


        public async Task<GetByIdBookDto> GetByIdBookAsync(int id)
        {
            var query = "select * from Books where BookId = @BookId";

            var parameters = new DynamicParameters();
            parameters.Add("@BookId", id);


            using (var connection = _dapperContext.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdBookDto>(query, parameters);
                return value;
            }
        }

        public async Task<List<ResultBookDto>> GetResultBookAsync()
        {
            var query = "select * from Books";

            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultBookDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateBookAsync(UpdateBookDto updateBookDto)
        {
            var query = "update Books set BookName=@BookName where BookId=@BookId";

            var parameters = new DynamicParameters();
            parameters.Add("@BookName", updateBookDto.BookName);
            parameters.Add("@BookId", updateBookDto.BookId);
            parameters.Add("@CategoryId", updateBookDto.CategoryId);
            parameters.Add("@AuthorId", updateBookDto.AuthorId);
            parameters.Add("@Category", updateBookDto.CategoryId);
            parameters.Add("@Author", updateBookDto.Author);
            parameters.Add("@Year", updateBookDto.Year);
            parameters.Add("@Publisher", updateBookDto.Publisher);
            parameters.Add("@TotalPage", updateBookDto.TotalPage);
            parameters.Add("@BookImageUrl", updateBookDto.BookImageUrl);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
