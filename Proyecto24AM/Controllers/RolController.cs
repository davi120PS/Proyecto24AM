using Microsoft.AspNetCore.Mvc;
using Proyecto24AM.Models.Entities;
using Proyecto24AM.Services.IServices;
using Proyecto24AM.Services.Services;

namespace Proyecto24AM.Controllers
{
    public class RolController : Controller
    {
        private readonly IRolServices _rolServices;
        //Instancia la clase IArticleServices en todo el proyecto para usar todos lo metodos creados
        public RolController(IRolServices rolServices)
        {
            _rolServices = rolServices;
        }

        [HttpGet]
        public async Task<IActionResult> Index()//Crea un metodo para llamar a la vista Index(en views/article/index.chtml)
        {
            try
            {
                return View(await _rolServices.GetRols());
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
        public IActionResult Crear(Rol request)
        {
            try
            {
                var response = _rolServices.CreateRol(request);
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
            var response = await _rolServices.GetByIdRol(id);
            return View(response);
        }
        [HttpPost]
        public IActionResult Editar(Rol request)
        {
            try
            {
                var response = _rolServices.EditRol(request);
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
                bool response = _rolServices.DeleteRol(id);
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