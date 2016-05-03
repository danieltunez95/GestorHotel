using Gh.Common;
using System.Collections.Generic;

namespace Gh.Dao
{
    public class OficioDao : IDao<OficioDto>
    {
        public OficioDto Add(OficioDto entity)
        {
            string storedProcedure = "Oficio_Add";
            return entity;
        }

        public int Delete(OficioDto entity)
        {
            int result = 0;
            string storedProcedure = "Oficio_Delete";
            return result;
        }

        public List<OficioDto> GetAll()
        {
            string commandText = @"SELECT guid, id, trabajo FROM oficio";
            List<OficioDto> oficios = new List<OficioDto>();
            return oficios;
        }

        public OficioDto GetById(int id)
        {
            string commandText = @"SELECT guid, id, trabajo FROM oficio WHERE id = @pID";
            OficioDto oficio = new OficioDto();
            return oficio;
        }

        public int Update(OficioDto entity)
        {
            int result = 0;
            string storedProcedure = "Oficio_Update";
            return result;
        }
    }
}
