using Proyecto24AM.Models.Entities;

namespace Proyecto24AM.Services.IServices
{
    public interface IArticleServices
    {
        public Task<List<Article>> GetArticles();
        public Task<Article> GetByIdArticle(int id);
        public Task<Article> CreateArticle(Article i);
    }
}
