using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gh.Bus
{
    public class BaseBus
    {
        public string GetConnectionString()
        {
            return "Server=tcp:gestorhotel.database.windows.net,1433;Database=GestorHotel;User ID=hoteladmin@gestorhotel;Password=Abcd1234;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }
       
    }
}
