using MyProject.Data;
using MyProject.Models;

namespace MyProject.Repositories
{
    public interface IBookRepositories
    {
        public Task<List<BookModel>> GetAllBooksAsync();
        public Task<BookModel> GetBookAsync(int id);
        public Task<int> AddBookAsync(BookModel model);
        public Task<int> UpdateBookAsync(int id, BookModel model);
        public Task DeleteBookAsync(int id);
    }
}
