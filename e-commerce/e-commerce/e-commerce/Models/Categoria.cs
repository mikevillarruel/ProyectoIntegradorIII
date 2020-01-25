using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace e_commerce.Models
{
    public class Categoria
    {
        int id;
        String nombre;


        public Categoria()
        {

        }

        public Categoria(int id,String nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public int Id { get => id; set => id = value; }

    }

}