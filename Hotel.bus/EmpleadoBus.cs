using GestorHotel.Bus.Interficies;
using GestorHotel.Common;
using GestorHotel.Dao;
using System.Collections.Generic;

namespace GestorHotel.Bus
{
    public class EmpleadoBus : IBus<Empleado>
    {
        EmpleadoDao dao = null;

        public EmpleadoBus()
        {
            dao = new EmpleadoDao();
        }
        public Empleado Add(Empleado adding)
        {
            return dao.Add(adding);
        }

        public int Delete(Empleado deleting)
        {
            return dao.Delete(deleting);
        }

        public List<Empleado> GetAll()
        {
            return dao.GetAll();
        }

        public Empleado GetById(int id)
        {
            return dao.GetById(id);
        }

        public int Update(Empleado updating)
        {
            return dao.Update(updating);
        }
    }
}
