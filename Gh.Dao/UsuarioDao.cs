using Gh.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gh.Dao
{
    public class UsuarioDao
    {
        string connectionString;
        public UsuarioDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddUser(UsuarioDto user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    StringBuilder query = new StringBuilder();
                    query.Append("INSERT INTO user");
                    query.Append("(username, password, role, minHour, maxHour) ");
                    query.Append("VALUES(@username, @password, @role, @minHour, @maxHour)");

                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = query.ToString();
                    command.Parameters.Add(new SqlParameter("@username", user.Username));
                    command.Parameters.Add(new SqlParameter("@password", user.Password));
                    command.Parameters.Add(new SqlParameter("@role", user.Role));
                    command.Parameters.Add(new SqlParameter("@minHour", user.MinHour));
                    command.Parameters.Add(new SqlParameter("@MaxHour", user.MaxHour));

                    connection.Open();
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
