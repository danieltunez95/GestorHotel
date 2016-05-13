using Gh.Common;
using Gh.Dao;
using System.Collections.Generic;

namespace Gh.Bus
{
    public class MunicipioBus : IBus<MunicipioDto>
    {
        MunicipioDao dao = null;

        public MunicipioBus()
        {
            dao = new MunicipioDao();
        }

        public MunicipioDto Add(MunicipioDto municipio)
        {
            return dao.Add(municipio);
        }

        public int Delete(MunicipioDto municipio)
        {
            return dao.Delete(municipio);
        }

        public List<MunicipioDto> GetAll()
        {
            return dao.GetAll();
        }

        public MunicipioDto GetById(int id)
        {
            return dao.GetById(id);
        }

        public int Update(MunicipioDto municipio)
        {
            return dao.Update(municipio);
        }
    }
}
