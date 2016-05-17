using System.Collections.Generic;
using Gh.Common;
using Gh.Dao;

namespace Gh.Bus
{
    public class EmpleadoBus : IBus<EmpleadoDto>
    {
        EmpleadoDao dao = null;
        
        public EmpleadoBus()
        {
            dao = new EmpleadoDao();
        }

        public EmpleadoDto Add(EmpleadoDto empleado)
        {
            return dao.Add(empleado);
        }

        public int Delete(EmpleadoDto empleado)
        {
            return dao.Delete(empleado);
        }

        public List<EmpleadoDto> GetAll()
        {
            return dao.GetAll();
        }

        public EmpleadoDto GetById(int id)
        {
            return dao.GetById(id);
        }

        public int Update(EmpleadoDto empleado)
        {
            return dao.Update(empleado);
        }
    }
}
