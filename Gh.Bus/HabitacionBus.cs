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

        public HabitacionDto GetByIdPos(string idPos)
        {
            return dao.GetByIdPos(idPos);
        }

        public List<HabitacionDto> GetAllByIdHotelWithOcupada(int idHotel,DateTime fechaInicio, DateTime fechaFinal)
        {
            return dao.GetAllByIdHotelWithOcupada(idHotel, fechaInicio, fechaFinal);
        }

        public int Update(HabitacionDto habitacion)
        {
            return dao.Update(habitacion);
        }

        public bool isBusy(int idHotel, int posicionX, int posicionY, int planta, DateTime fechaInicio, DateTime fechaFinal)
        {
            return dao.isBusy(idHotel, posicionX, posicionY, planta, fechaInicio, fechaFinal);
        }

        public bool existHabitacion(int idHotel, int posicionX, int posicionY, int planta)
        {
            return dao.existHabitacion(idHotel, posicionX, posicionY, planta);
        }
    }
}
