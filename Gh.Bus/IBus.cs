using System.Collections.Generic;

namespace Gh.Bus
{
    interface IBus<T>
    {
        List<T> GetAll();
        T GetById(int id);
        T Add(T entity);
        int Update(T entity);
        int Delete(T entity);
    }
}
