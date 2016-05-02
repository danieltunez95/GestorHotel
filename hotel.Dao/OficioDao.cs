using GestorHotel.Common;
using System.Collections.Generic;

namespace GestorHotel.Dao
{
    public class OficioDao : IDao<Oficio>
    {
        /// <summary>
        /// Añade a la base de datos con un procedimiento SQL.
        /// </summary>
        /// <param name="adding">Objeto Oficio a añadir</param>
        /// <returns>Oficio</returns>
        public Oficio Add(Oficio adding)
        {
            string storedProcedure = "Oficio_Add";
            return adding;
        }

        /// <summary>
        /// Borra de la base de datos con un procedimiento SQL.
        /// </summary>
        /// <param name="deleting">Oficio</param>
        /// <returns>Líneas afectadas (int)</returns>
        public int Delete(Oficio deleting)
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

        public int Update(Oficio updating)
        {
            int result = 0;
            string storedProcedure = "Oficio_Update";
            return result;
        }
    }
}
