using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using proyecto.Controlador;
using proyecto.Modelo;
using System.IO;
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

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }


        private void ExportGridToExcel()
        {
            /*
            string attachment = "attachment; filename=proyecto.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gvProductos.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();*/

            System.IO.StringWriter sw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);

            // Render grid view control.
            gvProductos.RenderControl(htw);

            // Write the rendered content to a file.
            string renderedGridView = sw.ToString();

            System.IO.File.WriteAllText("C:/Users/danie/Desktop/archivos/ExportedFile.xls", renderedGridView);
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
            Session["nomProducto"] = (sender as LinkButton).CommandArgument;
            Response.Redirect("~/Vista/Modificar-Productos.aspx");


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

        protected void Exportar_Click(object sender, EventArgs e)
        {
            ExportGridToExcel();
        }
    }
}