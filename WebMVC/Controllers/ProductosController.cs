using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class ProductosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Delegado()
        {
            return View();
        }
    }
}
