using System.Collections.Generic;

namespace Gh.Bus
{
    interface IBusReadOnly<T>
    {
        List<T> GetAll();
        T GetById(int id);
    }
}
