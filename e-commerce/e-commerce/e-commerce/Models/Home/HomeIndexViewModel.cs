using e_commerce.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_commerce.Models.Home
{
    
    public class HomeIndexViewModel
    {
        public List<Producto> listaProducto { get; set; }
        public static HomeIndexViewModel createModel()
        {
            Servicio servicio = new Servicio();
            return new HomeIndexViewModel()
            {
                
                listaProducto = servicio.selectMisProductos("1");
            }        
            
        }

    }
}