using System.Configuration;

namespace Gh.Dao
{
    public class AppConfigReader
    {
        public static string GetConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GestorHotelConnection"].ConnectionString;
            return connectionString;
        }
    }
}
