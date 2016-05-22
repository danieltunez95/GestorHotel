using Gh.Common;
using Gh.Dao;
using System.Collections.Generic;

namespace Gh.Bus
{
    public class UsuarioBus : IBus<UsuarioDto>
    {
        UsuarioDao dao = null;

        public UsuarioBus()
        {
            dao = new UsuarioDao();
        }

        public List<UsuarioDto> GetAll()
        {
            return dao.GetAll();
        }

        public UsuarioDto GetById(int id)
        {
            return dao.GetById(id);
        }
        
        public UsuarioDto GetByUsername(string username)
        {
            return dao.GetByUsername(username);
        }

        public UsuarioDto Add(UsuarioDto usuario)
        {
            return dao.Add(usuario);
        }

        public int Update(UsuarioDto usuario)
        {
            return dao.Update(usuario);
        }

        public int Delete(UsuarioDto usuario)
        {
            return dao.Delete(usuario);
        }

        public UsuarioDto Login(string username, string password)
        {
            return dao.Login(username, password);
        }
    }
}
