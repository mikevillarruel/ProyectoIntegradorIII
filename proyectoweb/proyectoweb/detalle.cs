using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoweb
{
    public class detalle
    {
        private int item;
        private string producto;
        private decimal cantidad;
        private decimal precio;

        public detalle()
        {

        }

        public detalle(int item, string producto, decimal cantidad, decimal precio)
        {
            this.item = item;
            this.producto = producto;
            this.cantidad = cantidad;
            this.precio = precio;
        }

        public int Item
        {
            get { return item; }
            set { item = value; }
        }

        public string Producto
        {
            get { return producto; }
            set { producto = value; }
        }

        public decimal Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public decimal Precio
        {
            get { return precio; }
            set { precio = value; }
        }
    }

}