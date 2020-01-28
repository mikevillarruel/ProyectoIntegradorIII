using e_commerce.siproe;
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
        siproe.ServicioWebSoapClient servicio = new siproe.ServicioWebSoapClient();
        public List<SelectListItem> obtenerCategorias()
        {
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

        public ActionResult Proveedores()
        {
            List<Proveedor> proveedores = new List<Proveedor>();
            proveedores = servicio.selectAllProveedores();
            return View(proveedores);
            
        }
        
        public ActionResult modificarProveedor(int id)
        {
            Proveedor proveedor = new Proveedor();
            proveedor = servicio.selectProveedor(id);
            return View(proveedor);            
        }
        [HttpPost]
        public ActionResult modificarProveedor(Proveedor proveedor)
        {
            servicio.updateProveedor(proveedor);
            return RedirectToAction("Proveedores");
        }
        public ActionResult agregarProveedor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult agregarProveedor(Proveedor proveedor)
        {
            servicio.insertProveedor(proveedor);
            return RedirectToAction("Proveedores");
        }


        public ActionResult Productos()
        {
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
                //System.Windows.Forms.MessageBox.Show("" + path);
                // file is uploaded
                file.SaveAs(path); 
            }
            producto.Imagen = file!=null? pic:producto.Imagen;
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
            servicio.addProducto(producto);
            return RedirectToAction("Productos");
        }
    }
}