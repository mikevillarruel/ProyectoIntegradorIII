using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using e_commerce.Models;

namespace e_commerce.Controllers
{
    public class Servicio
    {
        public String selectPrueba()
        {
            Operaciones operaciones = new Operaciones();
            String prueba;
            prueba = operaciones.selectPrueba();
            return prueba;
        }

        public List<Producto> selectMisProductos(String usuario)
        {
            Operaciones op = new Operaciones();
            List<Producto> listaProductos = new List<Producto>();
            listaProductos = op.selectMisProductos(usuario);

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
    }
}