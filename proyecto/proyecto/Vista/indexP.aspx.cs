using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyecto.Vista
{
    public partial class indexP : System.Web.UI.Page
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
        protected void btnCerrar_Click1(object sender, EventArgs e)
        {
            Session.Remove("usP");
            Response.Redirect("~/Vista/Login.aspx");
        }
    }
}