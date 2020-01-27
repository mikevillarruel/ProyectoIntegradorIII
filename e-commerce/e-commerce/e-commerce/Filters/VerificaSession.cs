using e_commerce.Controllers;
using e_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_commerce.Filters
{
    public class VerificaSession: ActionFilterAttribute
    {
        private Proveedor us;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);

                us = (Proveedor)HttpContext.Current.Session["Usuario"];
                if (us == null)
                {
                    if (filterContext.Controller is AccesoController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Acceso/Login");
                    }
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("ALGO PASA en filtro" + e);
            }
        }
        }
}