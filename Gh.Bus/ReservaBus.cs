using Gh.Common;
using Gh.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gh.Bus
{
    public class ReservaBus : IBus<ReservaDto>
    {
        ReservaDao dao = null;

        public ReservaBus()
        {
            dao = new ReservaDao();
        }

        public ReservaDto Add(ReservaDto reserva)
        {
            return dao.Add(reserva);
        }

        public ReservaDto AddFromPos(ReservaDto reserva)
        {
            HabitacionBus habitacionBus = new HabitacionBus();
            HabitacionDto habitacion = habitacionBus.GetByIdPos(reserva.IdPosHabitacion);
            reserva.IdHabitacion = habitacion.Id;
            return dao.AddFromPos(reserva);
        }

        public int Delete(ReservaDto reserva)
        {
            return dao.Delete(reserva);
        }

        public List<ReservaDto> GetAll()
        {
            return dao.GetAll();
        }

        public ReservaDto GetById(int id)
        {
            return dao.GetById(id);
        }

        public int Update(ReservaDto reserva)
        {
            return dao.Update(reserva);
        }
    }
}
