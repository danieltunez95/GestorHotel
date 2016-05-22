using Gh.Common;
using Gh.Dao;
using System.Collections.Generic;

namespace Gh.Bus
{
    public class TipoHabitacionBus : IBus<TipoHabitacionDto>
    {
        TipoHabitacionDao dao = null;

        public TipoHabitacionBus()
        {
            dao = new TipoHabitacionDao();
        }

        public TipoHabitacionDto Add(TipoHabitacionDto tipoHabitacion)
        {
            return dao.Add(tipoHabitacion);
        }

        public int Delete(TipoHabitacionDto tipoHabitacion)
        {
            return dao.Delete(tipoHabitacion);
        }

        public List<TipoHabitacionDto> GetAll()
        {
            return dao.GetAll();
        }

        public TipoHabitacionDto GetById(int id)
        {
            return dao.GetById(id);
        }

        public int Update(TipoHabitacionDto tipoHabitacion)
        {
            return dao.Update(tipoHabitacion);
        }
    }
}
