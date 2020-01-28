using e_commerce.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_commerce.Models.Home
{
    public class HomeIndexViewModel
    {
        public List<siproe.Producto> productos=new List<siproe.Producto>();
        public HomeIndexViewModel crearModelo()
        {
            siproe.ServicioWebSoapClient servicio = new siproe.ServicioWebSoapClient();
            List<siproe.Producto> productos = new List<siproe.Producto>();
            return new HomeIndexViewModel
            {
                productos = servicio.selectAllProductos()
            };

        }
    }
}