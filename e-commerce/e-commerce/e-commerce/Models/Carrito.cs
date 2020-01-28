using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_commerce.Models
{
    public class Carrito
    {
        public Producto producto { get; set; }
        public int Cantidad { get; set; }
    }
}