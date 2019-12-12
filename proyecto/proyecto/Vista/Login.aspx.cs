using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using proyecto.Controlador;

namespace proyecto.Vista
{
    public partial class Login : System.Web.UI.Page
    {
        String usuarioP;
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnIniciar_Click1(object sender, EventArgs e)
        {
            String usuario = userL.Value;
            String contrasenia = contraseniaL.Value;
            Servicio servicio = new Servicio();
            string script="";

            //servicio.iniciarSesion(usuario, contrasenia);
            // 1=ADMIN 2=COMPRADOR
            if (servicio.iniciarSesion(usuario, contrasenia).Equals("Persona"))
            {
                if(servicio.abrirIndex(usuario, contrasenia)==1)
                {
                    Response.Redirect("~/Vista/indexA.aspx");
                    usuarioP = usuario;
                    /*
                    script = @"<script type='text/javascript'>                
                    alert('ES PERSONA ADMIN');
                    </script>";*/
                }
                else if (servicio.abrirIndex(usuario, contrasenia) == 2)
                {
                    Response.Redirect("~/Vista/index.aspx");
                    /*
                    script = @"<script type='text/javascript'>                
                    alert('ES PERSONA COMPRADOR');
                    </script>";*/
                }

            }
            else if (servicio.iniciarSesion(usuario, contrasenia).Equals("Proveedor"))
            {
                Response.Redirect("~/Vista/indexP.aspx");
                usuarioP = usuario;
                /*
                script = @"<script type='text/javascript'>                
                alert('ES PROVEEDOR');
                </script>";*/
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