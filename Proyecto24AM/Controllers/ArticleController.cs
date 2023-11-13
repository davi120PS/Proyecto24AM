using Microsoft.AspNetCore.Mvc;
using Proyecto24AM.Models.Entities;
using Proyecto24AM.Services.IServices;

namespace Proyecto24AM.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleServices _articleServices;
        public ArticleController(IArticleServices articleServices)
        {
            _articleServices = articleServices;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _articleServices.GetArticles();
                return View(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Crear(Article request) 
        {
            try
            {
                var response = _articleServices.CreateArticle(request);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }
        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            try
            {
                var response = _articleServices.DeleteArticle(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }
    }
}
