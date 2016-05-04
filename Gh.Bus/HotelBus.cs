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

        public HotelDto Add(HotelDto adding)
        {
            return dao.Add(adding);
        }

        public int Delete(HotelDto deleting)
        {
            return dao.Delete(deleting);
        }

        public List<HotelDto> GetAll()
        {
            return dao.GetAll();
        }

        public HotelDto GetById(int id)
        {
            return dao.GetById(id);
        }

        public int Update(HotelDto updating)
        {
            return dao.Update(updating);
        }
    }
}
