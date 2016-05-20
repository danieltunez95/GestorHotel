using Gh.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gh.Bus
{
    public class HabitacionBus : IBus<HabitacionDto>
    {
        public HabitacionDto Add(HabitacionDto entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(HabitacionDto entity)
        {
            throw new NotImplementedException();
        }

        public List<HabitacionDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public HabitacionDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(HabitacionDto entity)
        {
            throw new NotImplementedException();
        }

        public bool Ocupada(int hotelId, int posicionX, int posicionY, DateTime fechaInicio, DateTime fechaFinal)
        {
            bool ocupada = false;

            throw new NotImplementedException();

            return ocupada;
        }
    }
}
