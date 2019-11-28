using ProyectoIII.Controlador;
using ProyectoIII.Modelo;
using System;

namespace ProyectoIII
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAumentar_Click(object sender, EventArgs e)
        {
            /*StringBuilder strB = new StringBuilder();
            ServiceReference1.WebService1SoapClient miwebserv = new ServiceReference1.WebService1SoapClient();
            result.InnerHtml = "";
            for (int i = 0; i < 5; i++)
            {
                result.InnerHtml = result.InnerHtml + "<img src='https://equiposlibres.pe/wp-content/uploads/2019/07/Mi9T-1.png'/>" +
                    "<section>" +
                    "<h1> Xiaomi Mi 9T 64GB + 4GB RAM 6.39'' 48MP Triple Cámara LTE Desbloqueado de fábrica GSM Smartphone</h1>" +
                    "Xiomi (Versión Internacional)" +
                    "<br/>" +
                    "<br/>" +
                    "$" + miwebserv.ponNumeros(i, 1).ToString() +
                    "</section>" +
                    "<hr/>";
            }
            //Label1.Text = miwebserv.ponNumeros(Double.Parse(Label1.Text), 2).ToString();
            */

            /*
            ServiceReference1.WebService1SoapClient miwebserv = new ServiceReference1.WebService1SoapClient();
            SoapFormatter formateador = new SoapFormatter();
            
            if (Conexion.getInstancia().getConexion() != null) {
                result.InnerHtml = result.InnerHtml + "<img src='https://equiposlibres.pe/wp-content/uploads/2019/07/Mi9T-1.png'/>" +
                        "<section>" +
                        "<h1> Xiaomi Mi 9T 64GB + 4GB RAM 6.39'' 48MP Triple Cámara LTE Desbloqueado de fábrica GSM Smartphone</h1>" +
                        "Xiomi (Versión Internacional)" +
                        "<br/>" +
                        "<br/>" +
                        "$" + miwebserv.selectComprador(1).Id + " " + miwebserv.selectComprador(1).Nombre + " " + miwebserv.selectComprador(1).Apellido + " " +
                        "</section>" +
                        "<hr/>";
            }
            */

            Comprador c = new Comprador(15,"Jose","Puebla","1004569870","jpuebla","158","Ibarra",1,"jpuebla@gmail.com","Quito","0985623148",new DateTime(2017,2,23));
            Proveedor p = new Proveedor(15, "Jose", "Puebla", "1004569870", "jpuebla", "158", "Ibarra", "1235");
            Servicio servicio = new Servicio();

            

            if (Conexion.getInstancia().getConexion() != null)
            {
                result.InnerHtml = result.InnerHtml + "<img src='https://equiposlibres.pe/wp-content/uploads/2019/07/Mi9T-1.png'/>" +
                        "<section>" +
                        "<h1> Xiaomi Mi 9T 64GB + 4GB RAM 6.39'' 48MP Triple Cámara LTE Desbloqueado de fábrica GSM Smartphone</h1>" +
                        "Xiomi (Versión Internacional)" +
                        "<br/>" +
                        "<br/>" +
                        "$" + servicio.insertProveedor(p) +
                        "</section>" +
                        "<hr/>";
            }

        }
    }
}