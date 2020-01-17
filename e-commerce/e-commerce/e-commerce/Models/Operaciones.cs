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
    }
}