using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Productos.BLL;
using Productos.Entities;

namespace ApiUsuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet("ProductosXRol")]
        public List<Producto> getProductosxRol(string rol)
        {
            var BLL = new ProductosBO();

            return BLL.GetProductosXRol(rol);
        }
    }
}
