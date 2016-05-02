using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorHotel.Bus.Interficies
{
    interface IBusReadOnly<T>
    {
        List<T> GetAll();
        T GetById(int id);
    }
}
