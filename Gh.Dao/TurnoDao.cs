using Gh.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gh.Dao
{
    public class TurnoDao
    {
        string connectionString;
        public TurnoDao(string ConnectionString)
        {
            this.connectionString = ConnectionString;
        }

        public List<TurnoDto> GetTurnos()
        {
            List<TurnoDto> turnos = new List<TurnoDto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    StringBuilder query = new StringBuilder();
                    query.Append("SELECT * ");
                    query.Append("FROM Turno ");

                    command.CommandText = query.ToString();
                    command.Connection = connection;

                    SqlDataReader reader = null;
                    connection.Open();
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        TurnoDto turno = new TurnoDto();

                        turno.Id = int.Parse(reader["Id"].ToString());
                        turno.Nombre = reader["Nombre"].ToString();
                        turno.TurnoPrimeroInicio = reader["TurnoPrimeroInicio"].ToString();
                        turno.TurnoPrimeroFinal = reader["TurnoPrimeroFinal"].ToString();
                        turno.TurnoSegundoInicio = reader["TurnoSegundoInicio"].ToString();
                        turno.TurnoSegundoFinal = reader["TurnoSegundoFinal"].ToString();
                        turno.Jornada = int.Parse(reader["Jornada"].ToString());

                        turnos.Add(turno);
                    }
                }
            }
            return turnos;
        }

        public void AddTurno(TurnoDto turno)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    StringBuilder query = new StringBuilder();
                    query.Append("INSERT INTO " + TurnoDto.DBName);
                    query.Append("(Nombre, TurnoPrimeroInicio, TurnoPrimeroFinal");
                    query.Append(", TurnoSegundoInicio, TurnoSegundoFinal, Jornada) ");
                    query.Append("VALUES(@nombre, @turnoPrimeroInicio, @turnoPrimeroFinal");
                    query.Append(", @turnoSegundoInicio, @turnoSegundoFinal, @jornada)");

                    command.CommandText = query.ToString();
                    command.Parameters.Add(new SqlParameter("@nombre", turno.Nombre));
                    command.Parameters.Add(new SqlParameter("@turnoPrimeroInicio", turno.TurnoPrimeroInicio));
                    command.Parameters.Add(new SqlParameter("@turnoPrimeroFinal", turno.TurnoPrimeroFinal));
                    command.Parameters.Add(new SqlParameter("@turnoSegundoInicio", turno.TurnoSegundoInicio));
                    command.Parameters.Add(new SqlParameter("@turnoSegundoFinal", turno.TurnoSegundoFinal));
                    command.Parameters.Add(new SqlParameter("@jornada", turno.Jornada));

                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
