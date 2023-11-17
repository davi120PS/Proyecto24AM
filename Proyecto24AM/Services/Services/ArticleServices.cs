using Proyecto24AM.Context;
using Proyecto24AM.Services.IServices;
using Proyecto24AM.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Azure.Core;

namespace Proyecto24AM.Services.Services
{
    public class ArticleServices : IArticleServices
    {
        private readonly ApplicationDbContext _context;
        public ArticleServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Article>> GetArticles()
        {
            try
            {
                return await _context.Articles.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Surgió un error" + ex.Message);
            }
        }
        public async Task<Article> GetByIdArticle(int id)
        {
            try
            {
                Article response = await _context.Articles.FirstOrDefaultAsync(x => x.PKArticle == id);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgió un error" + ex.Message);
            }
        }
        public async Task<Article> CreateArticle(Article i)
        {
            try
            {
                Article request = new Article()
                {
                    Name = i.Name,
                    Description = i.Description,
                    Price = i.Price
                };
                //Con esto se manda a la bd de forma asincrona
                var result = await _context.Articles.AddAsync(request);
                 _context.SaveChanges();

                return request;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgió un error" + ex.Message);
            }
        }
        public async Task<Article> EditArticle(Article i)
        {
            try
            {
                Article request = _context.Articles.Find(i.PKArticle);
                request.Name = i.Name;
                request.Description = i.Description;
                request.Price = i.Price;
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
        public async Task<Article> DeleteArticle(Article i)
        {
            try
            {
                Article request = _context.Articles.Find(i);
                if (request != null)
                {
                    var result = _context.Articles.Remove(request);
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
        public bool DeleteArticle (int id)
        {
            try
            {
                Article article = _context.Articles.Find(id);
                
                if (article != null)
                {
                    var res = _context.Articles.Remove(article);
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
