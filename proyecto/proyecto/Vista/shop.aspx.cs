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
    public partial class shop : System.Web.UI.Page
    {
        String nombre;
        List<Producto> listaProductos = new List<Producto>();

        String nombrePro;
        Servicio servicioCart = new Servicio();
        List<Producto> listaCart = new List<Producto>();
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
            llenarProductos();
        }

        public void llenarProductos()
        {
            Servicio servicio = new Servicio();
            gvProductos.DataSource = servicio.selectTodosProductos();
            gvProductos.DataBind();

        }




        public void lnkVer_OnClick(object sender, EventArgs e)
        {
            Session["nomProducto"] = (sender as LinkButton).CommandArgument;
            Response.Redirect("~/Vista/VerProducto.aspx");
        }

        public void lnkComprar_OnClick(object sender, EventArgs e)
        {
            /*
            Session["nomProducto"] = (sender as LinkButton).CommandArgument;
            Response.Redirect("~/Vista/cart.aspx");*/

            listaCart.Add(servicioCart.selectCartProducto(nombrePro));
            Session["nomProducto"] = listaCart;
            Response.Redirect("~/Vista/cart.aspx");
        }
    }
}