using Gh.Common;
using Gh.Dao;
using System.Collections.Generic;

namespace Gh.Bus
{
    public class PersonaBus : IBus<PersonaDto>
    {
        PersonaDao dao = null;

        public PersonaBus()
        {
            dao = new PersonaDao();
        }

        public PersonaDto Add(PersonaDto persona)
        {
            return dao.Add(persona);
        }

        public int Delete(PersonaDto persona)
        {
            return dao.Delete(persona);
        }

        public List<PersonaDto> GetAll()
        {
            return dao.GetAll();
        }

        public PersonaDto GetById(int id)
        {
            return dao.GetById(id);
        }

        public int Update(PersonaDto persona)
        {
            return dao.Update(persona);
        }
    }
}
