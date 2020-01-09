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
    public partial class Modificar_Productos : System.Web.UI.Page
    {
        String nombre;
        String nombrePro;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                nombre = Session["usP"].ToString();
                nombrePro = Request.QueryString["np"];
                
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Vista/Login.aspx?men=1");

            }
            llenarCampos(nombre,nombrePro);
        }

        public void llenarCampos(String usuario, String nombrePro)
        {
            Servicio servicio = new Servicio();
            Producto producto = new Producto();
            producto = servicio.selectProducto(usuario, nombrePro);

            nombreP.Value = producto.Nombre;
            descripcionP.Value = producto.Descripcion;
            precioP.Value = producto.Precio.ToString();
        }

        protected void btnIngresar_Click1(object sender, EventArgs e)
        {

            m1.Text = nombreP.Value;
            /*
            Servicio servicio = new Servicio();
            Producto producto = new Producto(nombreP.Value, descripcionP.Value, Convert.ToDecimal(precioP.Value), null, null);
            string script;


            
            /*
            servicio.updateUnProducto(nombre, nombrePro, producto);
            script = @"<script type='text/javascript'>                
                alert('Actualizacion Correcta);
                </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);*/
        }
    }
}