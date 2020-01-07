using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using proyecto.Controlador;
using System.IO;

namespace proyecto.Vista
{
    public partial class Upload_Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String nombre = Session["usP"].ToString();
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Vista/Login.aspx?men=1");

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String savePath = @"C:/Users/danie/Documents/Septimo Semestre/Proyecto Integrador III/Segundo Parcial/carpeta2";
            Servicio servicio = new Servicio();
            if (FileUpload1.HasFile)
            {
                //obtener nombre del archivo
                String fileName = Server.HtmlEncode(FileUpload1.FileName);
                //Obtener extensión del archivo
                string extension = System.IO.Path.GetExtension(fileName);
                //Acepta solo .txt .csv
                if ((extension == ".txt") || (extension == ".csv"))
                {
                    savePath += fileName;
                    //guardando archivo en la nueva dirección
                    FileUpload1.SaveAs(savePath);
                    //extrae datos según el tipo de archivo
                    servicio.extraerDatos(extension, savePath);
                    //enviar datos a la base
                    
                    //MessageBox.Show("Productos Subidos exitosamente");
                }
                else
                {
                    //MessageBox.Show("Solo se acepta .txt o .csv");
                }
            }
            else
            {
                //MessageBox.Show("No a seleccionado ningún archivo");
            }
        }
    }
}