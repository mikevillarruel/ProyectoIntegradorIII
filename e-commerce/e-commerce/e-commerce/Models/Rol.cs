using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_commerce.Models
{
    public class Rol
    {
        int id;
        String nombre;

        public Rol()
        {

        }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Id { get => id; set => id = value; }
    }
}