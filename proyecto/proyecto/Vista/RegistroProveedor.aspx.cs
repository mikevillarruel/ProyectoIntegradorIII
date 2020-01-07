using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using proyecto.Modelo;
using proyecto.Controlador;

namespace proyecto.Vista
{
    public partial class RegistroProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Servicio servicio = new Servicio();
            String contraE = servicio.Encriptar(contrasenia.Value);
            Proveedor proveedor = new Proveedor(0, nombre.Value, direccion.Value, ciudad.Value, telefono.Value, email.Value, usuario.Value, contraE);
            
            string script;
            if (servicio.insertProveedor(proveedor))
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