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

        public List<SelectListItem> obtenerCategorias()
        {
            Servicio servicio = new Servicio();
            List<SelectListItem> lista = new List<SelectListItem>();
            List<Categoria> cat = new List<Categoria>();
            cat = servicio.getCategoria();
            foreach(var item in cat)
            {
                lista.Add(new SelectListItem { Value=item.Id.ToString(),Text=item.Nombre });
            }
            return lista;
        }
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
            ViewBag.ListCategoria = obtenerCategorias();
            producto = servicio.selectProducto(productoNombre);
            return View(producto);
        }
        [HttpPost]
        public ActionResult modificarProducto(Producto producto)
        {
            Servicio servicio = new Servicio();
            servicio.updateUnProducto(producto);
            return RedirectToAction("Productos");
        }
        public ActionResult agregarProducto(string productoNombre)
        {
            ViewBag.ListCategoria = obtenerCategorias();
            return View();
        }
        [HttpPost]
        public ActionResult agregarProducto(Producto producto)
        {
            Servicio servicio = new Servicio();
            servicio.addProducto(producto);
            return RedirectToAction("Productos");
        }
    }
}