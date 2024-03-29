﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using proyecto.Modelo;
using proyecto.Controlador;

namespace proyecto.Vista.webfonts
{
    public partial class RegistroComprador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Servicio servicio = new Servicio();
            String contraE = servicio.Encriptar(contrasenia.Value);
            DateTime aDate = DateTime.ParseExact(fechaDeNacimiento.Value, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            Comprador comprador = new Comprador(0, nombre.Value, apellido.Value, cedula.Value, usuario.Value, contraE, ciudad.Value, 2, email.Value, direccion.Value, telefono.Value, aDate);
            string script;
            if (servicio.insertComprador(comprador))
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