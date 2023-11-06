using Microsoft.AspNetCore.Mvc;

namespace Proyecto24AM.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
