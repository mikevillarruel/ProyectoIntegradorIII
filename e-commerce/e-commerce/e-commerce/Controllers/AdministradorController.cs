using e_commerce.siproe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

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

        public ActionResult ReporteGanancias()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ReporteGanancias(Proveedor proveedor)
        {
            Document doc = new Document(PageSize.LETTER);
            // Indicamos donde vamos a guardar el documento
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(@"D:\ganacias.pdf", FileMode.Create));

            // Le colocamos el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("Mi primer PDF");
            doc.AddCreator("Roberto Torres");

            // Abrimos el archivo
            doc.Open();

            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            //LOGO
            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance("https://uploads-ssl.webflow.com/575ef60509a5a7a9116d9f8c/58af733c8b893223458839e6_EGAFutura-adm-compras.png");
            imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_CENTER;
            imagen.ScaleAbsolute(100f, 100f);
            doc.Add(imagen);


            // Escribimos el encabezamiento en el documento
            Paragraph p = new Paragraph("SIPROE");
            p.Alignment = Element.ALIGN_CENTER;
            doc.Add(p);
            p = new Paragraph("REPORTE DE GANANCIA EN VENTAS");
            p.Alignment = Element.ALIGN_CENTER;
            doc.Add(p);
            doc.Add(new Phrase("RUC: 10010040131589"));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase("Direccion: Av. Simon Bolivar N548"));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase("Email: atencionalcliente@siproe.com"));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase("www.siproe.com"));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase(DateTime.Now + ""));
            doc.Add(Chunk.NEWLINE);

            // Creamos una tabla que contendrá el nombre, apellido y país
            // de nuestros visitante.

            List<Producto> productos = servicio.selectAllProductos();
            PdfPTable tblPrueba = new PdfPTable(4);
            tblPrueba.WidthPercentage = 100;

            // Configuramos el título de las columnas de la tabla
            PdfPCell clNombre = new PdfPCell(new Phrase("Nombre", _standardFont));
            clNombre.BorderWidth = 0;
            clNombre.BorderWidthBottom = 0.75f;

            PdfPCell clApellido = new PdfPCell(new Phrase("Precio", _standardFont));
            clApellido.BorderWidth = 0;
            clApellido.BorderWidthBottom = 0.75f;

            PdfPCell clPais = new PdfPCell(new Phrase("Cantidad", _standardFont));
            clPais.BorderWidth = 0;
            clPais.BorderWidthBottom = 0.75f;

            PdfPCell clGanancia = new PdfPCell(new Phrase("Ganancia", _standardFont));
            clGanancia.BorderWidth = 0;
            clGanancia.BorderWidthBottom = 0.75f;

            // Añadimos las celdas a la tabla
            tblPrueba.AddCell(clNombre);
            tblPrueba.AddCell(clApellido);
            tblPrueba.AddCell(clPais);
            tblPrueba.AddCell(clGanancia);

            decimal ganancia = 0;

            for (int i = 0; i < productos.Count; i++)
            {
                clNombre = new PdfPCell(new Phrase(productos[i].Nombre, _standardFont));
                clNombre.BorderWidth = 0;

                clApellido = new PdfPCell(new Phrase(productos[i].Precio + "", _standardFont));
                clApellido.BorderWidth = 0;

                clPais = new PdfPCell(new Phrase(productos[i].Cantidad + "", _standardFont));
                clPais.BorderWidth = 0;

                clGanancia = new PdfPCell(new Phrase(productos[i].Precio * productos[i].Cantidad * (decimal)0.1 + "", _standardFont));
                clGanancia.BorderWidth = 0;

                // Añadimos las celdas a la tabla
                tblPrueba.AddCell(clNombre);
                tblPrueba.AddCell(clApellido);
                tblPrueba.AddCell(clPais);
                tblPrueba.AddCell(clGanancia);

                ganancia = ganancia + productos[i].Precio * productos[i].Cantidad * (decimal)0.1;

            }

            doc.Add(tblPrueba);

            Paragraph f = new Paragraph("GANANCIA TOTAL: $" + ganancia);
            f.Alignment = Element.ALIGN_RIGHT;
            doc.Add(f);
            doc.Add(Chunk.NEWLINE);

            doc.Close();
            writer.Close();
            return RedirectToAction("ReporteGanancias");
        }

            public ActionResult Reportes()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Reportes(Proveedor proveedor)
        {
            Document doc = new Document(PageSize.LETTER);
            // Indicamos donde vamos a guardar el documento
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(@"D:\ventas.pdf", FileMode.Create));

            // Le colocamos el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("Mi primer PDF");
            doc.AddCreator("Roberto Torres");

            // Abrimos el archivo
            doc.Open();

            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            //LOGO
            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance("https://uploads-ssl.webflow.com/575ef60509a5a7a9116d9f8c/58af733c8b893223458839e6_EGAFutura-adm-compras.png");
            imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_CENTER;
            imagen.ScaleAbsolute(100f, 100f);
            doc.Add(imagen);


            // Escribimos el encabezamiento en el documento
            Paragraph p = new Paragraph("SIPROE");
            p.Alignment = Element.ALIGN_CENTER;
            doc.Add(p);
            p = new Paragraph("REPORTE DE VENTAS");
            p.Alignment = Element.ALIGN_CENTER;
            doc.Add(p);
            doc.Add(new Phrase("RUC: 10010040131589"));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase("Direccion: Av. Simon Bolivar N548"));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase("Email: atencionalcliente@siproe.com"));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase("www.siproe.com"));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase(DateTime.Now + ""));
            doc.Add(Chunk.NEWLINE);

            // Creamos una tabla que contendrá el nombre, apellido y país
            // de nuestros visitante.

            List<Producto> productos = servicio.selectAllProductos();
            PdfPTable tblPrueba = new PdfPTable(3);
            tblPrueba.WidthPercentage = 100;

            // Configuramos el título de las columnas de la tabla
            PdfPCell clNombre = new PdfPCell(new Phrase("Nombre", _standardFont));
            clNombre.BorderWidth = 0;
            clNombre.BorderWidthBottom = 0.75f;

            PdfPCell clApellido = new PdfPCell(new Phrase("Precio", _standardFont));
            clApellido.BorderWidth = 0;
            clApellido.BorderWidthBottom = 0.75f;

            PdfPCell clPais = new PdfPCell(new Phrase("Cantidad", _standardFont));
            clPais.BorderWidth = 0;
            clPais.BorderWidthBottom = 0.75f;

            // Añadimos las celdas a la tabla
            tblPrueba.AddCell(clNombre);
            tblPrueba.AddCell(clApellido);
            tblPrueba.AddCell(clPais);

            for (int i = 0; i < productos.Count; i++)
            {
                clNombre = new PdfPCell(new Phrase(productos[i].Nombre, _standardFont));
                clNombre.BorderWidth = 0;

                clApellido = new PdfPCell(new Phrase(productos[i].Precio + "", _standardFont));
                clApellido.BorderWidth = 0;

                clPais = new PdfPCell(new Phrase(productos[i].Cantidad + "", _standardFont));
                clPais.BorderWidth = 0;

                // Añadimos las celdas a la tabla
                tblPrueba.AddCell(clNombre);
                tblPrueba.AddCell(clApellido);
                tblPrueba.AddCell(clPais);
            }

            doc.Add(tblPrueba);

            doc.Close();
            writer.Close();
            return RedirectToAction("Reportes");
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

        public ActionResult Comprar()
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
        /*
        public ActionResult agregarCarrito(int productId)
        {
            var cart = new List<Carrito>();
        }*/
        public ActionResult subirArchivo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult subirArchivo(Producto producto, HttpPostedFileBase file)
        {
            //System.Windows.Forms.MessageBox.Show("Entro");
            String pic=null;
            String ext = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                ext= System.IO.Path.GetExtension(pic);
                System.Windows.Forms.MessageBox.Show(pic + ext);
                if ((ext == ".txt") || (ext == ".csv"))
                {
                    string path = System.IO.Path.Combine(Server.MapPath("~/ImgProducto/"), pic);
                    // file is uploaded
                    file.SaveAs(path);
                    servicio.extraerDatos(ext, path);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(pic);
                }

            }
            else
            {
                System.Windows.Forms.MessageBox.Show("null");
            }
            return RedirectToAction("Productos");

        }


        public ActionResult eliminarProducto(String productoNombre)
        {
            servicio.deleteUnProducto(productoNombre);
            return RedirectToAction("Productos");
        }
        
        public ActionResult eliminarProveedor(int id)
        {
            servicio.deleteUnProveedor(id);
            return RedirectToAction("Proveedores");
        }
    }
}