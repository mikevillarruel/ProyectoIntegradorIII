using e_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace e_commerce.ServicioWeb
{
    /// <summary>
    /// Descripción breve de ServicioWeb
    /// </summary>
    [WebService(Namespace = "http://siproe.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ServicioWeb : System.Web.Services.WebService
    {

        Operaciones op = new Operaciones();

        [WebMethod]
        public Proveedor iniciarSesion(String usuario, String contrasenia)
        {
            Proveedor us = new Proveedor();
            us = op.usuarioPersona(usuario, contrasenia);
            return us;

        }

        [WebMethod]
        public List<Proveedor> selectAllProveedores()
        {
            List<Proveedor> proveedores = new List<Proveedor>();
            proveedores = op.selectAllProveedores();
            return proveedores;
        }

        [WebMethod]
        public Proveedor selectProveedor(int id)
        {
            Proveedor proveedor = new Proveedor();
            proveedor = op.selectProveedor(id);
            return proveedor;
        }

        [WebMethod]
        public void updateProveedor(Proveedor proveedor)
        {
            op.updateProveedor(proveedor);
        }

        [WebMethod]
        public void insertProveedor(Proveedor proveedor)
        {
            System.Windows.Forms.MessageBox.Show("" + proveedor.Nombre);
            op.insertProveedor(proveedor);
        }

        [WebMethod]
        public List<Producto> selectAllProductos()
        {
            List<Producto> listaProductos = new List<Producto>();
            listaProductos = op.selectAllProductos();

            return listaProductos;
        }

        [WebMethod]
        public Producto selectProducto(String nombrePro)
        {
            Producto producto = new Producto();

            producto = op.selectUnProducto(nombrePro);

            return producto;
        }

        [WebMethod]
        public void updateUnProducto(Producto producto)
        {
            op.updateUnProducto(producto);
        }

        [WebMethod]
        public void addProducto(Producto producto)
        {
            op.insertProducto(producto);
        }

        [WebMethod]
        public List<Categoria> getCategoria()
        {
            List<Categoria> categorias = new List<Categoria>();
            categorias = op.getCategoria();
            return categorias;
        }

        [WebMethod]
        public void extraerDatos(String extension, String savePath)
        {
            op.extraerDatos(extension,savePath);
        }

        [WebMethod]
        public void deleteUnProducto(String productoID)
        {
            op.deleteUnProducto(productoID);
        }
        [WebMethod]
        public void deleteUnProveedor(int usuarioID)
        {
            op.deleteUnProveedor(usuarioID);
        }
    }
}
