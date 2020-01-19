using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace e_commerce.Models
{
    public class Categoria
    {

        String nombre;
        Boolean activo;
        Boolean inactivo;


        public Categoria()
        {

        }

        public Categoria(String nombre,Boolean activo, Boolean inactivo)
        {
            this.nombre = nombre;
            this.activo = activo;
            this.inactivo = inactivo;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public Boolean Activo { get => activo; set => activo = value; }
        public Boolean Inactivo { get => inactivo; set => inactivo = value; }

    }

}