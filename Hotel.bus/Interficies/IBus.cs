using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorHotel.Bus.Interficies
{
    interface IBus<T>
    {
        List<T> GetAll();
        T GetById(int id);
        T Add(T adding);
        int Update(T updating);
        int Delete(T deleting);
    }
}
