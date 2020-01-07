using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using proyecto.Modelo;
using System.IO;

namespace proyecto.Controlador
{
    public class Servicio
    {
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
    }
}