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
                usuarioDao.AddUser(user);
            }
            catch (Exception ex)
            {
                correcto = false;
            }

            return correcto;
        }
    }
}
