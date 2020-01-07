using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyecto.Vista
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String nombre = Session["us"].ToString();
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Vista/Login.aspx?men=1");

            }

        }

        protected void btnCerrar_Click1(object sender, EventArgs e)
        {
            Session.Remove("us");
            Response.Redirect("~/Vista/Login.aspx");
        }
    }
}