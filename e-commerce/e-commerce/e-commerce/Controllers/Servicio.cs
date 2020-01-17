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
    }
}