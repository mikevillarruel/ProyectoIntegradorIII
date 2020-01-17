﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using proyecto.Controlador;
using proyecto.Modelo;

namespace proyecto.Vista
{
    public partial class cart : System.Web.UI.Page
    {
        String nombre;
        String nombrePro;
        Servicio servicio = new Servicio();
        List<Producto> listaCart = new List<Producto>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                nombre = Session["us"].ToString();
                //listaCart = Session["nomProducto"];
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Vista/Login.aspx?men=1");

            }

            llenarProductos();
        }


        public void llenarProductos()
        {
            //listaCart.Add(servicio.selectCartProducto(nombrePro));
            gvProductos.DataSource = listaCart;
            gvProductos.DataBind();
        }


    }
}