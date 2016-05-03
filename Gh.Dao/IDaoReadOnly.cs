using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gh.Dao
{
    interface IDaoReadOnly<T>
    {
        List<T> GetAll();
        T GetById(int id);
    }
}
