using Gh.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Gh.Dao
{
    public class PoblacionDao : BaseDao<PoblacionDto>, IDao<PoblacionDto>
    {
        public PoblacionDto Add(PoblacionDto poblacion)
        {
            string commandText = "Poblacion_Add";
            CommandType commandType = CommandType.StoredProcedure;
            List<SqlParameter> parameters = new List<SqlParameter>();

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Output;
            idParameter.ParameterName = "@Id";
            parameters.Add(idParameter);

            // Nombre
            SqlParameter nombreParameter = new SqlParameter();
            nombreParameter.DbType = DbType.Int32;
            nombreParameter.Direction = ParameterDirection.Output;
            nombreParameter.ParameterName = "@Nombre";
            nombreParameter.Value = poblacion.Nombre;
            parameters.Add(nombreParameter);

            GetData(commandText, parameters, commandType);

            poblacion.Id = Convert.ToInt32(idParameter.Value);

            return poblacion;
        }

        public int Delete(PoblacionDto poblacion)
        {
            throw new NotImplementedException();
        }

        public List<PoblacionDto> GetAll()
        {
            string commandText = @"SELECT
Id,
Nombre
FROM Poblacion";

            List<PoblacionDto> poblaciones = GetData(commandText, null);
            return poblaciones;
        }

        public PoblacionDto GetById(int id)
        {
            string commandText = @"SELECT
Id,
Nombre
FROM Poblacion
WHERE Id = @Id";
            List<SqlParameter> parameters = new List<SqlParameter>();

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.ParameterName = "@Id";
            idParameter.Value = id;
            parameters.Add(idParameter);

            List<PoblacionDto> poblaciones = GetData(commandText, parameters);
            PoblacionDto poblacion = null;

            if (poblaciones.Count == 1)
                poblacion = poblaciones[0];

            return poblacion;
        }

        public int Update(PoblacionDto poblacion)
        {
            throw new NotImplementedException();
        }

        protected override PoblacionDto MapDataReader(SqlDataReader dr)
        {
            PoblacionDto poblacion = new PoblacionDto()
            {
                Id = Convert.ToInt32(dr["Id"]),
                Nombre = dr["Nombre"] != null ? dr["Nombre"].ToString() : null
            };
            return poblacion;
        }
    }
}
