using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto.Modelo
{
    public class estadistica
    {
        string anio;
        string producto;
        string cantidad;
        string proveedor;

        public estadistica()
        {
        }
        public estadistica(string anio, string producto, string cantidad, string proveedor)
        {
            this.anio = anio;
            this.producto= producto;
            this.cantidad = cantidad;
            this.proveedor = proveedor;

        }
        public string Anio { get => anio; set => anio = value; }
        public string Producto { get => producto; set => producto = value; }
        public string Cantidad { get => cantidad; set => cantidad = value; }
        public string Proveedor { get => proveedor; set => proveedor = value; }

    }
}