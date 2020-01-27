using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using e_commerce.Models;

namespace e_commerce.Controllers
{
    public class Servicio
    {
        public List<Usuario> selectAllProveedores()
        {
            Operaciones op = new Operaciones();
            List<Usuario> proveedores = new List<Usuario>();
            proveedores = op.selectAllProveedores();
            return proveedores;
        }

        public Usuario selectProveedor(int id)
        {
            Operaciones op = new Operaciones();
            Usuario proveedor = new Usuario();
            proveedor = op.selectProveedor(id);
            return proveedor;
        }

        public void updateProveedor(Usuario proveedor)
        {
            Operaciones op = new Operaciones();
            op.updateProveedor(proveedor);
        }
        public void insertProveedor(Usuario proveedor)
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

        public Usuario iniciarSesion(String usuario, String contrasenia)
        {
             Usuario us = new Usuario();
;            Operaciones op = new Operaciones();
            us = op.usuarioPersona(usuario, contrasenia);
            return us;
           
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