using BookStore.Dtos.BookDtos;
using BookStore.Services.BookService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService bookService;
        private IBookService _bookService;

        public BooksController(IBookService BookService) => _bookService = BookService;

        [HttpGet]
        public async Task<IActionResult> BookList()
        {
            var bookList = await _bookService.GetResultBookAsync();
            return Ok(bookList);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookDto createBookDto)
        {
            await _bookService.CreateBookAsync(createBookDto);
            return Ok("Kitap başarıyla oluşturuldu.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBook(UpdateBookDto updateBookDto)
        {
            await _bookService.UpdateBookAsync(updateBookDto);
            return Ok("Kitap başarıyla güncellendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookService.DeleteBookAsync(id);
            return Ok("Kitap başarıyla silindi.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdBook(int id)
        {
            var value = await _bookService.GetByIdBookAsync(id);
            return Ok(value);
        }
    }

}