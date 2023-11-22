using Proyecto24AM.Models.Entities;

namespace Proyecto24AM.Services.IServices
{
    public interface IBookServices
    {
        public Task<List<Book>> GetBooks();
        public Task<Book> GetByIdBook(int id);
        public Task<Book> CreateBook(Book i);
        public Task<Book> EditBook(Book i);
        public bool DeleteBook(int id);
    }
}
