using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using proyecto.Controlador;
using proyecto.Modelo;

namespace proyecto.Vista
{
    public partial class RegistroAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Servicio servicio = new Servicio();
            String contraE = servicio.Encriptar(contrasenia.Value);
            Persona persona = new Persona(0, nombre.Value, apellido.Value, cedula.Value, usuario.Value, contraE, ciudad.Value, 1, email.Value, direccion.Value, telefono.Value);
            
            string script;
            if (servicio.insertAdministrador(persona))
            {
                script = @"<script type='text/javascript'>                
                alert('Registro Correcto');
                </script>";
                Response.Redirect("~/Vista/Login.aspx");

            }
            else
            {
                script = @"<script type='text/javascript'>                
                alert('Registro Incorrecto');
                </script>";
            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
    }
}