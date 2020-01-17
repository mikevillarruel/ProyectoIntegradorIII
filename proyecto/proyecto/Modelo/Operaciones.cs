using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using System.Data;

namespace proyecto.Modelo
{
    public class Operaciones
    {
        public Comprador selectComprador(int id)
        {
            Comprador comprador = null;
            try
            {
                OracleConnection conn = Conexion.getInstancia().getConexion();
                OracleCommand oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "select * from vnt_persona where PK_PER_ID=" + id;
                oracleCommand.CommandType = CommandType.Text;
                OracleDataReader odr = oracleCommand.ExecuteReader();
                comprador = new Comprador();
                if (odr.Read())
                {
                    comprador.Id = (int)odr.GetDecimal(0);
                    comprador.Nombre = odr.GetString(1);
                    comprador.Apellido = odr.GetString(2);
                    comprador.Cedula = odr.GetString(3);
                    comprador.Usuario = odr.GetString(4);
                    comprador.Contrasenia = odr.GetString(5);
                    comprador.Ciudad = odr.GetString(6);
                    comprador.Tipo = (int)odr.GetDecimal(7);
                    comprador.Email = odr.GetString(8);
                    comprador.Direccion = odr.GetString(9);
                    comprador.Telefono = odr.GetString(10);
                }
            }
            catch
            {
                return comprador;
            }
            return comprador;
        }

