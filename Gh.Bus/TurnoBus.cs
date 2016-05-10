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
            TurnoDao turnoDao = new TurnoDao();
            return turnoDao.GetAll();
        }

        public bool AddTurno(TurnoDto turno)
        {
            bool correcto = true;
            try
            {
                TurnoDao turnoDao = new TurnoDao();
                turnoDao.Add(turno);
            }
            catch (Exception ex)
            {
                correcto = false;
            }
            return correcto;
        }
    }
}
