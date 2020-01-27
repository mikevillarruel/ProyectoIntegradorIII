using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using e_commerce.Models;

namespace e_commerce.Controllers
{
    public class Servicio
    {
        public Proveedor iniciarSesion(String usuario, String contrasenia)
        {
            Proveedor us = new Proveedor();
            ; Operaciones op = new Operaciones();
            us = op.usuarioPersona(usuario, contrasenia);
            return us;

        }
        public List<Proveedor> selectAllProveedores()
        {
            Operaciones op = new Operaciones();
            List<Proveedor> proveedores = new List<Proveedor>();
            proveedores = op.selectAllProveedores();
            return proveedores;
        }

        public Proveedor selectProveedor(int id)
        {
            Operaciones op = new Operaciones();
            Proveedor proveedor = new Proveedor();
            proveedor = op.selectProveedor(id);
            return proveedor;
        }

        public void updateProveedor(Proveedor proveedor)
        {
            Operaciones op = new Operaciones();
            op.updateProveedor(proveedor);
        }
        public void insertProveedor(Proveedor proveedor)
        {
            Operaciones op = new Operaciones();
            op.insertProveedor(proveedor);
        }
        public List<Producto> selectAllProductos()
        {
            Operaciones op = new Operaciones();
            List<Producto> listaProductos = new List<Producto>();
            listaProductos = op.selectAllProductos();

            return listaProductos;
        }

        public Producto selectProducto(String nombrePro)
        {
            Operaciones op = new Operaciones();
            Producto producto = new Producto();

            producto = op.selectUnProducto(nombrePro);

            return producto;
        }
        public void updateUnProducto(Producto producto)
        {
            Operaciones op = new Operaciones();
            op.updateUnProducto(producto);
        }

        public void addProducto(Producto producto)
        {

            Operaciones op = new Operaciones();
            op.insertProducto(producto);
        }

        public List<Categoria> getCategoria()
        {
            Operaciones op = new Operaciones();
            List<Categoria> categorias = new List<Categoria>();
            categorias = op.getCategoria();
            return categorias;
        }
    }
}