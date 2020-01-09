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
    public partial class my_products : System.Web.UI.Page
    {
        String nombre;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                nombre = Session["usP"].ToString();
                //m1.Text = nombre;
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
            gvProductos.DataSource = servicio.selectMisProductos(nombre);
            gvProductos.DataBind();
 
        }

        public void lnkModificar_OnClick(object sender, EventArgs e)
        {
            //m1.Text = (sender as LinkButton).CommandArgument ;
            Response.Redirect("~/Vista/Modificar-Productos.aspx?np="+ (sender as LinkButton).CommandArgument);


        }

        public void lnkEliminar_OnClick(object sender, EventArgs e)
        {
            //m1.Text = (sender as LinkButton).CommandArgument ;
            Servicio servicio = new Servicio();
            servicio.deleteUnProducto(nombre, (sender as LinkButton).CommandArgument);
            llenarProductos();

        }

        protected void buscar_Click(object sender, EventArgs e)
        {
            m1.Text = busqueda.Value;
            Servicio servicio = new Servicio();
            List<Producto> listaProductos = new List<Producto>();

            listaProductos.Add(servicio.selectProducto(nombre, busqueda.Value));

            gvProductos.DataSource = listaProductos;
            gvProductos.DataBind();

        }
    }
}