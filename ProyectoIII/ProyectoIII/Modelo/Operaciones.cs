using Oracle.DataAccess.Client;
using System;
using System.Data;

namespace ProyectoIII.Modelo
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
                oracleCommand.CommandText = "insert into vnt_persona (PK_PER_ID, PER_NOMBRE, PER_APELLIDO, PER_CEDULA, PER_USUARIO, PER_CONTRASENIA, PER_CIUDAD, PER_TIPO, PER_EMAIL, PER_DIRECCION, PER_TELEFONO) " +
                    "VALUES ('" + comprador.Id + "','" + comprador.Nombre + "','" + comprador.Apellido + "','" + comprador.Cedula + "','" + comprador.Usuario + "','" + comprador.Contrasenia + "','" + comprador.Ciudad + "','" + comprador.Tipo + "','" + comprador.Email + "','" + comprador.Direccion + "','" + comprador.Telefono + "')";
                oracleCommand.CommandType = CommandType.Text;
                oracleCommand.ExecuteNonQuery();

                oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "insert into vnt_comprador (PK_CMP_ID, FK_PER_ID, CMP_NACIMIENTO) " +
                    "VALUES ('" + comprador.Id + "','" + comprador.Id + "',TO_DATE('" + comprador.FechaDeNacimiento.ToString("yyyy-MM-dd") + "','YYYY-MM-DD'))";
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
                oracleCommand.CommandText = "insert into vnt_proveedor (PK_PVD_ID, PVD_NOMBRE, PVD_DIRECCION, PVD_CIUDAD, PVD_TELEFONO, PVD_EMAIL, PVD_USUARIO, PVD_CONTRASENIA)" +
                    "VALUES ('" + proveedor.Id + "','" + proveedor.Nombre + "','" + proveedor.Direccion + "','" + proveedor.Ciudad + "','" + proveedor.Telefono + "','" + proveedor.Email + "','" + proveedor.Usuario + "','" + proveedor.Contrasenia + "')";
                oracleCommand.CommandType = CommandType.Text;
                oracleCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public Boolean accesos(string nombrePantalla)
        {
            try
            {
                int accesos = 0;
                OracleConnection conn = Conexion.getInstancia().getConexion();
                OracleCommand oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "select accesos from estadistica_ingreso where nombre_pantalla='" + nombrePantalla + "'";
                oracleCommand.CommandType = CommandType.Text;
                OracleDataReader odr = oracleCommand.ExecuteReader();

                if (odr.Read())
                {
                    accesos = (int)odr.GetDecimal(0) + 1;

                    oracleCommand = conn.CreateCommand();
                    oracleCommand.CommandText = "update estadistica_ingreso set accesos='" + accesos + "' where nombre_pantalla='" + nombrePantalla + "'";
                    oracleCommand.CommandType = CommandType.Text;
                    oracleCommand.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    accesos = accesos + 1;
                    oracleCommand = conn.CreateCommand();
                    oracleCommand.CommandText = "insert into estadistica_ingreso (nombre_pantalla,accesos)" +
                        "VALUES ('" + nombrePantalla + "','" + accesos + "')";
                    oracleCommand.CommandType = CommandType.Text;
                    oracleCommand.ExecuteNonQuery();
                    return true;
                }

                
            }
            catch (Exception e)
            {
                return false;
            }

        }

    }
}