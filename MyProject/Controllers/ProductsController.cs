using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using MyProject.Repositories;

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IBookRepositories _bookrepo;

        public ProductsController(IBookRepositories repo)
        {
            _bookrepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                return Ok(await _bookrepo.GetAllBooksAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookrepo.GetBookAsync(id);
            return book == null ? NotFound() : Ok(book);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddNewBook(BookModel model)
        {
            try
            {
                var newBookId = await _bookrepo.AddBookAsync(model);
                var book = await _bookrepo.GetBookAsync(newBookId);
                return book == null ? NotFound() : Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateBook(int id, BookModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            await _bookrepo.UpdateBookAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookrepo.DeleteBookAsync(id);
            return Ok();
        }
    }
}
