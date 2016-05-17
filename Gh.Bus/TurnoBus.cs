using Gh.Common;
using Gh.Dao;
using System.Collections.Generic;

namespace Gh.Bus
{
    public class TurnoBus : IBus<TurnoDto>
    {
        TurnoDao dao = null;

        public TurnoBus()
        {
            dao = new TurnoDao();
        }

        public TurnoDto Add(TurnoDto turno)
        {
            return dao.Add(turno);
        }

        public int Delete(TurnoDto turno)
        {
            return dao.Delete(turno);
        }

        public List<TurnoDto> GetAll()
        {
            return dao.GetAll();
        }

        public TurnoDto GetById(int id)
        {
            return dao.GetById(id);
        }

        public int Update(TurnoDto turno)
        {
            return dao.Update(turno);
        }
    }
}
