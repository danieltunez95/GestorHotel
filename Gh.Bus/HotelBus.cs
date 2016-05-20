using System.Collections.Generic;
using Gh.Common;
using Gh.Dao;
using System.Linq;

namespace Gh.Bus
{
    public class HotelBus : IBus<HotelDto>
    {
        HotelDao dao = null;
        HabitacionDao habitacionDao = null;

        public HotelBus()
        {
            dao = new HotelDao();
            habitacionDao = new HabitacionDao();
        }

        public HotelDto Add(HotelDto hotel)
        {
            return dao.Add(hotel);
        }

        public int Delete(HotelDto hotel)
        {
            return dao.Delete(hotel);
        }

        /// <summary>
        /// Devuelve una lista de todos los hoteles sin habitaciones.
        /// </summary>
        /// <returns>Hoteles sin habitaciones</returns>
        public List<HotelDto> GetAll()
        {
            return dao.GetAll();
        }

        /// <summary>
        /// Devuelve el hotel seleccionado por ID y sus habitaciones.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Hotel seleccionado por ID y sus habitaciones.</returns>
        public HotelDto GetById(int id)
        {
            HotelDto hotel = dao.GetById(id);
            hotel.Habitaciones = habitacionDao.GetAllByIdHotel(hotel);
            hotel.Ancho = hotel.Habitaciones.OrderBy(x => x.PosicionY).ToList()[hotel.Habitaciones.Count].PosicionY;
            hotel.Largo = hotel.Habitaciones.OrderBy(x => x.PosicionX).ToList()[hotel.Habitaciones.Count].PosicionX;
            return hotel;
        }

        public int Update(HotelDto hotel)
        {
            return dao.Update(hotel);
        }

        public HotelDto GenerarPlantaFromString(HotelDto hotel, string planta, int plantaActual)
        {
            string[] habitaciones = planta.Split('/');
            if (hotel.Habitaciones == null)
                hotel.Habitaciones = new List<HabitacionDto>();

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
                            MetrosCuadrados = 0,
                            Camas = 0,
                            TipoCama = CamaEnum.Matrimonio,
                            Precio = 0d,
                            Dormitorios = 0,
                            Descripcion = "PENDIENTE DE EDICIÓN",
                            Planta = 0,
                            Imagen = ""
                        });
                    }
                }
            }

            return hotel;
        }

        public bool HasAnyHotel()
        {
            return dao.HasAnyHotel();
        }

        public int GetReservasByIdHotel(HotelDto hotel)
        {
            return dao.GetReservasByIdHotel(hotel);
        }

        public int GetEntradasByIdHotel(HotelDto hotel)
        {
            return dao.GetEntradasByIdHotel(hotel);
        }

        public int GetSalidasByIdHotel(HotelDto hotel)
        {
            return dao.GetSalidasByIdHotel(hotel);
        }
    }
}
