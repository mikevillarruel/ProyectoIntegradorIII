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
    public partial class add_products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click1(object sender, EventArgs e)
        {
            Producto producto = new Producto(nombreP.Value, descripcionP.Value, Convert.ToDecimal(precioP.Value), imagenP.Value, categorias.SelectedValue.ToString());
            Servicio servicio = new Servicio();
            int tamanio = imagen.PostedFile.ContentLength;
            byte[] img = new byte[tamanio];
            imagen.PostedFile.InputStream.Read(img, 0, tamanio);

            string script;
            if (servicio.insertProducto(producto,img))
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