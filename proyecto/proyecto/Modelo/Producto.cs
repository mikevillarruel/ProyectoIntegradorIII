using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto.Modelo
{
    public class Producto
    {
        String nombre;
        String descripcion;
        Decimal precio;
        String imagen;
        String categoria;
        int cantidad;
        Decimal total;


        public Producto()
        {

        }

        public Producto(String nombre, String descripcion, Decimal precio, String imagen, String categoria, int cantidad, Decimal total)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
            this.imagen = imagen;
            this.categoria = categoria;
            this.cantidad = cantidad;
            this.total = total;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public Decimal Precio { get => precio; set => precio = value; }
        public string Imagen { get => imagen; set => imagen = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public Decimal Total { get => total; set => total = value; }

    }
}