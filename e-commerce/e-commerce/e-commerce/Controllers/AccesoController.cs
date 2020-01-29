using System;
using System.Collections.Generic;
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
        public List<SelectListItem> obtenerRoles()
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            List<Models.Rol> cat = new List<Models.Rol>();
            Models.Operaciones op = new Models.Operaciones();
            cat = op.getRoles();
            foreach (var item in cat)
            {
                lista.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Nombre });
            }
            return lista;
        }
        public ActionResult Registrar()
        {
            
            ViewBag.ListRoles = obtenerRoles();
            return View();
        }
        [HttpPost]
        public ActionResult Registrar(Proveedor proveedor)
        {
            
            if (proveedor.Rol==1)
            {
                proveedor.Tipo = "A";
                servicio.insertProveedor(proveedor);
            }
            else if (proveedor.Rol==2)
            {
                proveedor.Tipo = "P";
                servicio.insertProveedor(proveedor);
            }
            else 
            {
                proveedor.Tipo = "C";
                servicio.insertProveedor(proveedor);
            }
            ViewBag.Message = "";

            return RedirectToAction("Login");
        }
    }
}