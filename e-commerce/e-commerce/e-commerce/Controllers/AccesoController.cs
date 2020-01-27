using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using e_commerce.Models;

namespace e_commerce.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(String Usuario, String Pass)
        {
            try
            {
                Usuario us= new Usuario();
                Servicio servicio = new Servicio();
                us = servicio.iniciarSesion(Usuario, Pass);
                if (us.Email==null)
                {
                    ViewBag.Error = "Usuario o contraseña inválida";
                    return View();
                }
                else
                {
                    Session["Usuario"] = us;
                    return RedirectToAction("Index", "Home");
                }
                
            }catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}