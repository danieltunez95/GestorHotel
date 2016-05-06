using Gh.Common;
using Gh.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gh.Bus
{
    public class TurnoBus : BaseBus
    {
        public List<TurnoDto> GetTurnos()
        {
            TurnoDao turnoDao = new TurnoDao(GetConnectionString());
            return turnoDao.GetTurnos();
        }

        public bool AddTurno(TurnoDto turno)
        {
            bool correcto = true;
            try
            {
                TurnoDao turnoDao = new TurnoDao(GetConnectionString());
                turnoDao.AddTurno(turno);
            }
            catch (Exception)
            {
                correcto = false;
            }
            return correcto;
        }
    }
}
