using Microsoft.AspNetCore.Mvc;
using Proyecto24AM.Models.Entities;
using Proyecto24AM.Services.IServices;

namespace Proyecto24AM.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleServices _articleServices;
        //Instancia la clase IArticleServices en todo el proyecto para usar todos lo metodos creados
        public ArticleController(IArticleServices articleServices)  
        {
            _articleServices = articleServices;
        }

        [HttpGet]
        public async Task<IActionResult> Index()//Crea un metodo para llamar a la vista Index(en views/article/index.chtml)
        {
            try
            {
                //Regresa la lista de articulos con variable
                /*var response = await _articleServices.GetArticles();
                return View(response);*/
                // Regresa la lista de articulos de manera directa
                return View(await _articleServices.GetArticles());
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

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var response = await _articleServices.GetByIdArticle(id);
            return View(response);
        }
        [HttpPost]
        public IActionResult Editar(Article request)
        {
            try
            {
                var response = _articleServices.EditArticle(request);
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
                bool response = _articleServices.DeleteArticle(id);
                if (response = true)
                {
                    return Json(new { succes = true });
                }
                else
                {
                    return Json(new { succes = false });
                }
                //return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }
    }
}
