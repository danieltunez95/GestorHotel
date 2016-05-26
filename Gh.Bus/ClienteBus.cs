using Gh.Common;
using Gh.Dao;
using System.Collections.Generic;

namespace Gh.Bus
{
    public class ClienteBus : IBus<ClienteDto>
    {
        ClienteDao dao = null;

        public ClienteBus()
        {
            dao = new ClienteDao();
        }

        public ClienteDto Add(ClienteDto cliente)
        {
            return dao.Add(cliente);
        }

        public int Delete(ClienteDto cliente)
        {
            return dao.Delete(cliente);
        }

        public List<ClienteDto> GetAll()
        {
            return dao.GetAll();
        }

        public List<ClienteDto> GetAll(HotelDto hotel)
        {
            return dao.GetAll(hotel);
        }

        public ClienteDto GetById(int id)
        {
            return dao.GetById(id);
        }

        public int Update(ClienteDto cliente)
        {
            return dao.Update(cliente);
        }
    }
}
