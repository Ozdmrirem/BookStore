using BookStore.Services.AuthorService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.EntityLayer.Concrete;
using BookStore.Dtos.AuthorDtos;
using BookStore.Dtos.AdminDtos;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> AuthorList()
        {
            var authorList = await _authorService.GetAllAuthorAsync();
            return Ok(authorList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorDto createAuthorDto)
        {
            await _authorService.CreateAuthorAsync(createAuthorDto);
            return Ok("Yazar başarıyla oluşturuldu.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorDto updateAuthorDto)
        {
            await _authorService.UpdateAuthorAsync(updateAuthorDto);
            return Ok("Yazar başarıyla güncellendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            await _authorService.DeleteAuthorAsync(id);
            return Ok("Yazar başarıyla silindi.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAuthor(int id)
        {
            var value = await _authorService.GetByIdAuthorAsync(id);
            return Ok(value);
        }
    }

}




