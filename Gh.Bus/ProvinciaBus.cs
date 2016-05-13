using Gh.Common;
using Gh.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gh.Bus
{
    public class ProvinciaBus : IBusReadOnly<ProvinciaDto>
    {
        ProvinciaDao dao = null;

        public ProvinciaBus()
        {
            dao = new ProvinciaDao();
        }

        public List<ProvinciaDto> GetAll()
        {
            return dao.GetAll();
        }

        public ProvinciaDto GetById(int id)
        {
            return dao.GetById(id);
        }
    }
}
