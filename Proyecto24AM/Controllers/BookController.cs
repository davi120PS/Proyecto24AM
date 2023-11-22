using Microsoft.AspNetCore.Mvc;
using Proyecto24AM.Models.Entities;
using Proyecto24AM.Services.IServices;

namespace Proyecto24AM.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookServices _bookServices;
        //Instancia la clase IArticleServices en todo el proyecto para usar todos lo metodos creados
        public BookController(IBookServices bookServices)
        {
            _bookServices = bookServices;
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
                return View(await _bookServices.GetBooks());
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
        public IActionResult Crear(Book request)
        {
            try
            {
                var response = _bookServices.CreateBook(request);
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
            var response = await _bookServices.GetByIdBook(id);
            return View(response);
        }
        [HttpPost]
        public IActionResult Editar(Book request)
        {
            try
            {
                var response = _bookServices.EditBook(request);
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
                bool response = _bookServices.DeleteBook(id);
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
