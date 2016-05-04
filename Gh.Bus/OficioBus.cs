using Gh.Common;
using Gh.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gh.Bus
{
    public class OficioBus : IBus<OficioDto>
    {
        OficioDao dao = null;

        public OficioBus()
        {
            dao = new OficioDao();
        }

        public OficioDto Add(OficioDto adding)
        {
            return dao.Add(adding);
        }

        public int Delete(OficioDto deleting)
        {
            return dao.Delete(deleting);
        }

        public List<OficioDto> GetAll()
        {
            return dao.GetAll();
        }

        public OficioDto GetById(int id)
        {
            return dao.GetById(id);
        }

        public int Update(OficioDto updating)
        {
            return dao.Update(updating);
        }
    }
}
