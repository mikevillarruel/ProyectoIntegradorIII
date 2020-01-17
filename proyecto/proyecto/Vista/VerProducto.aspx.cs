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
    public partial class VerProducto : System.Web.UI.Page
    {
        String nombre;
        String nombrePro;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                nombre = Session["us"].ToString();
                nombrePro = Session["nomProducto"].ToString();
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Vista/Login.aspx?men=1");

            }
            llenarProductos();
        }

        public void llenarProductos()
        {
            Servicio servicio = new Servicio();
            gvProductos.DataSource = servicio.selectVerProducto(nombrePro);
            gvProductos.DataBind();

        }
    }
}