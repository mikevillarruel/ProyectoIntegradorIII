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

        public List<Producto> selectAllProductos()
        {
            List<Producto> listaProductos = new List<Producto>();


            try
            {
                OracleConnection conn = Conexion.getInstancia().getConexion();
                OracleCommand oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "SELECT P.PRODUCTO_NOMBRE, P.PRODUCTO_DESCRIPCION, P.PRODUCTO_PRECIO, C.CATEGORIA_NOMBRE,P.CANTIDAD FROM TBL_PRODUCTO P, TBL_CATEGORIA C, TBL_USUARIO V WHERE P.CATEGORIA_ID LIKE C.CATEGORIA_ID";
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
                oracleCommand.CommandText = "UPDATE TBL_PRODUCTO SET PRODUCTO_NOMBRE='" + producto.Nombre + "', PRODUCTO_DESCRIPCION = '" + producto.Descripcion + "', PRODUCTO_PRECIO=" + producto.Precio + "PRODUCTO_IMAGEN='"+ producto.Imagen+ "' WHERE PRODUCTO_NOMBRE LIKE '" + producto.Nombre + "'";
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
                //oracleCommand.CommandText = "select categoria_id from tbl_categoria where categoria_nombre LIKE '" + producto.Categoria + "'";
                //oracleCommand.CommandType = CommandType.Text;
                //OracleDataReader odr = oracleCommand.ExecuteReader();
                //int myid = 0;
                //while (odr.Read())
                //{
                //    myid = (int)odr.GetDecimal(0);
                //}
                oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "insert into tbl_producto (producto_id,categoria_id, usuario_id, PRODUCTO_NOMBRE, PRODUCTO_DESCRIPCION,CANTIDAD,PRODUCTO_PRECIO,PRODUCTO_IMAGEN) " +
                    "VALUES (3," + producto.Categoria + "," + "1" + ",'" + producto.Nombre + "','" + producto.Descripcion + "'," + producto.Cantidad + "," + producto.Precio + ",'"+producto.Imagen+"')";
                //OracleParameter blobParameter = new OracleParameter();
                //blobParameter.OracleDbType = OracleDbType.Blob;
                //blobParameter.ParameterName = "BlobParameter";
                //blobParameter.Value = img;
                //oracleCommand.Parameters.Add(blobParameter);

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
        }
    }