using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using proyecto.Controlador;

namespace proyecto.Vista
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        String usuarioP;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIniciar_Click1(object sender, EventArgs e)
        {
            String usuario = userL.Value;
            //String contrasenia = contraseniaL.Value;
            Servicio servicio = new Servicio();
            String contrasenia = servicio.Encriptar(contraseniaL.Value);
            string script = "";

            //servicio.iniciarSesion(usuario, contrasenia);
            // 1=ADMIN 2=COMPRADOR
            if (servicio.iniciarSesion(usuario, contrasenia).Equals("Persona"))
            {
                
                
                if (servicio.abrirIndex(usuario, contrasenia) == 1)
                {
                    Session["us"] = usuario;
                }
                else if (servicio.abrirIndex(usuario, contrasenia) == 2)
                {
                    Session["us"] = usuario;
                }
                Response.Redirect("~/Vista/CambiarContrasena2.aspx");
                
            }
            else if (servicio.iniciarSesion(usuario, contrasenia).Equals("Proveedor"))
            {
                
                Session["us"] = usuario;
                Response.Redirect("~/Vista/CambiarContrasena2.aspx");
            }
            else
            {
                script = @"<script type='text/javascript'>                
                alert('REVISE SUS DATOS');
                </script>";
            }

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

        }
    }
}