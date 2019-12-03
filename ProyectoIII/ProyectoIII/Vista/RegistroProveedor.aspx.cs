using ProyectoIII.Controlador;
using ProyectoIII.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoIII.Vista
{
    public partial class RegistroProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = new Proveedor(0,nombre.Value, direccion.Value, ciudad.Value, telefono.Value, email.Value, usuario.Value, contrasenia.Value);
            Servicio servicio = new Servicio();
            string script;
            if (servicio.insertProveedor(proveedor))
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
    }
}