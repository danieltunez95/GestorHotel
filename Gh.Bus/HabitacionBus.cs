using Gh.Common;
using Gh.Dao;
using System;
using System.Collections.Generic;

namespace Gh.Bus
{
    public class HabitacionBus : IBus<HabitacionDto>
    {
        HabitacionDao dao = null;

        public HabitacionBus()
        {
            dao = new HabitacionDao();
        }

        public HabitacionDto Add(HabitacionDto habitacion)
        {
            return dao.Add(habitacion);
        }

        public int Delete(HabitacionDto habitacion)
        {
            return dao.Delete(habitacion);
        }

        public List<HabitacionDto> GetAll()
        {
            return dao.GetAll();
        }

        public List<HabitacionDto> GetAllByIdHotel(HotelDto hotel)
        {
            return dao.GetAllByIdHotel(hotel);
        }

        public HabitacionDto GetById(int id)
        {
            return dao.GetById(id);
        }

        public int Update(HabitacionDto habitacion)
        {
            return dao.Update(habitacion);
        }

        public bool isBusy(int hotelId, int posicionX, int posicionY, int planta, DateTime fechaInicio, DateTime fechaFinal)
        {
            return dao.isBusy(hotelId, posicionX, posicionY, planta, fechaInicio, fechaFinal);
        }
    }
}
