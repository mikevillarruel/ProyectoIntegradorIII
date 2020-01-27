﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_commerce.Models
{
    public class Proveedor
    {
        int id;
        String nombre;
        String email;
        String contrasenia;
        String tipo;

        public Proveedor()
        {

        }

        public Proveedor(int id, String nombre, String email,String contrasenia, String tipo)
        {
            this.id = id;
            this.nombre = nombre;
            this.email = email;
            this.contrasenia = contrasenia;
            this.tipo = tipo;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Email { get => email; set => email = value; }
        public string Contrasenia { get => contrasenia; set => contrasenia = value; }
        public string Tipo { get => tipo; set => tipo = value; }


    }
}