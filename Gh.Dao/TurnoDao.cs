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
    public class TurnoDao : BaseDao<TurnoDto>, IDao<TurnoDto>
    {
        public List<TurnoDto> GetAll()
        {
            string commandText = @"SELECT Id,
Nombre,
TurnoPrimeroInicio,
TurnoPrimeroFinal,
TurnoSegundoInicio,
TurnoSegundoFinal,
Jornada
FROM Turno";
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<TurnoDto> turnos = GetData(commandText, parameters);
            return turnos;
        }

        public TurnoDto GetById(int id)
        {
            string commandText = @"SELECT Id,
Nombre,
TurnoPrimeroInicio,
TurnoPrimeroFinal,
TurnoSegundoInicio,
TurnoSegundoFinal,
Jornada
FROM Turno
WHERE Id = @Id";
            List<SqlParameter> parameters = new List<SqlParameter>();
            // ID
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.Value = id;
            idParameter.ParameterName = "@Id";
            parameters.Add(idParameter);

            List<TurnoDto> turnos = GetData(commandText, parameters);
            TurnoDto turno = null;
            if(turnos.Count == 1)
            {
                turno = turnos[0];
            }
            return turno;
        }

        public TurnoDto Add(TurnoDto turno)
        {
            string storedProcedure = "Turno_Insert";
            CommandType commandType = CommandType.StoredProcedure;
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

            GetData(storedProcedure, parameters, commandType);

            turno.Id = Convert.ToInt32(idParameter.Value);
            return turno;
        }

        public int Update(TurnoDto turno)
        {
            string storedProcedure = "Turno_Update";
            CommandType commandType = CommandType.StoredProcedure;

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

            GetData(storedProcedure, parameters, commandType);

            return Convert.ToInt32(affectedRowsParameter.Value);
        }

        public int Delete(TurnoDto turno)
        {
            string storedProcedure = "Turno_Delete";
            CommandType commandType = CommandType.StoredProcedure;

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

            GetData(storedProcedure, parameters, commandType);

            return Convert.ToInt32(affectedRowsParameter.Value);
        }

        protected override TurnoDto MapDataReader(SqlDataReader dr)
        {
            TurnoDto turno = new TurnoDto()
            {
                Id = Convert.ToInt32(dr["Id"]),
                Nombre = dr["Nombre"] != null ? dr["Nombre"].ToString() : null,
                TurnoPrimeroInicio = dr["TurnoPrimeroInicio"] != null ? dr["TurnoPrimeroInicio"].ToString() : null,
                TurnoPrimeroFinal = dr["TurnoPrimeroFinal"] != null ? dr["TurnoPrimeroFinal"].ToString() : null,
                TurnoSegundoInicio = dr["TurnoSegundoInicio"] != null ? dr["TurnoSegundoInicio"].ToString() : null,
                TurnoSegundoFinal = dr["TurnoSegundoFinal"] != null ? dr["TurnoSegundoFinal"].ToString() : null,
                Jornada = Convert.ToInt32(dr["Jornada"])
            };
            return turno;
        }
    }
}
