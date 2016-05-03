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
        public EmpleadoDto Add(EmpleadoDto adding)
        {
            return dao.Add(adding);
        }

        public int Delete(EmpleadoDto deleting)
        {
            return dao.Delete(deleting);
        }

        public List<EmpleadoDto> GetAll()
        {
            return dao.GetAll();
        }

        public EmpleadoDto GetById(int id)
        {
            return dao.GetById(id);
        }

        public int Update(EmpleadoDto updating)
        {
            return dao.Update(updating);
        }
    }
}
