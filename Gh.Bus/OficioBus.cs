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

        public Oficio Add(Oficio adding)
        {
            return dao.Add(adding);
        }

        public int Delete(Oficio deleting)
        {
            return dao.Delete(deleting);
        }

        public List<Oficio> GetAll()
        {
            return dao.GetAll();
        }

        public Oficio GetById(int id)
        {
            return dao.GetById(id);
        }

        public int Update(Oficio updating)
        {
            return dao.Update(updating);
        }
    }
}
