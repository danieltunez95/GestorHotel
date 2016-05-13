using Gh.Common;
using Gh.Dao;
using System.Collections.Generic;

namespace Gh.Bus
{
    public class PaisBus : IBusReadOnly<PaisDto>
    {
        PaisDao dao = null;

        public PaisBus()
        {
            dao = new PaisDao();
        }

        public List<PaisDto> GetAll()
        {
            return dao.GetAll();
        }

        public PaisDto GetById(int id)
        {
            return dao.GetById(id);
        }
    }
}
