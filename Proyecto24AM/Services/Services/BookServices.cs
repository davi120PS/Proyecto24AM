using Proyecto24AM.Context;
using Proyecto24AM.Services.IServices;
using Proyecto24AM.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Azure.Core;

namespace Proyecto24AM.Services.Services
{
    public class BookServices : IBookServices
    {
        private readonly ApplicationDbContext _context;
        public BookServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Book>> GetBooks()
        {
            try
            {
                return await _context.Books.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Surgió un error" + ex.Message);
            }
        }
        public async Task<Book> GetByIdBook(int id)
        {
            try
            {
                Book response = await _context.Books.FirstOrDefaultAsync(x => x.PKBook == id);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgió un error" + ex.Message);
            }
        }
        public async Task<Book> CreateBook(Book i)
        {
            try
            {
                Book request = new Book()
                {
                    Title = i.Title,
                    Description = i.Description,
                    Images = i.Images,
                    Active = true
                };
                //Con esto se manda a la bd de forma asincrona
                var result = await _context.Books.AddAsync(request);
                _context.SaveChanges();

                return request;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgió un error" + ex.Message);
            }
        }
        public async Task<Book> EditBook(Book i)
        {
            try
            {
                Book request = _context.Books.Find(i.PKBook);
                request.Title = i.Title;
                request.Description = i.Description;
                request.Images = i.Images;
                request.Active = i.Active;
                //Con esto se manda a la bd de forma asincrona

                _context.Entry(request).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return request;

                /*var result = _context.Articles.Update(request);
                await _context.SaveChangesAsync();

                return request;*/
            }
            catch (Exception ex)
            {
                throw new Exception("Surgió un error" + ex.Message);
            }
        }
        public async Task<Book> DeleteBook(Book i)
        {
            try
            {
                Book request = _context.Books.Find(i);
                if (request != null)
                {
                    var result = _context.Books.Remove(request);
                    await _context.SaveChangesAsync();
                }
                else
                    Console.WriteLine("No existe el registro");
                //Con esto se manda a la bd de forma asincrona

                return request;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgió un error" + ex.Message);
            }
        }
        public bool DeleteBook(int id)
        {
            try
            {
                Book book = _context.Books.Find(id);

                if (book != null)
                {
                    var res = _context.Books.Remove(book);
                    _context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgió un error" + ex.Message);
            }
        }
    }
}
