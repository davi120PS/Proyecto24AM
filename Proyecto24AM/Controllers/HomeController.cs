using Microsoft.AspNetCore.Mvc;
using Proyecto24AM.Models;
using Proyecto24AM.Services.IServices;
using System.Diagnostics;

namespace Proyecto24AM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleServices _articleServices;
        public HomeController(ILogger<HomeController> logger, IArticleServices articleServices)
        {
            _articleServices = articleServices;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Privacy()
        {
            var response = await _articleServices.GetArticles();
            return View(response);
        }

        public IActionResult Contacto()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}