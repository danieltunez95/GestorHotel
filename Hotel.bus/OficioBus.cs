using GestorHotel.Bus.Interficies;
using GestorHotel.Common;
using GestorHotel.Dao;
using System.Collections.Generic;

namespace GestorHotel.Bus
{
    public class OficioBus : IBus<Oficio>
    {
        OficioDao dao = null;

        public OficioBus()
        {
            dao = new OficioDao();
        }

        public Oficio Add(Oficio adding)
        {
            return dao.Add(adding);
        }

        public int Delete(Oficio deleting)
        {
            return dao.Delete(deleting);
        }

        public List<Oficio> GetAll()
        {
            return dao.GetAll();
        }

        public Oficio GetById(int id)
        {
            return dao.GetById(id);
        }

        public int Update(Oficio updating)
        {
            return dao.Update(updating);
        }
    }
}
