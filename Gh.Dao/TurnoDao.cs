using Gh.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gh.Dao
{
    public class TurnoDao : BaseDao, IDao<TurnoDto>
    {
        string connectionString;
        public TurnoDao(string ConnectionString)
        {
            this.connectionString = ConnectionString;
        }

        public TurnoDao()
        {
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

                    //TODO: Reparar error en consulta
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

        public List<TurnoDto> GetAll()
        {
            string text = @"SELECT Id, Nombre, TurnoPrimeroInicio, TurnoPrimeroFinal, TurnoSegundoInicio,
                            TurnoSegundoFinal, Jornada FROM Turno";
            List<TurnoDto> turnos = new List<TurnoDto>();
            return turnos;
        }

        public TurnoDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public TurnoDto Add(TurnoDto turno)
        {
            string storedProcedure = "Turno_Insert";
            string commandType = "StoredProcedure";
            List<SqlParameter> parameters = new List<SqlParameter>();
                    
            // ID
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Output;
            idParameter.ParameterName = "@Id";
            parameters.Add(idParameter);
                    
            // Nombre
            SqlParameter nombreParameter = new SqlParameter();
            nombreParameter.DbType = DbType.String;
            nombreParameter.Direction = ParameterDirection.Input;
            nombreParameter.Value = turno.Nombre ?? Convert.DBNull;
            nombreParameter.ParameterName = "@Nombre";
            parameters.Add(nombreParameter);

            // TurnoPrimeroInicio
            SqlParameter turnoPrimeroInicioParameter = new SqlParameter();
            turnoPrimeroInicioParameter.DbType = DbType.String;
            turnoPrimeroInicioParameter.Direction = ParameterDirection.Input;
            turnoPrimeroInicioParameter.Value = turno.TurnoPrimeroInicio ?? Convert.DBNull;
            turnoPrimeroInicioParameter.ParameterName = "@TurnoPrimeroInicio";
            parameters.Add(turnoPrimeroInicioParameter);

            // TurnoPrimeroFinal
            SqlParameter turnoPrimeroFinalParameter = new SqlParameter();
            turnoPrimeroFinalParameter.DbType = DbType.String;
            turnoPrimeroFinalParameter.Direction = ParameterDirection.Input;
            turnoPrimeroFinalParameter.Value = turno.TurnoPrimeroFinal ?? Convert.DBNull;
            turnoPrimeroFinalParameter.ParameterName = "@TurnoPrimeroFinal";
            parameters.Add(turnoPrimeroFinalParameter);

            // TurnoSegundoInicio
            SqlParameter turnoSegundoInicioParameter = new SqlParameter();
            turnoSegundoInicioParameter.DbType = DbType.String;
            turnoSegundoInicioParameter.Direction = ParameterDirection.Input;
            turnoSegundoInicioParameter.Value = turno.TurnoSegundoInicio ?? Convert.DBNull;
            turnoSegundoInicioParameter.ParameterName = "@TurnoSegundoInicio";
            parameters.Add(turnoSegundoInicioParameter);

            // TurnoSegundoFinal
            SqlParameter turnoSegundoFinalParameter = new SqlParameter();
            turnoSegundoFinalParameter.DbType = DbType.String;
            turnoSegundoFinalParameter.Direction = ParameterDirection.Input;
            turnoSegundoFinalParameter.Value = turno.TurnoSegundoFinal ?? Convert.DBNull;
            turnoSegundoFinalParameter.ParameterName = "@TurnoSegundoFinal";
            parameters.Add(turnoSegundoFinalParameter);

            // Jornada
            SqlParameter jornadaParameter = new SqlParameter();
            jornadaParameter.DbType = DbType.Int32;
            jornadaParameter.Direction = ParameterDirection.Input;
            jornadaParameter.Value = turno.Jornada;
            jornadaParameter.ParameterName = "@Jornada";
            parameters.Add(jornadaParameter);

            GetData(storedProcedure, commandType, parameters);

            turno.Id = Convert.ToInt32(idParameter.Value);
            return turno;
        }

        public int Update(TurnoDto turno)
        {
            string storedProcedure = "Turno_Update";
            string commandType = "StoredProcedure";

            List<SqlParameter> parameters = new List<SqlParameter>();

            // ID
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.Value = turno.Id;
            idParameter.ParameterName = "@Id";
            parameters.Add(idParameter);

            // Nombre
            SqlParameter nombreParameter = new SqlParameter();
            nombreParameter.DbType = DbType.String;
            nombreParameter.Direction = ParameterDirection.Input;
            nombreParameter.Value = turno.Nombre ?? Convert.DBNull;
            nombreParameter.ParameterName = "@Nombre";
            parameters.Add(nombreParameter);

            // TurnoPrimeroInicio
            SqlParameter turnoPrimeroInicioParameter = new SqlParameter();
            turnoPrimeroInicioParameter.DbType = DbType.String;
            turnoPrimeroInicioParameter.Direction = ParameterDirection.Input;
            turnoPrimeroInicioParameter.Value = turno.TurnoPrimeroInicio ?? Convert.DBNull;
            turnoPrimeroInicioParameter.ParameterName = "@TurnoPrimeroInicio";
            parameters.Add(turnoPrimeroInicioParameter);

            // TurnoPrimeroFinal
            SqlParameter turnoPrimeroFinalParameter = new SqlParameter();
            turnoPrimeroFinalParameter.DbType = DbType.String;
            turnoPrimeroFinalParameter.Direction = ParameterDirection.Input;
            turnoPrimeroFinalParameter.Value = turno.TurnoPrimeroFinal ?? Convert.DBNull;
            turnoPrimeroFinalParameter.ParameterName = "@TurnoPrimeroFinal";
            parameters.Add(turnoPrimeroFinalParameter);

            // TurnoSegundoInicio
            SqlParameter turnoSegundoInicioParameter = new SqlParameter();
            turnoSegundoInicioParameter.DbType = DbType.String;
            turnoSegundoInicioParameter.Direction = ParameterDirection.Input;
            turnoSegundoInicioParameter.Value = turno.TurnoSegundoInicio ?? Convert.DBNull;
            turnoSegundoInicioParameter.ParameterName = "@TurnoSegundoInicio";
            parameters.Add(turnoSegundoInicioParameter);

            // TurnoSegundoFinal
            SqlParameter turnoSegundoFinalParameter = new SqlParameter();
            turnoSegundoFinalParameter.DbType = DbType.String;
            turnoSegundoFinalParameter.Direction = ParameterDirection.Input;
            turnoSegundoFinalParameter.Value = turno.TurnoSegundoFinal ?? Convert.DBNull;
            turnoSegundoFinalParameter.ParameterName = "@TurnoSegundoFinal";
            parameters.Add(turnoSegundoFinalParameter);

            // Jornada
            SqlParameter jornadaParameter = new SqlParameter();
            jornadaParameter.DbType = DbType.Int32;
            jornadaParameter.Direction = ParameterDirection.Input;
            jornadaParameter.Value = turno.Jornada;
            jornadaParameter.ParameterName = "@Jornada";
            parameters.Add(jornadaParameter);

            // AffectedRows
            SqlParameter affectedRowsParameter = new SqlParameter();
            affectedRowsParameter.DbType = DbType.Int32;
            affectedRowsParameter.Direction = ParameterDirection.Output;
            affectedRowsParameter.Value = 0;
            affectedRowsParameter.ParameterName = "@AffectedRows";
            parameters.Add(affectedRowsParameter);

            GetData(storedProcedure, commandType, parameters);

            return Convert.ToInt32(affectedRowsParameter.Value);
        }

        public int Delete(TurnoDto turno)
        {
            string storedProcedure = "Turno_Delete";
            string commandType = "StoredProcedure";

            List<SqlParameter> parameters = new List<SqlParameter>();

            // ID
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.Value = turno.Id;
            idParameter.ParameterName = "@Id";
            parameters.Add(idParameter);

            // AffectedRows
            SqlParameter affectedRowsParameter = new SqlParameter();
            affectedRowsParameter.DbType = DbType.Int32;
            affectedRowsParameter.Direction = ParameterDirection.Output;
            affectedRowsParameter.Value = 0;
            affectedRowsParameter.ParameterName = "@AffectedRows";
            parameters.Add(affectedRowsParameter);

            GetData(storedProcedure, commandType, parameters);

            return Convert.ToInt32(affectedRowsParameter.Value);
        }
    }
}
