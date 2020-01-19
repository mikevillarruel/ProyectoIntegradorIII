using e_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace e_commerce.Controllers
{
    public class AdministradorController : Controller
    {
        // GET: Administrador
        public ActionResult DashBoard()
        {
            return View();
        }

        public ActionResult Productos()
        {
            Servicio servicio = new Servicio();
            List<Producto> productos = new List<Producto>();
            productos = servicio.selectMisProductos("1");
            return View(productos);
        }

        public ActionResult añadirProducto()
        {
            return View();
        }

        public ActionResult modificarProducto(string productoNombre)
        {
            Servicio servicio = new Servicio();
            Producto producto = new Producto();
            producto = servicio.selectProducto(productoNombre);
            return View(producto);
        }
        [HttpPost]
        public ActionResult modificarProducto(Producto producto)
        {
            System.Windows.Forms.MessageBox.Show(producto.Nombre + "|" + producto.Precio);
            Servicio servicio = new Servicio();
            servicio.updateUnProducto(producto);
            return RedirectToAction("Productos");
        }
    }
}