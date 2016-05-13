using Gh.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Gh.Dao
{
    public class MunicipioDao : BaseDao<MunicipioDto>, IDao<MunicipioDto>
    {
        public MunicipioDto Add(MunicipioDto municipio)
        {
            string commandText = "Municipio_Add";
            CommandType commandType = CommandType.StoredProcedure;
            List<SqlParameter> parameters = new List<SqlParameter>();

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Output;
            idParameter.ParameterName = "@Id";
            parameters.Add(idParameter);

            // IdProvincia
            SqlParameter provinciaParameter = new SqlParameter();
            provinciaParameter.DbType = DbType.Int32;
            provinciaParameter.Direction = ParameterDirection.Input;
            provinciaParameter.ParameterName = "@IdProvincia";
            provinciaParameter.Value = municipio.Provincia.Id;
            parameters.Add(provinciaParameter);

            // Nombre
            SqlParameter nombreParameter = new SqlParameter();
            nombreParameter.DbType = DbType.Int32;
            nombreParameter.Direction = ParameterDirection.Input;
            nombreParameter.ParameterName = "@Nombre";
            nombreParameter.Value = municipio.Nombre;
            parameters.Add(nombreParameter);

            GetData(commandText, parameters, commandType);

            municipio.Id = Convert.ToInt32(idParameter.Value);

            return municipio;
        }

        public int Delete(MunicipioDto municipio)
        {
            string commandText = "Municipio_Delete";
            CommandType commandType = CommandType.StoredProcedure;
            List<SqlParameter> parameters = new List<SqlParameter>();

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.ParameterName = "@Id";
            idParameter.Value = municipio.Id;
            parameters.Add(idParameter);

            // AffectedRows
            SqlParameter affectedRowsParameter = new SqlParameter();
            affectedRowsParameter.DbType = DbType.Int32;
            affectedRowsParameter.Direction = ParameterDirection.Output;
            affectedRowsParameter.ParameterName = "@AffectedRows";
            affectedRowsParameter.Value = 0;
            parameters.Add(affectedRowsParameter);

            GetData(commandText, parameters, commandType);

            return Convert.ToInt32(affectedRowsParameter.Value);
        }

        public List<MunicipioDto> GetAll()
        {
            string commandText = @"SELECT 
Id,
IdProvincia,
Nombre
FROM Municipio";

            List<MunicipioDto> municipios = GetData(commandText, null);

            return municipios;
        }

        public MunicipioDto GetById(int id)
        {
            string commandText = @"SELECT 
Id,
IdProvincia,
Nombre,
FROM Municipio
WHERE ID = @Id";
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.ParameterName = "@Id";
            idParameter.Value = id;
            parameters.Add(idParameter);

            List<MunicipioDto> municipios = GetData(commandText, parameters);
            MunicipioDto municipio = null;
            if (municipios.Count == 1)
                municipio = municipios[0];
            return municipio;
        }

        public int Update(MunicipioDto municipio)
        {
            string commandText = "Municipio_Update";
            CommandType commandType = CommandType.StoredProcedure;
            List<SqlParameter> parameters = new List<SqlParameter>();

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.ParameterName = "@Id";
            idParameter.Value = municipio.Id;
            parameters.Add(idParameter);

            // IdProvincia
            SqlParameter provinciaParameter = new SqlParameter();
            provinciaParameter.DbType = DbType.Int32;
            provinciaParameter.Direction = ParameterDirection.Input;
            provinciaParameter.ParameterName = "@IdProvincia";
            provinciaParameter.Value = municipio.Provincia.Id;
            parameters.Add(provinciaParameter);

            // Nombre
            SqlParameter nombreParameter = new SqlParameter();
            nombreParameter.DbType = DbType.String;
            nombreParameter.Direction = ParameterDirection.Input;
            nombreParameter.ParameterName = "@Nombre";
            nombreParameter.Value = municipio.Nombre;
            parameters.Add(nombreParameter);

            // AffectedRows
            SqlParameter affectedRowsParameter = new SqlParameter();
            affectedRowsParameter.DbType = DbType.Int32;
            affectedRowsParameter.Direction = ParameterDirection.Output;
            affectedRowsParameter.ParameterName = "@AffectedRows";
            affectedRowsParameter.Value = 0;
            parameters.Add(affectedRowsParameter);

            GetData(commandText, parameters, commandType);

            return Convert.ToInt32(affectedRowsParameter.Value);
        }

        protected override MunicipioDto MapDataReader(SqlDataReader dr)
        {
            MunicipioDto municipio = new MunicipioDto()
            {
                Id = Convert.ToInt32(dr["Id"]),
                Provincia = new ProvinciaDto()
                {
                    Id = Convert.ToInt32(dr["IdProvincia"])
                },
                Nombre = dr["Nombre"] != null ? dr["Nombre"].ToString() : null
            };
            return municipio;
        }
    }
}
