using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gh.Common
{
    public class PaisDto : BaseDto
    {
        public PaisDto(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
    }
}
