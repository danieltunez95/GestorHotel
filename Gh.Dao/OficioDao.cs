using Gh.Common;
using System.Collections.Generic;

namespace Gh.Dao
{
    public class OficioDao : IDao<Oficio>
    {
        public Oficio Add(Oficio entity)
        {
            string storedProcedure = "Oficio_Add";
            return entity;
        }

        public int Delete(Oficio entity)
        {
            int result = 0;
            string storedProcedure = "Oficio_Delete";
            return result;
        }

        public List<Oficio> GetAll()
        {
            string commandText = @"SELECT guid, id, trabajo FROM oficio";
            List<Oficio> oficios = new List<Oficio>();
            return oficios;
        }

        public Oficio GetById(int id)
        {
            string commandText = @"SELECT guid, id, trabajo FROM oficio WHERE id = @pID";
            Oficio oficio = new Oficio();
            return oficio;
        }

        public int Update(Oficio entity)
        {
            int result = 0;
            string storedProcedure = "Oficio_Update";
            return result;
        }
    }
}
