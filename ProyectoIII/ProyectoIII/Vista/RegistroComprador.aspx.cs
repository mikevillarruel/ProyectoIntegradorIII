using ProyectoIII.Controlador;
using ProyectoIII.Modelo;
using System;
using System.Web.UI;

namespace ProyectoIII.Vista
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Comprador comprador = new Comprador(0, nombre.Value, apellido.Value, cedula.Value, usuario.Value, contrasenia.Value, ciudad.Value, 1, email.Value, direccion.Value, telefono.Value, new DateTime(2017, 2, 23));
            Servicio servicio = new Servicio();
            string script;
            if (servicio.insertComprador(comprador))
            {
                script = @"<script type='text/javascript'>                
                alert('Registro Correcto');
                </script>";

            }
            else
            {
                script = @"<script type='text/javascript'>                
                alert('Registro Incorrecto');
                </script>";
            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
        /*
protected void crearCuenta_Click(object sender, EventArgs e)
{
   Comprador c = new Comprador(1, nombre.ToString(), apellido.ToString(), cedula.ToString(), "usuario", contrasenia.ToString(), "Ibarra", 1, email.ToString(), "Quito", telefono.ToString(), new DateTime(2017, 2, 23));
   Servicio servicio = new Servicio();
   servicio.insertComprador(c);
}*/
    }
}