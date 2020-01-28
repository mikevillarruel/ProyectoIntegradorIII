using System;
using System.Web.Mvc;
using e_commerce.siproe;

namespace e_commerce.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso

        siproe.ServicioWebSoapClient servicio = new siproe.ServicioWebSoapClient();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(String Usuario, String Pass)
        {
            try
            {
                Proveedor us = new Proveedor();
                us = servicio.iniciarSesion(Usuario, Pass);
                if (us.Email == null)
                {
                    ViewBag.Error = "Usuario o contraseña inválida";
                    return View();
                }
                else
                {
                    Session["Usuario"] = us;
                    return RedirectToAction("Dashboard", "Administrador");
                }

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}