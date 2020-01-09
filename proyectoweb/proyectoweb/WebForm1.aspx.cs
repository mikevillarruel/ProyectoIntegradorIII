using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Net.Mail;

namespace proyectoweb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        OracleConnection conexion = new OracleConnection("DATA SOURCE = ORCL ; PASSWORD = 123 ; USER ID = proyecto");
        protected void Button1_Click(object sender, EventArgs e)
        {
            conexion.Open();
            OracleCommand cmd = conexion.CreateCommand();
            cmd.CommandText = "SELECT p.nombre_producto, d.cantidad_factura, d.precio_factura FROM producto p, detalle_factura d WHERE p.id_producto LIKE d.id_producto ";
            cmd.CommandType = System.Data.CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();

            while(dr.Read())
            {
                /* alerta.Text = dr.GetString(0);*/
                //decimal numero = dr.GetDecimal(2);
                alerta.Text = "Se ha enviado un correo de confirmacion";
                    
            }

            var exportFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var exportFile = System.IO.Path.Combine(exportFolder,"compra.pdf");

            using (var writer = new PdfWriter(exportFile))
            {
                using (var pdf= new PdfDocument(writer))
                {
                    var doc = new Document(pdf);
                    doc.Add(new Paragraph("Hello World"));
                }
            }

            /*Enviar correo*/

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("karly.btr.97@gmail.com");
                mail.To.Add("ingalmeida@yahoo.com");
                mail.Subject = "Comprobante de venta";
                mail.Body = "Adjunto el achivo de la venta realizada";
                
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment("C:/Users/danie/Desktop/compra.pdf");
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("karly.btr.97@gmail.com", "alessandroshmsasilove97");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                alerta.Text =ex.ToString();
            }
        }
    

        public List<detalle> listardetalle()
        {
            List<detalle> listadecompras = new List<detalle>();

            conexion.Open();
            OracleCommand cmd = conexion.CreateCommand();
            cmd.CommandText = "SELECT p.nombre_producto, d.cantidad_factura, d.precio_factura FROM producto p, detalle_factura d WHERE p.id_producto LIKE d.id_producto ";
            cmd.CommandType = System.Data.CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                i = i + 1;
                detalle unDetalle = new detalle();
                unDetalle.Item = i;
                unDetalle.Producto = dr.GetString(0);
                unDetalle.Cantidad = dr.GetDecimal(1);
                unDetalle.Precio = dr.GetDecimal(2);
                listadecompras.Add(unDetalle);

            }
            conexion.Close();
            return listadecompras;
        }

        protected void btnVerificar_Click(object sender, EventArgs e)
        {
            List<detalle> listadedetalle = listardetalle();

            if (listadedetalle.Count == 0)
            {
                alerta.Text = "No se ha realizado ninguna compra";
            }
            else
            {
                tablaDetalle.DataSource = listadedetalle;
                tablaDetalle.DataBind();
                String detalle = listadedetalle.ToString();
                alerta.Text = ""+detalle;
            }

        }
    }
}