using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using e_commerce.Models;

namespace e_commerce.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple =false)]
    public class UsuariosAutorizados : AuthorizeAttribute
    {
        private Proveedor proveedor;

    }
}