using e_commerce.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_commerce.Models.Home
{
    public class HomeIndexViewModel
    {
        public List<Producto> productos=new List<Producto>();
        public HomeIndexViewModel crearModelo()
        {
            Servicio servicio = new Servicio();
            List<Producto> productos = new List<Producto>();
            return new HomeIndexViewModel
            {
                productos = servicio.selectAllProductos()
            };

        }
    }
}