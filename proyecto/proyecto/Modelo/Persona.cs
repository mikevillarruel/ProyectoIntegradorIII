using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto.Modelo
{
    public class Persona
    {
        int id;
        string nombre;
        string apellido;
        string cedula;
        string usuario;
        string contrasenia;
        string ciudad;
        int tipo;
        string email;
        string direccion;
        string telefono;

        public Persona()
        {
        }
        public Persona(int id, string nombre, string apellido, string cedula, string usuario, string contrasenia, string ciudad, int tipo, string email, string direccion, string telefono)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.cedula = cedula;
            this.usuario = usuario;
            this.contrasenia = contrasenia;
            this.ciudad = ciudad;
            this.tipo = tipo;
            this.email = email;
            this.direccion = direccion;
            this.telefono = telefono;
        }
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Contrasenia { get => contrasenia; set => contrasenia = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public int Tipo { get => tipo; set => tipo = value; }
        public string Email { get => email; set => email = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }

    }
}