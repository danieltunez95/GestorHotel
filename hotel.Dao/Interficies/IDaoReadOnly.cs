using System.Collections.Generic;

namespace GestorHotel.Dao
{
    interface IDaoReadOnly<T>
    {
        List<T> GetAll();
        T GetById(int id);
    }
}
