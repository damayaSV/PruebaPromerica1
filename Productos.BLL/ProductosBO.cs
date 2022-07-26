using Productos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos.BLL
{
    public class ProductosBO
    {

        public List<ProductosXRol> lstProductosXRol = new List<ProductosXRol>();
        public List<Producto> lstProductos = new List<Producto>();
        public ProductosBO()
        {
            lstProductosXRol.Add(new ProductosXRol{ Producto ="Prod_A",Rol="Principal"});
            lstProductosXRol.Add(new ProductosXRol { Producto = "Prod_B", Rol = "Principal" });
            lstProductosXRol.Add(new ProductosXRol { Producto = "Prod_C", Rol = "Principal" });
            lstProductosXRol.Add(new ProductosXRol { Producto = "Prod_A", Rol = "Delegado" });
            lstProductosXRol.Add(new ProductosXRol { Producto = "Prod_C", Rol = "Delegado" });

        }

        public List<Producto> GetProductosXRol(string Rol)
        {
            List<Producto> Respuesta = new List<Producto>();

            var productos = lstProductosXRol.Where(x=>x.Rol == Rol).ToList();

            foreach (var item in productos)
            {
                Respuesta.Add( new Producto { NombreProducto = item.Producto });
            }

            return Respuesta;
        }

    }
}
