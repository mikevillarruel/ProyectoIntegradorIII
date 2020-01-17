using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net.Mail;
using proyecto.Controlador;
using proyecto.Modelo;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Configuration;
using System.IO;
using System.Data;

namespace proyecto.Vista
{
    public partial class report : System.Web.UI.Page
    {

        String nombre;

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               nombre = Session["usA"].ToString();
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Vista/Login.aspx?men=1");

            }

            llenarProductos();
        }




        protected void Button1_Click(object sender, EventArgs e)
        {
            /*
            var exportFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var exportFile = System.IO.Path.Combine(exportFolder, "compra.pdf");

            using (var writer = new PdfWriter(exportFile))
            {
                using (var pdf = new PdfDocument(writer))
                {
                    var doc = new Document(pdf);
                    doc.Add(new Paragraph("Hello World"));
                }
            }*/


            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Vithal_Wadje.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gvProductos.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            Paragraph paragraph = new Paragraph("SIPROE ruc:1720875879, direccion: la magdalena, telefono: 2653693, email: siproe@hotmail.com");
            Paragraph paragraph2 = new Paragraph("Reporte del producto mas vendido");
            Paragraph paragraph3 = new Paragraph("Usuario: " + nombre);
            Paragraph paragraph4 = new Paragraph(DateTime.Now.ToString());
            string imageURL = Server.MapPath(".") + "/imagest/item-1.png";
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);

            jpg.ScaleToFit(140f, 120f);
            jpg.SpacingBefore = 10f;
            jpg.SpacingBefore = 10f;
            jpg.Alignment = Element.ALIGN_LEFT;

            pdfDoc.Open();

            pdfDoc.Add(paragraph);
            pdfDoc.Add(paragraph2);
            pdfDoc.Add(paragraph3);
            pdfDoc.Add(paragraph4);
            pdfDoc.Add(jpg);

            htmlparser.Parse(sr);
            pdfDoc.Close();



            Response.Write(pdfDoc);
            Response.End();
            gvProductos.AllowPaging = true;
            gvProductos.DataBind();

            /*
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    //To Export all pages

                    gvProductos.AllowPaging = false;
                    gvProductos.DataBind();

                    //gvProductos.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    Paragraph paragraph = new Paragraph("SIPROE ruc:1720875879, direccion: la magdalena, telefono: 2653693, email: siproe@hotmail.com");
                    Paragraph paragraph2 = new Paragraph("Reporte del producto mas vendido");
                    Paragraph paragraph3 = new Paragraph("Usuario: "+nombre);
                    string imageURL = Server.MapPath(".") + "/imagest/item-1.png";
                    iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);

                    jpg.ScaleToFit(140f, 120f);
                    jpg.SpacingBefore = 10f;
                    jpg.SpacingBefore = 10f;
                    jpg.Alignment = Element.ALIGN_LEFT;
                    


                    htmlparser.Parse(sr);

                    pdfDoc.Add(paragraph);
                    pdfDoc.Add(paragraph2);
                    pdfDoc.Add(paragraph3);
                    pdfDoc.Add(jpg);





                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }*/

        }


        public void llenarProductos()
        {
            Servicio servicio = new Servicio();
            gvProductos.DataSource = servicio.selectMisReporte();
            gvProductos.DataBind();

        }


    }
}