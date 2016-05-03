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

        public Hotel Add(Hotel adding)
        {
            return dao.Add(adding);
        }

        public int Delete(Hotel deleting)
        {
            return dao.Delete(deleting);
        }

        public List<Hotel> GetAll()
        {
            return dao.GetAll();
        }

        public Hotel GetById(int id)
        {
            return dao.GetById(id);
        }

        public int Update(Hotel updating)
        {
            return dao.Update(updating);
        }
    }
}
