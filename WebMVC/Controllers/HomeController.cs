using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<ActionResult> Index()
        {
            return View();

            
            

        }

        public IActionResult Login(string UserName, string Password)
        {
            try
            {
                if (LoginUser(UserName, Password).Result)
                {

                    //Una vez que validamos el usuario obtenemos los roles 
                    string Rol = GetRolUsuario(UserName).Result;

                    if (Rol == "Principal")
                    {
                        
                        return RedirectToAction("Index", "Productos");
                    }

                    switch (Rol)
                    {

                        case "Principal":
                            //lo redirijo a la página de productos del Rol Principal
                            return RedirectToAction("Index", "Productos");

                        case "Delegado":
                            //lo redirijo a la página de productos del Rol Delegado
                            return RedirectToAction("Delegado", "Productos");
                        default:
                            return View("UsuarioInvalido");
                            
                    }


                }
                else
                {
                    return View("UsuarioInvalido");
                }
            }
            catch (Exception)
            {
                return View("UsuarioInvalido");
              
            }

            

            
        }

        public async Task<string> GetRolUsuario(string Usuario)
        {
            string Result = "";


            var httpClient = new HttpClient();

            Result = await httpClient.GetStringAsync("https://localhost:7023/api/Usuario/ObtenerRolesUsuario?usuario=" + Usuario);


            return Result;
        }

        public async Task<bool> LoginUser(string Usuario, string Password)
        {
            bool result = false;

            var httpClient = new HttpClient();

            //var json = await httpClient.GetStringAsync("https://localhost:7023/api/Producto/ProductosXRol?rol=Principal");
            var json = await httpClient.GetStringAsync("https://localhost:7023/api/Usuario/ValidarCredenciales?usuario="+ Usuario +"&password="+Password+"");

            if (json =="true")
            {
                result = true;
            }

            return result;

        }

        public IActionResult Privacy()
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