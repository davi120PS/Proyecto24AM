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
        public async Task< List<Article>> GetArticles()
        {
            try
            {
                return await _context.Articles.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception ("Surgió un error" + ex.Message);
            }
        }
        public async Task<Article> GetByIdArticle(int id)
        {
            try
            {
                Article response = await _context.Articles.FirstOrDefaultAsync(x=>x.PKArticle == id);
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
                var result = _context.Articles.Add(request);
                await _context.SaveChangesAsync();

                return request;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgió un error" + ex.Message);
            }
        }
    }
}
