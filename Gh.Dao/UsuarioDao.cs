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
                    query.Append("INSERT INTO ");
                    query.Append(UsuarioDto.DBName);
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

        public List<UsuarioDto> GetUsers()
        {
            List<UsuarioDto> users = new List<UsuarioDto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    StringBuilder query = new StringBuilder();
                    query.Append("SELECT * ");
                    query.Append("FROM ");
                    query.Append(UsuarioDto.DBName);

                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = query.ToString();
                    command.Connection = connection;

                    SqlDataReader reader = null;
                    connection.Open();
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        UsuarioDto user = new UsuarioDto();
                        user.Id = int.Parse(reader["Id"].ToString());
                        user.Username = reader["Username"].ToString();
                        user.Role = (Role)Enum.Parse(typeof(Role), reader["Role"].ToString());
                        user.MinHour = float.Parse(reader["MinHour"].ToString());
                        user.MaxHour = float.Parse(reader["MaxHour"].ToString());

                        users.Add(user);
                    }
                }
            }

                return users;
        }
    }
}
