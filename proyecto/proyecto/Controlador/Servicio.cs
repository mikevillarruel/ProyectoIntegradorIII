﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using proyecto.Modelo;
using System.IO;

namespace proyecto.Controlador
{
    public class Servicio
    {
        List<Producto> listaCart = new List<Producto>();

        public void cambiarContrasenaPersona(String usuario, String contrasena)
        {
            Operaciones op = new Operaciones();
            op.cambiarContrasenaPersona(usuario, contrasena);
        }

        public void cambiarContrasenaProveedor(String usuario, String contrasena)
        {
            Operaciones op = new Operaciones();
            op.cambiarContrasenaProveedor(usuario, contrasena);
        }
        public Comprador selectComprador(int id)
        {
            Operaciones op = new Operaciones();
            return op.selectComprador(id);
        }

        public Boolean insertProducto(Producto producto, byte[] img)
        {
            Operaciones op = new Operaciones();
            return op.insertProducto(producto, img);
        }

        public Boolean insertAdministrador(Persona persona)
        {
            Operaciones op = new Operaciones();
            return op.insertAdministrador(persona);
        }

        public Boolean insertComprador(Comprador comprador)
        {
            Operaciones op = new Operaciones();
            return op.insertComprador(comprador);
        }

        public Boolean insertProveedor(Proveedor proveedor)
        {
            Operaciones op = new Operaciones();
            return op.insertProveedor(proveedor);
        }

        public int abrirIndex(String usuario, String contrasenia)
        {
            Operaciones op = new Operaciones();
            int tipoUsuario = 0;
            if (op.selectTipo(usuario, contrasenia) == 1)
            {
                return tipoUsuario = 1;
            }
            else if (op.selectTipo(usuario, contrasenia) == 2)
            {
                return tipoUsuario = 2;
            }
            return tipoUsuario;
        }

        public string iniciarSesion(String usuario, String contrasenia)
        {
            Operaciones op = new Operaciones();
            String tipoUsuario="";

            if (op.usuarioPersona(usuario, contrasenia))
            {
                //identificar tipo admin
                //identificar tipo comprador
                //abrir index cada uno
                return tipoUsuario = "Persona";
            }
            else if (op.usuarioProveedor(usuario,contrasenia))
            {
                //abrir index
                return tipoUsuario = "Proveedor";
            }
            return tipoUsuario;
        }

        public string iniciarSesionC(String usuario)
        {
            Operaciones op = new Operaciones();
            String tipoUsuario = "";

            if (op.usuarioPersonaC(usuario))
            {
                //identificar tipo admin
                //identificar tipo comprador
                //abrir index cada uno
                return tipoUsuario = "Persona";
            }
            else if (op.usuarioProveedorC(usuario))
            {
                //abrir index
                return tipoUsuario = "Proveedor";
            }
            return tipoUsuario;
        }


        public void enviarDatosProducto()
        {

        }

        public void extraerDatos(String extension, String savePath)
        {
            String[] lectura;
            String[] ID_CATEGORIA;
            String[] ID_PROVEEDOR;
            String[] NOMBRE_PRODUCTO;
            String[] DESCRIPCION_PRODUCTO;
            String[] PRECIO_PRODUCTO;
            String[] IMAGEN_PRODUCTO;
            Operaciones op = new Operaciones();
            lectura = File.ReadAllLines(savePath);
            int numLineas = lectura.Length;
            Char sep;

            ID_CATEGORIA = new String[numLineas];
            ID_PROVEEDOR = new String[numLineas];
            NOMBRE_PRODUCTO = new String[numLineas];
            DESCRIPCION_PRODUCTO = new String[numLineas];
            PRECIO_PRODUCTO = new String[numLineas];
            IMAGEN_PRODUCTO = new String[numLineas];

            if (extension == ".txt")
            {
                sep = '|';
            }
            else
            {
                sep = ';';
            }

            for (int j = 0; j < lectura.Length; j++)
            {
                ID_CATEGORIA[j] = lectura[j].Split(sep)[0];
                ID_PROVEEDOR[j] = lectura[j].Split(sep)[1];
                NOMBRE_PRODUCTO[j] = lectura[j].Split(sep)[2];
                DESCRIPCION_PRODUCTO[j] = lectura[j].Split(sep)[3];
                PRECIO_PRODUCTO[j] = lectura[j].Split(sep)[4];
                IMAGEN_PRODUCTO[j] = lectura[j].Split(sep)[5];
            }

            op.enviarDatosProducto(lectura, ID_CATEGORIA, ID_PROVEEDOR, NOMBRE_PRODUCTO, DESCRIPCION_PRODUCTO, PRECIO_PRODUCTO, IMAGEN_PRODUCTO);
        }



        public string Encriptar(String cadena)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(cadena);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        public string DesEncriptar(String cadena)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(cadena);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }


        public List<Producto> selectMisProductos(String usuario)
        {
            Operaciones op = new Operaciones();
            List<Producto> listaProductos = new List<Producto>();
            listaProductos = op.selectMisProductos(usuario);

            return listaProductos;
        }

        public Producto selectProducto(String usuario, String nombrePro)
        {
            Operaciones op = new Operaciones();
            Producto producto = new Producto();

            producto = op.selectUnProducto(usuario, nombrePro);

            return producto;
        }

        public void updateUnProducto(String usuario, String nombrePro, Producto producto)
        {
            Operaciones op = new Operaciones();
            op.updateUnProducto(usuario, nombrePro, producto);
        }

        public void deleteUnProducto(String usuario, String nombrePro)
        {
            Operaciones op = new Operaciones();
            op.deleteUnProducto(usuario, nombrePro);
        }
    
        public List<Producto> selectTodosProductos()
        {
            Operaciones op = new Operaciones();
            List<Producto> listaProductos = new List<Producto>();
            listaProductos = op.selectTodosProductos();

            return listaProductos;

        }

        public List<Producto> selectVerProducto(String nombrePro)
        {
            Operaciones op = new Operaciones();
            List<Producto> listaProductos = new List<Producto>();
            listaProductos = op.selectVerProducto(nombrePro);

            return listaProductos;

        }
        /*
        public List<Producto> selectCartProducto(String nombrePro)
        {
            Operaciones op = new Operaciones();
            Producto unProducto = new Producto();

            unProducto = op.selectCartProducto(nombrePro);
            listaCart.Add(unProducto);

            return listaCart;
        }*/

        public Producto selectCartProducto(String nombrePro)
        {
            Operaciones op = new Operaciones();
            Producto unProducto = new Producto();

            unProducto = op.selectCartProducto(nombrePro);

            return unProducto;
        }




        public List<estadistica> selectMisReporte()
        {
            Operaciones op = new Operaciones();
            List<estadistica> listaReporte = new List<estadistica>();
            listaReporte = op.selectMisReporte();

            return listaReporte;
        }
    }
}