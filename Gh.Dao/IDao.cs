using System.Collections.Generic;

namespace Gh.Dao
{
    interface IDao<T>
    {
        List<T> GetAll();
        T GetById(int id);
        T Add(T entity);
        int Update(T entity);
        int Delete(T entity);
    }
}
