using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using System.Data;
using System.IO;

namespace e_commerce.Models
{
    public class Operaciones
    {

        public string Encriptar(String cadena)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(cadena);
            result = Convert.ToBase64String(encryted);
            return result;
        }



        public Proveedor usuarioPersona(String usuario, String contrasenia)
        {
            //System.Windows.Forms.MessageBox.Show("Error" + contrasenia);
            contrasenia = Encriptar(contrasenia);
            //System.Windows.Forms.MessageBox.Show("Error" + contrasenia);
            List<Proveedor> proveedores = new List<Proveedor>();
            Proveedor us = new Proveedor();
            try
            {
                OracleConnection conn = Conexion.getInstancia().getConexion();
                OracleCommand oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "SELECT * FROM TBL_USUARIO WHERE USUARIO_EMAIL LIKE '" + usuario + "' AND USUARIO_CONTRASENIA LIKE '" + contrasenia + "'";
                oracleCommand.CommandType = CommandType.Text;
                OracleDataReader odr = oracleCommand.ExecuteReader();
                int i = 0;
                while (odr.Read())
                {
                    us.Id = (int)odr.GetDecimal(0);
                    us.Tarjeta = (int)odr.GetDecimal(1);
                    us.Nombre = odr.GetString(2);
                    us.Apellido = odr.GetString(3);
                    us.Email = odr.GetString(4);
                    us.Contrasenia = odr.GetString(5);
                    us.Tipo = odr.GetString(6);
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("catch en operacion" + e);
                return us;
            }
            return us;
        }
        public List<Proveedor> selectAllProveedores()
        {
            List<Proveedor> proveedores = new List<Proveedor>();
            try
            {
                OracleConnection conn = Conexion.getInstancia().getConexion();
                OracleCommand oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "SELECT USUARIO_ID, USUARIO_NOMBRE, USUARIO_EMAIL, USUARIO_CONTRASENIA, USUARIO_TIPO FROM TBL_USUARIO WHERE usuario_tipo='P' or usuario_tipo='D'";
                oracleCommand.CommandType = CommandType.Text;
                OracleDataReader odr = oracleCommand.ExecuteReader();
                int i = 0;
                while (odr.Read())
                {
                    Proveedor pro = new Proveedor();
                    pro.Id = (int)odr.GetDecimal(0);
                    pro.Nombre = odr.GetString(1);
                    pro.Email = odr.GetString(2);
                    pro.Contrasenia = odr.GetString(3);
                    pro.Tipo = odr.GetString(4);
                    proveedores.Add(pro);
                    i = i + 1;
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("ALGO PASA en proveedores" + e);
                return proveedores;
            }
            return proveedores;
        }

        public Proveedor selectProveedor(int id)
        {
            Proveedor proveedor = new Proveedor();
            try
            {
                OracleConnection conn = Conexion.getInstancia().getConexion();
                OracleCommand oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "SELECT USUARIO_ID, USUARIO_NOMBRE, USUARIO_EMAIL, USUARIO_CONTRASENIA, USUARIO_TIPO FROM TBL_USUARIO WHERE USUARIO_ID=" + id;
                oracleCommand.CommandType = CommandType.Text;
                OracleDataReader odr = oracleCommand.ExecuteReader();
                int i = 0;
                while (odr.Read())
                {
                    proveedor.Id = (int) odr.GetDecimal(0);
                    proveedor.Nombre = odr.GetString(1);
                    proveedor.Email = odr.GetString(2);
                    proveedor.Contrasenia = odr.GetString(3);
                    proveedor.Tipo = odr.GetString(4);
                }
            }
            catch
            {
                return proveedor;
            }
            return proveedor;
        }

        public void updateProveedor(Proveedor proveedor)
        {
            try
            {
                OracleConnection conn = Conexion.getInstancia().getConexion();
                OracleCommand oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "UPDATE TBL_USUARIO SET USUARIO_NOMBRE='" + proveedor.Nombre + "', USUARIO_EMAIL = '" + proveedor.Email + "', USUARIO_CONTRASENIA='" + proveedor.Contrasenia + "' WHERE USUARIO_ID =" + proveedor.Id;
                oracleCommand.CommandType = CommandType.Text;
                oracleCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(proveedor.Nombre + "|" + proveedor.Id+ e);
            }
        }

        public Boolean insertProveedor(Proveedor proveedor)
        {
            proveedor.Contrasenia = Encriptar(proveedor.Contrasenia);
            try
            {
                System.Windows.Forms.MessageBox.Show("" + proveedor.Nombre);
                OracleConnection conn = Conexion.getInstancia().getConexion();
                OracleCommand oracleCommand = conn.CreateCommand();
                oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "insert into tbl_usuario (USUARIO_NOMBRE,USUARIO_APELLIDO, USUARIO_EMAIL,USUARIO_CONTRASENIA,USUARIO_TIPO,USUARIO_ROL,TARJETA_ID) " +
                    "VALUES ('"+proveedor.Nombre+"','"+proveedor.Apellido+"','"+proveedor.Email+"','"+proveedor.Contrasenia+"','"+proveedor.Tipo+ "','1','1')";
                oracleCommand.CommandType = CommandType.Text;
                oracleCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("" + e);

                return false;
            }
        }
        public List<Producto> selectAllProductos()
        {
            List<Producto> listaProductos = new List<Producto>();


            try
            {
                OracleConnection conn = Conexion.getInstancia().getConexion();
                OracleCommand oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "SELECT P.PRODUCTO_NOMBRE, P.PRODUCTO_DESCRIPCION, P.PRODUCTO_PRECIO, C.CATEGORIA_NOMBRE,P.PRODUCTO_CANTIDAD,P.PRODUCTO_IMAGEN FROM TBL_PRODUCTO P, TBL_CATEGORIA C WHERE C.CATEGORIA_ID LIKE P.CATEGORIA_ID";
                oracleCommand.CommandType = CommandType.Text;
                OracleDataReader odr = oracleCommand.ExecuteReader();
                int i = 0;
                while (odr.Read())
                {
                    Producto unProducto = new Producto();
                    unProducto.Nombre = odr.GetString(0);
                    unProducto.Descripcion = odr.GetString(1);
                    unProducto.Precio = odr.GetDecimal(2);
                    unProducto.Categoria = odr.GetString(3);
                    unProducto.Cantidad = (int)odr.GetDecimal(4);
                    unProducto.Imagen = odr.GetString(5);
                    listaProductos.Add(unProducto);
                    i = i + 1;

                }
            }
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show("ALGO PASA en productos" + e);
                return listaProductos;
            }
            return listaProductos;
        }

        public Producto selectUnProducto(String nombrePro)
        {
            Producto unProducto = new Producto();
            try
            {
                OracleConnection conn = Conexion.getInstancia().getConexion();
                OracleCommand oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "SELECT P.PRODUCTO_NOMBRE, P.PRODUCTO_DESCRIPCION, P.PRODUCTO_PRECIO,P.PRODUCTO_CANTIDAD,P.PRODUCTO_IMAGEN FROM TBL_PRODUCTO P WHERE P.PRODUCTO_NOMBRE LIKE '"+nombrePro+"'";
                oracleCommand.CommandType = CommandType.Text;
                OracleDataReader odr = oracleCommand.ExecuteReader();
                int i = 0;
                while (odr.Read())
                {
                    unProducto.Nombre = odr.GetString(0);
                    unProducto.Descripcion = odr.GetString(1);
                    unProducto.Precio = odr.GetDecimal(2);
                    unProducto.Cantidad = (int)odr.GetDecimal(3);
                    unProducto.Imagen = odr.GetString(4);
                }
            }
            catch
            {
                return unProducto;
            }
            return unProducto;
        }

        public void updateUnProducto(Producto producto)
        {
            try
            {
                OracleConnection conn = Conexion.getInstancia().getConexion();
                OracleCommand oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "UPDATE TBL_PRODUCTO SET PRODUCTO_NOMBRE='" + producto.Nombre + "', PRODUCTO_DESCRIPCION = '" + producto.Descripcion + "', PRODUCTO_PRECIO=" + producto.Precio + ",PRODUCTO_IMAGEN='"+ producto.Imagen+ "',PRODUCTO_CANTIDAD="+producto.Cantidad+ " WHERE PRODUCTO_NOMBRE LIKE '" + producto.Nombre + "'";
                oracleCommand.CommandType = CommandType.Text;
                oracleCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(producto.Nombre + "|" + producto.Imagen+"|"+e);
            }
        }
        public Boolean insertProducto(Producto producto)
        {
            try
            {
                OracleConnection conn = Conexion.getInstancia().getConexion();
                OracleCommand oracleCommand = conn.CreateCommand();
                oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "insert into tbl_producto (categoria_id, usuario_id, PRODUCTO_NOMBRE, PRODUCTO_DESCRIPCION,PRODUCTO_CANTIDAD,PRODUCTO_PRECIO,PRODUCTO_IMAGEN) " +
                    "VALUES ("+ producto.Categoria + "," + "1" + ",'" + producto.Nombre + "','" + producto.Descripcion + "'," + producto.Cantidad + "," + producto.Precio + ",'"+producto.Imagen+"')";
                oracleCommand.CommandType = CommandType.Text;
                oracleCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("" + e);

                return false;
            }
        }

            public List<Categoria> getCategoria()
            {
                List<Categoria> categorias = new List<Categoria>();
                try
                {
                    OracleConnection conn = Conexion.getInstancia().getConexion();
                    OracleCommand oracleCommand = conn.CreateCommand();
                    oracleCommand.CommandText = "SELECT * FROM TBL_CATEGORIA";
                    oracleCommand.CommandType = CommandType.Text;
                    OracleDataReader odr = oracleCommand.ExecuteReader();
                    int i = 0;
                    while (odr.Read())
                    {
                        Categoria cat = new Categoria();
                        cat.Id = (int)odr.GetDecimal(0);
                        cat.Nombre = odr.GetString(1);
                        categorias.Add(cat);
                        i = i + 1;
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("ALGO PASA" + e);
                    return categorias;
                }
                return categorias;
            }

        public void extraerDatos(String extension, String savePath)
        {
            String[] lectura;
            String[] ID_CATEGORIA;
            String[] ID_PROVEEDOR;
            String[] NOMBRE_PRODUCTO;
            String[] DESCRIPCION_PRODUCTO;
            String[] IMAGEN_PRODUCTO;
            String[] CANTIDAD_PRODUCTO;
            String[] PRECIO_PRODUCTO;
            lectura = File.ReadAllLines(savePath);
            int numLineas = lectura.Length;
            Char sep;

            ID_CATEGORIA = new String[numLineas];
            ID_PROVEEDOR = new String[numLineas];
            NOMBRE_PRODUCTO = new String[numLineas];
            DESCRIPCION_PRODUCTO = new String[numLineas];
            IMAGEN_PRODUCTO = new String[numLineas];
            CANTIDAD_PRODUCTO = new String[numLineas];
            PRECIO_PRODUCTO = new String[numLineas];
            

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
                IMAGEN_PRODUCTO[j] = lectura[j].Split(sep)[4];  
                CANTIDAD_PRODUCTO[j] = lectura[j].Split(sep)[5];
                PRECIO_PRODUCTO[j] = lectura[j].Split(sep)[6];
                
            }
            for (int n = 0; n < lectura.Length; n++)
            {
                OracleConnection conn = Conexion.getInstancia().getConexion();
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandText = "insert into tbl_producto (categoria_id, usuario_id, PRODUCTO_NOMBRE, PRODUCTO_DESCRIPCION,PRODUCTO_IMAGEN,PRODUCTO_CANTIDAD,PRODUCTO_PRECIO) VALUES (:id_categoria,:id_proveedor,:nombre_producto,:descripcion_producto,:imagen_producto,:cantidad_producto,:precio_producto)";
                cmd.CommandType = System.Data.CommandType.Text;
                //valores de los parámetros
                cmd.Parameters.Add(":id_categoria", ID_CATEGORIA[n]);
                cmd.Parameters.Add(":id_proveedor", ID_PROVEEDOR[n]);
                cmd.Parameters.Add(":nombre_producto", NOMBRE_PRODUCTO[n]);
                cmd.Parameters.Add(":descripcion_producto", DESCRIPCION_PRODUCTO[n]);
                cmd.Parameters.Add(":imagen_producto", IMAGEN_PRODUCTO[n]);
                cmd.Parameters.Add(":cantidad_producto", CANTIDAD_PRODUCTO[n]);
                cmd.Parameters.Add(":precio_producto", PRECIO_PRODUCTO[n]);
                //cmd.ExecuteNonQuery();
                OracleDataReader dr = cmd.ExecuteReader();

            }

        }

        public void deleteUnProducto(String productoID)
        {
            try
            {
                OracleConnection conn = Conexion.getInstancia().getConexion();
                OracleCommand oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "DELETE FROM TBL_PRODUCTO WHERE PRODUCTO_NOMBRE LIKE '" + productoID + "'";
                oracleCommand.CommandType = CommandType.Text;
                oracleCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {

            }
        }
        public void deleteUnProveedor(int usuarioID)
        {
            try
            {
                OracleConnection conn = Conexion.getInstancia().getConexion();
                OracleCommand oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "DELETE FROM TBL_USUARIO WHERE USUARIO_ID LIKE '" + usuarioID + "'";
                oracleCommand.CommandType = CommandType.Text;
                oracleCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {

            }
        }
    }
}