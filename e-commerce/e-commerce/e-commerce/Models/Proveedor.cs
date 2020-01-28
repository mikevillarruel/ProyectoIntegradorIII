using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_commerce.Models
{
    public class Proveedor
    {
        int id;
        int tarjeta;
        String nombre;
        String apellido;
        String email;
        String contrasenia;
        String tipo;
        int rol;

        public Proveedor()
        {

        }

        public Proveedor(String nombre, String email,String contrasenia, String tipo)
        {
            this.nombre = nombre;
            this.email = email;
            this.contrasenia = contrasenia;
            this.tipo = tipo;
        }

        public Proveedor(String nombre, String apellido, String email, String contrasenia, String tipo)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.email = email;
            this.contrasenia = contrasenia;
            this.tipo = tipo;
        }

        public int Id { get => id; set => id = value; }
        public int Tarjeta { get => tarjeta; set => tarjeta = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Email { get => email; set => email = value; }
        public string Contrasenia { get => contrasenia; set => contrasenia = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public int Rol { get => rol; set => rol = value; }


    }
}