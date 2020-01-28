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

        public ActionResult Registrar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registrar(Proveedor proveedor)
        {
            
            if (proveedor.Tipo.Equals("P") || proveedor.Tipo.Equals("D"))
            {
                servicio.insertProveedor(proveedor);
            }
            else if (proveedor.Tipo.Equals("C"))
            {
                servicio.insertProveedor(proveedor);
            }
            else if (proveedor.Tipo.Equals("A"))
            {
                servicio.insertProveedor(proveedor);
            }
            ViewBag.Message = "";

            return RedirectToAction("Login");
        }
    }
}