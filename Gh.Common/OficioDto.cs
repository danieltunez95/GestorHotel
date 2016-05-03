using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gh.Common
{
    public class OficioDto : BaseDto
    {
        private string trabajo;

        public string Trabajo
        {
            get { return trabajo; }
            set { trabajo = value; }
        }
    }
}
