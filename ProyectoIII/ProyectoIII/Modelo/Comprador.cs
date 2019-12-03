using System;

namespace ProyectoIII.Modelo
{
    public class Comprador : Persona
    {
        DateTime fechaDeNacimiento;

        public Comprador()
        {
            /*Hola Mayrilla*/
        }

        public Comprador(DateTime fechaDeNacimiento)
        {
            this.fechaDeNacimiento = fechaDeNacimiento;
        }

        public Comprador(int id, string nombre, string apellido, string cedula, string usuario, string contrasenia, string ciudad, int tipo, string email, string direccion, string telefono, DateTime fechaDeNacimiento) : base(id, nombre, apellido, cedula, usuario, contrasenia, ciudad, tipo, email, direccion, telefono)
        {
            this.fechaDeNacimiento = fechaDeNacimiento;
        }

        public DateTime FechaDeNacimiento { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }
    }
}