using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using proyecto.Controlador;

namespace proyecto.Vista
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        String usuarioP;
        String nombre;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                nombre = Session["us"].ToString();
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Vista/Login.aspx?men=1");

            }
        }

        protected void btnIniciar_Click1(object sender, EventArgs e)
        {
            string script = "";
            String contrasena1 = contra1.Value;
            String contrasena2 = contra2.Value;
            Servicio servicio = new Servicio();
            String contraseniaN = servicio.Encriptar(contra1.Value);

            if (contrasena1.Equals(contrasena2))
            {
                if (servicio.iniciarSesionC(nombre).Equals("Persona"))
                {
                    servicio.cambiarContrasenaPersona(nombre, contraseniaN);
                    Session.Remove("us");
                    Response.Redirect("~/Vista/Login.aspx");

                }
                else if (servicio.iniciarSesionC(nombre).Equals("Proveedor"))
                {
                    servicio.cambiarContrasenaProveedor(nombre, contraseniaN);
                    Session.Remove("us");
                    Response.Redirect("~/Vista/Login.aspx");
                }

                script = @"<script type='text/javascript'>                
                alert('El cambio se ha realizado con exito');
                </script>";

                //funcional.Text = ""+nombre;
            }
            else
            {
                script = @"<script type='text/javascript'>                
                alert('Los datos no coinciden');
                </script>";

            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

        }
    }
}