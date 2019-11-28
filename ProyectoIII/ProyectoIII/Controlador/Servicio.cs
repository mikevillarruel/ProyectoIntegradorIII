using ProyectoIII.Modelo;
using System;

namespace ProyectoIII.Controlador
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