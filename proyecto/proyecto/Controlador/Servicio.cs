using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using proyecto.Modelo;

namespace proyecto.Controlador
{
    public class Servicio
    {
        public Comprador selectComprador(int id)
        {
            Operaciones op = new Operaciones();
            return op.selectComprador(id);
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
    }
}