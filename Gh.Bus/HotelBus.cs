using System.Collections.Generic;
using Gh.Common;
using Gh.Dao;

namespace Gh.Bus
{
    public class HotelBus : IBus<HotelDto>
    {
        HotelDao dao = null;

        public HotelBus()
        {
            dao = new HotelDao();
        }

        public HotelDto Add(HotelDto hotel)
        {
            return dao.Add(hotel);
        }

        public int Delete(HotelDto hotel)
        {
            return dao.Delete(hotel);
        }

        public List<HotelDto> GetAll()
        {
            return dao.GetAll();
        }

        public HotelDto GetById(int id)
        {
            return dao.GetById(id);
        }

        public int Update(HotelDto hotel)
        {
            return dao.Update(hotel);
        }

        public HotelDto GenerarPlantaFromString(HotelDto hotel, string planta, int plantaActual)
        {
            string hotelString = "1,0,1,1/0,0,1,0/1,1,0,1";
            string[] habitaciones = hotelString.Split('/');
            for (int i = 0; i < habitaciones.Length; i++)
            {
                string[] habitacion = habitaciones[i].Split(',');
                for (int j = 0; j < habitacion.Length; j++)
                {
                    if (habitacion[j].Equals("1"))
                    {
                        hotel.Habitaciones.Add(new HabitacionDto()
                        {
                            PosicionX = i,
                            PosicionY = j,
                            Planta = plantaActual
                        });
                    }
                }
            }

            return hotel;
        }
    }
}
