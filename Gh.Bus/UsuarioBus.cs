using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gh.Common;
using Gh.Dao;

namespace Gh.Bus
{
    public class UsuarioBus : BaseBus
    {
        public bool AddUser(UsuarioDto user)
        {
            bool correcto = true;

            try
            {
                UsuarioDao usuarioDao = new UsuarioDao(GetConnectionString());
                //TODO: Check the connectionString returned in the expression above
                //usuarioDao.AddUser(user);
            }
            catch (Exception)
            {
                correcto = false;
            }

            return correcto;
        }
    }
}
