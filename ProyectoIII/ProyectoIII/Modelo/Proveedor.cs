namespace ProyectoIII.Modelo
{
    public class Proveedor
    {

        int id;
        string nombre;
        string direccion;
        string ciudad;
        string telefono;
        string email;
        string usuario;
        string contrasenia;

        public Proveedor(int id, string nombre, string direccion, string ciudad, string telefono, string email, string usuario, string contrasenia)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.ciudad = ciudad;
            this.telefono = telefono;
            this.email = email;
            this.usuario = usuario;
            this.contrasenia = contrasenia;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Contrasenia { get => contrasenia; set => contrasenia = value; }
    }
}