using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto24AM.Context;
using Proyecto24AM.Models.Entities;
using Proyecto24AM.Services.IServices;
using Proyecto24AM.Services.Services;

namespace Proyecto24AM.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly ApplicationDbContext _context;
        //Instancia la clase IArticleServices en todo el proyecto para usar todos lo metodos creados
        public UserController(IUserServices userServices, ApplicationDbContext context)
        {
            _userServices = userServices;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()//Crea un metodo para llamar a la vista Index(en views/article/index.chtml)
        {
            try
            {
                return View(await _userServices.GetUsers());
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }
        [HttpGet]
        public IActionResult Crear()
        {
            ViewBag.Rols = _context.Rols.Select(p => new SelectListItem()
            {
                Text = p.Name,
                Value = p.PKRol.ToString()
            });

            return View();
        }
        [HttpPost]
        public IActionResult Crear(User request)
        {
            try
            {
                var response = _userServices.CreateUser(request);
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
            var response = await _userServices.GetByIdUser(id);

            ViewBag.Rols = _context.Rols.Select(p => new SelectListItem()
            {
                Text = p.Name,
                Value = p.PKRol.ToString()
            });

            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(User request)
        {
            try
            {
                var response = await _userServices.EditUser(request);
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
                bool response = _userServices.DeleteUser(id);
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