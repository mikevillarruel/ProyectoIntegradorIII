using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using System.Data;

namespace e_commerce.Models
{
    public class Operaciones
    {
        public String selectPrueba()
        {
            //ADMIN 1
            //COMPRADOR 2
            String prueba="";
            try
            {
                OracleConnection conn = Conexion.getInstancia().getConexion();
                OracleCommand oracleCommand = conn.CreateCommand();

                oracleCommand.CommandText = "SELECT PRO_NOMBRE FROM VNT_PRODUCTO";
                oracleCommand.CommandType = CommandType.Text;
                OracleDataReader odr = oracleCommand.ExecuteReader();

                if (odr.Read())
                {
                    prueba = odr.GetString(0);
                    return prueba;
                }
            }
            catch
            {
                return prueba;
            }
            return prueba;
        }

        public List<Producto> selectMisProductos(String usuario)
        {
            List<Producto> listaProductos = new List<Producto>();


            try
            {
                OracleConnection conn = Conexion.getInstancia().getConexion();
                OracleCommand oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "SELECT P.PRODUCTO_NOMBRE, P.PRODUCTO_DESCRIPCION, P.PRODUCTO_PRECIO, C.CATEGORIA_NOMBRE FROM TBL_PRODUCTO P, TBL_CATEGORIA C, TBL_USUARIO V WHERE P.CATEGORIA_ID LIKE C.CATEGORIA_ID AND V.USUARIO_ID LIKE P.USUARIO_ID AND V.USUARIO_ID LIKE '" + usuario + "'";
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
                    listaProductos.Add(unProducto);
                    i = i + 1;

                }
            }
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show("ALGO PASA" + e);
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
                oracleCommand.CommandText = "SELECT P.PRODUCTO_NOMBRE, P.PRODUCTO_DESCRIPCION, P.PRODUCTO_PRECIO FROM TBL_PRODUCTO P WHERE P.PRODUCTO_NOMBRE LIKE '"+nombrePro+"'";
                oracleCommand.CommandType = CommandType.Text;
                OracleDataReader odr = oracleCommand.ExecuteReader();
                int i = 0;
                while (odr.Read())
                {
                    unProducto.Nombre = odr.GetString(0);
                    unProducto.Descripcion = odr.GetString(1);
                    unProducto.Precio = odr.GetDecimal(2);
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
                oracleCommand.CommandText = "UPDATE TBL_PRODUCTO SET PRODUCTO_NOMBRE='" + producto.Nombre + "', PRODUCTO_DESCRIPCION = '" + producto.Descripcion + "', PRODUCTO_PRECIO=" + producto.Precio + " WHERE PRODUCTO_NOMBRE LIKE '" + producto.Nombre + "'";
                oracleCommand.CommandType = CommandType.Text;
                oracleCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(producto.Nombre + "|" + producto.Precio+"|"+e);
            }
        }
    }
}