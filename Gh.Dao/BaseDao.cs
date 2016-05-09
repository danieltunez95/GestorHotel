using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gh.Dao
{
    public class BaseDao
    {
        public void GetData(string commandText, string commandType, List<SqlParameter> parameters)
        {
            using (SqlConnection connection = new SqlConnection("Server=tcp:gestorhotel.database.windows.net,1433;Database=GestorHotel;User ID=hoteladmin@gestorhotel;Password=Abcd1234;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30"))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.CommandText = commandText;
                    command.CommandType = (CommandType)Enum.Parse(typeof(CommandType), commandType);
                    foreach (SqlParameter param in parameters)
                    {
                        command.Parameters.Add(param);
                    }

                    command.Connection = connection;
                    connection.Open();
                    reader = command.ExecuteReader();
                }
            }
        }
        public void GetDataReader(string commandText, string commandType, List<SqlParameter> parameters)
        {
            using (SqlConnection connection = new SqlConnection("Server=tcp:gestorhotel.database.windows.net,1433;Database=GestorHotel;User ID=hoteladmin@gestorhotel;Password=Abcd1234;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30"))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.CommandText = commandText;
                    command.CommandType = (CommandType)Enum.Parse(typeof(CommandType), commandType);
                    foreach (SqlParameter param in parameters)
                    {
                        command.Parameters.Add(param);
                    }

                    command.Connection = connection;
                    connection.Open();
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        // Incoming
                    }
                }
            }
        }
    }
}