        public Boolean insertComprador(Comprador comprador)
        {
            try
            {
                OracleConnection conn = Conexion.getInstancia().getConexion();
                OracleCommand oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "insert into vnt_persona (PER_NOMBRE, PER_APELLIDO, PER_CEDULA, PER_USUARIO, PER_CONTRASENIA, PER_CIUDAD, PER_TIPO, PER_EMAIL, PER_DIRECCION, PER_TELEFONO) " +
                    "VALUES ('" + comprador.Nombre + "','" + comprador.Apellido + "','" + comprador.Cedula + "','" + comprador.Usuario + "','" + comprador.Contrasenia + "','" + comprador.Ciudad + "','" + comprador.Tipo + "','" + comprador.Email + "','" + comprador.Direccion + "','" + comprador.Telefono + "')";
                oracleCommand.CommandType = CommandType.Text;
                oracleCommand.ExecuteNonQuery();

                oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "select(pk_per_id) from vnt_persona where per_usuario = '" + comprador.Usuario + "'";
                oracleCommand.CommandType = CommandType.Text;
                OracleDataReader odr = oracleCommand.ExecuteReader();
                int myid = 0;
                while (odr.Read())
                {
                    myid = (int)odr.GetDecimal(0);
                }


                oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "insert into vnt_comprador (FK_PER_ID, CMP_NACIMIENTO) " +
                    "VALUES ('" + myid + "',TO_DATE('" + comprador.FechaDeNacimiento.ToString("yyyy-MM-dd") + "','YYYY-MM-DD'))";
                oracleCommand.CommandType = CommandType.Text;
                oracleCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }



        public Boolean insertAdministrador(Persona persona)
        {
            try
            {
                OracleConnection conn = Conexion.getInstancia().getConexion();
                OracleCommand oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "insert into vnt_persona (PER_NOMBRE, PER_APELLIDO, PER_CEDULA, PER_USUARIO, PER_CONTRASENIA, PER_CIUDAD, PER_TIPO, PER_EMAIL, PER_DIRECCION, PER_TELEFONO) " +
                    "VALUES ('" + persona.Nombre + "','" + persona.Apellido + "','" + persona.Cedula + "','" + persona.Usuario + "','" + persona.Contrasenia + "','" + persona.Ciudad + "','" + persona.Tipo + "','" + persona.Email + "','" + persona.Direccion + "','" + persona.Telefono + "')";
                oracleCommand.CommandType = CommandType.Text;
                oracleCommand.ExecuteNonQuery();

                oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "select(pk_per_id) from vnt_persona where per_usuario = '" + persona.Usuario + "'";
                oracleCommand.CommandType = CommandType.Text;
                OracleDataReader odr = oracleCommand.ExecuteReader();
                int myid = 0;
                while (odr.Read())
                {
                    myid = (int)odr.GetDecimal(0);
                }


                oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "insert into vnt_administrador (FK_PER_ID) " +
                    "VALUES ('" + myid + "')";
                oracleCommand.CommandType = CommandType.Text;
                oracleCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public Boolean insertProveedor(Proveedor proveedor)
        {
            try
            {
                OracleConnection conn = Conexion.getInstancia().getConexion();
                OracleCommand oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "insert into vnt_proveedor (PVD_NOMBRE, PVD_DIRECCION, PVD_CIUDAD, PVD_TELEFONO, PVD_EMAIL, PVD_USUARIO, PVD_CONTRASENIA)" +
                    "VALUES ('" + proveedor.Nombre + "','" + proveedor.Direccion + "','" + proveedor.Ciudad + "','" + proveedor.Telefono + "','" + proveedor.Email + "','" + proveedor.Usuario + "','" + proveedor.Contrasenia + "')";
                oracleCommand.CommandType = CommandType.Text;
                oracleCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public Boolean usuarioPersona(String usuario, String contrasenia)
        {
            try
            {
                OracleConnection conn = Conexion.getInstancia().getConexion();
                OracleCommand oracleCommand = conn.CreateCommand();
                
                oracleCommand.CommandText = "SELECT * FROM VNT_PERSONA WHERE PER_USUARIO LIKE '" + usuario + "' AND PER_CONTRASENIA LIKE '" + contrasenia+"'";
                oracleCommand.CommandType = CommandType.Text;
                OracleDataReader odr = oracleCommand.ExecuteReader();

                if (odr.Read())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public Boolean usuarioProveedor(String usuario, String contrasenia)
        {
            try
            {
                OracleConnection conn = Conexion.getInstancia().getConexion();
                OracleCommand oracleCommand = conn.CreateCommand();

                oracleCommand.CommandText = "SELECT * FROM VNT_PROVEEDOR WHERE PVD_USUARIO LIKE '" + usuario + "' AND PVD_CONTRASENIA LIKE '" + contrasenia + "'";
                oracleCommand.CommandType = CommandType.Text;
                OracleDataReader odr = oracleCommand.ExecuteReader();

                if (odr.Read())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public int selectTipo(String usuario, String contrasenia)
        {
            //ADMIN 1
            //COMPRADOR 2
            int tipo = 0;
            try
            {
                OracleConnection conn = Conexion.getInstancia().getConexion();
                OracleCommand oracleCommand = conn.CreateCommand();

                oracleCommand.CommandText = "SELECT PER_TIPO FROM VNT_PERSONA WHERE PER_USUARIO LIKE '" + usuario + "' AND PER_CONTRASENIA LIKE '" + contrasenia + "'";
                oracleCommand.CommandType = CommandType.Text;
                OracleDataReader odr = oracleCommand.ExecuteReader();

                if (odr.Read())
                {
                    tipo=(int)odr.GetDecimal(0);
                    return tipo;
                }
            }
            catch
            {
                return tipo;
            }
            return tipo;
        }



        public Boolean insertProducto(Producto producto, byte[] img)
        {
            try
            {
                OracleConnection conn = Conexion.getInstancia().getConexion();
                OracleCommand oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "select(pk_cat_id) from vnt_categoria where cat_nombre LIKE '" + producto.Categoria + "'";
                oracleCommand.CommandType = CommandType.Text;
                OracleDataReader odr = oracleCommand.ExecuteReader();
                int myid = 0;
                while (odr.Read())
                {
                    myid = (int)odr.GetDecimal(0);
                }

                oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "insert into vnt_producto (FK_CAT_ID, FK_PVD_ID, PRO_NOMBRE, PRO_DESCRIPCION, PRO_PRECIO,PRO_IMAGEN) " +
                    "VALUES (" + myid + "," + "1" + ",'" + producto.Nombre + "','" + producto.Descripcion + "'," + producto.Precio + ",:BlobParameter)";
                OracleParameter blobParameter = new OracleParameter();
                blobParameter.OracleDbType = OracleDbType.Blob;
                blobParameter.ParameterName = "BlobParameter";
                blobParameter.Value = img;
                oracleCommand.Parameters.Add(blobParameter);

                oracleCommand.CommandType = CommandType.Text;
                oracleCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public void enviarDatosProducto(String[] lectura, String[] ID_CATEGORIA, String[] ID_PROVEEDOR, String[] NOMBRE_PRODUCTO, String[] DESCRIPCION_PRODUCTO, String[] PRECIO_PRODUCTO, String[] IMAGEN_PRODUCTO)
        {
            for (int n = 0; n < lectura.Length; n++)
            {
                OracleConnection conn = Conexion.getInstancia().getConexion();
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandText = "insert into vnt_producto (FK_CAT_ID, FK_PVD_ID, PRO_NOMBRE, PRO_DESCRIPCION, PRO_PRECIO) VALUES (:id_categoria,:id_proveedor,:nombre_producto,:descripcion_producto,:precio_producto)";
                cmd.CommandType = System.Data.CommandType.Text;
                //valores de los parámetros
                cmd.Parameters.Add(":id_categoria", ID_CATEGORIA[n]);
                cmd.Parameters.Add(":id_proveedor", ID_PROVEEDOR[n]);
                cmd.Parameters.Add(":nombre_producto", NOMBRE_PRODUCTO[n]);
                cmd.Parameters.Add(":descripcion_producto", DESCRIPCION_PRODUCTO[n]);
                cmd.Parameters.Add(":precio_producto", PRECIO_PRODUCTO[n]);
                //cmd.ExecuteNonQuery();
                OracleDataReader dr = cmd.ExecuteReader();

            }
        }


        public void cambiarContrasenaPersona(String usuario, String contrasenia)
        {
            try
            {
                OracleConnection conn = Conexion.getInstancia().getConexion();
                OracleCommand oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "UPDATE VNT_PERSONA SET PER_CONTRASENIA='" + contrasenia + "'WHERE PER_USUARIO LIKE '"+usuario+"'";
                oracleCommand.CommandType = CommandType.Text;
                oracleCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
            }

        }



        public void cambiarContrasenaProveedor(String usuario, String contrasenia)
        {
            try
            {
                OracleConnection conn = Conexion.getInstancia().getConexion();
                OracleCommand oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "UPDATE VNT_PROVEEDOR SET PVD_CONTRASENIA='" + contrasenia + "'WHERE PVD_USUARIO LIKE '" + usuario + "'";
                oracleCommand.CommandType = CommandType.Text;
                oracleCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
            }

        }


        public Boolean usuarioPersonaC(String usuario)
        {
            try
            {
                OracleConnection conn = Conexion.getInstancia().getConexion();
                OracleCommand oracleCommand = conn.CreateCommand();

                oracleCommand.CommandText = "SELECT * FROM VNT_PERSONA WHERE PER_USUARIO LIKE '" + usuario + "'";
                oracleCommand.CommandType = CommandType.Text;
                OracleDataReader odr = oracleCommand.ExecuteReader();

                if (odr.Read())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public Boolean usuarioProveedorC(String usuario)
        {
            try
            {
                OracleConnection conn = Conexion.getInstancia().getConexion();
                OracleCommand oracleCommand = conn.CreateCommand();

                oracleCommand.CommandText = "SELECT * FROM VNT_PROVEEDOR WHERE PVD_USUARIO LIKE '" + usuario + "'";
                oracleCommand.CommandType = CommandType.Text;
                OracleDataReader odr = oracleCommand.ExecuteReader();

                if (odr.Read())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }


        public List<Producto> selectMisProductos(String usuario)
        {
            List<Producto> listaProductos = new List<Producto>();


           try
            {
                OracleConnection conn = Conexion.getInstancia().getConexion();
                OracleCommand oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "SELECT P.PRO_NOMBRE, P.PRO_DESCRIPCION, P.PRO_PRECIO, C.CAT_NOMBRE FROM VNT_PRODUCTO P, VNT_CATEGORIA C, VNT_PROVEEDOR V WHERE P.FK_CAT_ID LIKE C.PK_CAT_ID AND V.PK_PVD_ID LIKE P.FK_PVD_ID AND V.PVD_USUARIO LIKE '"+ usuario+"'";
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
            catch
            {
                return listaProductos;
            }
            return listaProductos;
        }


        public Producto selectUnProducto(String usuario, String nombrePro)
        {
            Producto unProducto = new Producto();
            try
             {
            OracleConnection conn = Conexion.getInstancia().getConexion();
            OracleCommand oracleCommand = conn.CreateCommand();
            oracleCommand.CommandText = "SELECT P.PRO_NOMBRE, P.PRO_DESCRIPCION, P.PRO_PRECIO, C.CAT_NOMBRE FROM VNT_PRODUCTO P, VNT_CATEGORIA C, VNT_PROVEEDOR V WHERE P.FK_CAT_ID LIKE C.PK_CAT_ID AND V.PK_PVD_ID LIKE P.FK_PVD_ID AND V.PVD_USUARIO LIKE '" + usuario + "' AND P.PRO_NOMBRE LIKE '"+nombrePro+"'";
            oracleCommand.CommandType = CommandType.Text;
            OracleDataReader odr = oracleCommand.ExecuteReader();
            int i = 0;
            while (odr.Read())
            {
                unProducto.Nombre = odr.GetString(0);
                unProducto.Descripcion = odr.GetString(1);
                unProducto.Precio = odr.GetDecimal(2);
                unProducto.Categoria = odr.GetString(3);
            }
            }
             catch
             {
                 return unProducto;
             }
            return unProducto;
        }



        public void updateUnProducto(String usuario, String nombrePro, Producto producto)
        {
            try
            {
                OracleConnection conn = Conexion.getInstancia().getConexion();
                OracleCommand oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "UPDATE VNT_PRODUCTO SET PRO_NOMBRE='" + producto.Nombre + "', PRO_DESCRIPCION = '"+producto.Descripcion+"', PRO_PRECIO="+producto.Precio+" WHERE PRO_NOMBRE LIKE '"+nombrePro+"'";
                oracleCommand.CommandType = CommandType.Text;
                oracleCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {

            }
        }

        public void deleteUnProducto(String usuario, String nombrePro) {
            try
            {
                OracleConnection conn = Conexion.getInstancia().getConexion();
                OracleCommand oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "DELETE FROM VNT_PRODUCTO WHERE PRO_NOMBRE LIKE '"+nombrePro+"' AND FK_PVD_ID LIKE (SELECT P.PK_PVD_ID FROM VNT_PROVEEDOR P WHERE P.PVD_USUARIO LIKE '"+usuario+"')";
                oracleCommand.CommandType = CommandType.Text;
                oracleCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {

            }
        }


        public List<Producto> selectTodosProductos()
        {
            List<Producto> listaProductos = new List<Producto>();


            try
            {
                OracleConnection conn = Conexion.getInstancia().getConexion();
                OracleCommand oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "SELECT P.PRO_NOMBRE, P.PRO_DESCRIPCION, P.PRO_PRECIO, C.CAT_NOMBRE FROM VNT_PRODUCTO P, VNT_CATEGORIA C, VNT_PROVEEDOR V WHERE P.FK_CAT_ID LIKE C.PK_CAT_ID AND V.PK_PVD_ID LIKE P.FK_PVD_ID";
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
            catch
            {
                return listaProductos;
            }
            return listaProductos;
        }

        public List<Producto> selectVerProducto(String nombrePro)
        {
            List<Producto> listaProductos = new List<Producto>();
            try
            {
                OracleConnection conn = Conexion.getInstancia().getConexion();
                OracleCommand oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "SELECT P.PRO_NOMBRE, P.PRO_DESCRIPCION, P.PRO_PRECIO, C.CAT_NOMBRE FROM VNT_PRODUCTO P, VNT_CATEGORIA C, VNT_PROVEEDOR V WHERE P.FK_CAT_ID LIKE C.PK_CAT_ID AND V.PK_PVD_ID LIKE P.FK_PVD_ID AND P.PRO_NOMBRE LIKE '" + nombrePro + "'";
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
            catch
            {
                return listaProductos;
            }
            return listaProductos; 
        }

        public Producto selectCartProducto(String nombrePro)
        {
            Producto unProducto = new Producto();
            try
            {
                OracleConnection conn = Conexion.getInstancia().getConexion();
                OracleCommand oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "SELECT P.PRO_NOMBRE, P.PRO_DESCRIPCION, P.PRO_PRECIO, C.CAT_NOMBRE FROM VNT_PRODUCTO P, VNT_CATEGORIA C, VNT_PROVEEDOR V WHERE P.FK_CAT_ID LIKE C.PK_CAT_ID AND V.PK_PVD_ID LIKE P.FK_PVD_ID AND P.PRO_NOMBRE LIKE '" + nombrePro + "'";
                oracleCommand.CommandType = CommandType.Text;
                OracleDataReader odr = oracleCommand.ExecuteReader();
                int i = 0;
                while (odr.Read())
                {
                    
                    unProducto.Nombre = odr.GetString(0);
                    unProducto.Descripcion = odr.GetString(1);
                    unProducto.Precio = odr.GetDecimal(2);
                    unProducto.Categoria = odr.GetString(3);
                    unProducto.Cantidad = 1;
                    unProducto.Total= odr.GetDecimal(2);
                    i = i + 1;
                }
            }
            catch
            {
                return unProducto;
            }
            return unProducto;
        }


        public List<estadistica> selectMisReporte()
        {
            List<estadistica> listaReporte = new List<estadistica>();


            try
            {
                OracleConnection conn = Conexion.getInstancia().getConexion();
                OracleCommand oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "SELECT ANIO, PRODUCTO, CANTIDAD, PROVEEDOR FROM ESTADISTICA  ORDER BY CANTIDAD DESC";
                oracleCommand.CommandType = CommandType.Text;
                OracleDataReader odr = oracleCommand.ExecuteReader();
                int i = 0;
                while (odr.Read())
                {
                    estadistica unProducto = new estadistica();
                    unProducto.Anio = odr.GetString(0);
                    unProducto.Producto = odr.GetString(1);
                    unProducto.Cantidad = odr.GetDecimal(2).ToString();
                    unProducto.Proveedor = odr.GetString(3);
                    listaReporte.Add(unProducto);
                    i = i + 1;

                }
            }
            catch
            {
                return listaReporte;
            }
            return listaReporte;
        }
    }
}