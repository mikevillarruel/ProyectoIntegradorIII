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
            productos = servicio.selectAllProductos();
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
        public ActionResult modificarProducto(Producto producto, HttpPostedFileBase file)
        {
            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);

                string path = System.IO.Path.Combine(Server.MapPath("~/ImgProducto/"), pic);
                System.Windows.Forms.MessageBox.Show("" + path);
                // file is uploaded
                file.SaveAs(path);
            }
            else
            {

                System.Windows.Forms.MessageBox.Show("" + pic);
            }
            producto.Imagen = file!=null? pic:producto.Imagen;
            Servicio servicio = new Servicio();
            servicio.updateUnProducto(producto);
            return RedirectToAction("Productos");
        }
        public ActionResult agregarProducto()
        {
            ViewBag.ListCategoria = obtenerCategorias();
            return View();
        }
        [HttpPost]
        public ActionResult agregarProducto(Producto producto,HttpPostedFileBase file)
        {
            string pic=null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/ImgProducto/"), pic);
                // file is uploaded
                file.SaveAs(path);
            }
            producto.Imagen = pic;
            Servicio servicio = new Servicio();
            servicio.addProducto(producto);
            return RedirectToAction("Productos");
        }
    }
}