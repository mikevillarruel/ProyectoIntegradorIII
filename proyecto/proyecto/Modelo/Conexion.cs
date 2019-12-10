using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Forms;
using Oracle.DataAccess.Client;


namespace proyecto.Modelo
{
    public class Conexion
    {
        private OracleConnection conn = null;
        private static Conexion instancia = null;

        private Conexion()
        {
        }

        public static Conexion getInstancia()
        {
            if (instancia == null)
            {
                instancia = new Conexion();
            }
            return instancia;
        }

        public Boolean crearConexion()
        {
            conn = new OracleConnection("DATA SOURCE = localhost:1521/orcl ; PASSWORD = 123 ; USER ID = proyecto");
            try { conn.Open(); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            Console.WriteLine("Connected to Oracle");
            return true;
        }

        public OracleConnection getConexion()
        {
            if (conn == null)
            {
                crearConexion();
            }
            return conn;
        }

        public void desconectar()
        {
            conn.Close();
            conn = null;
        }

    }
}