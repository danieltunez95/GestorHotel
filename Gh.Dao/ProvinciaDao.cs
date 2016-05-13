using Gh.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Gh.Dao
{
    public class ProvinciaDao : BaseDao<ProvinciaDto>, IDaoReadOnly<ProvinciaDto>
    {
        public List<ProvinciaDto> GetAll()
        {
            string commandText = @"SELECT
Id,
IdPais,
Nombre
FROM Provincia";

            List<ProvinciaDto> provincias = GetData(commandText, null);

            return provincias;
        }

        public ProvinciaDto GetById(int id)
        {
            string commandText = @"SELECT
Id,
IdPais,
Nombre
FROM Provincia
WHERE Id = @Id";
            List<SqlParameter> parameters = new List<SqlParameter>();

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.ParameterName = "@Id";
            idParameter.Value = id;
            parameters.Add(idParameter);

            List<ProvinciaDto> provincias = GetData(commandText, parameters);
            ProvinciaDto provincia = null;

            if (provincias.Count == 1)
                provincia = provincias[0];

            return provincia;
        }

        protected override ProvinciaDto MapDataReader(SqlDataReader dr)
        {
            ProvinciaDto provincia = new ProvinciaDto()
            {
                Id = Convert.ToInt32(dr["Id"]),
                Pais = new PaisDto()
                {
                    Id = Convert.ToInt32(dr["IdPais"])
                },
                Nombre = dr["Nombre"] != null ? dr["Nombre"].ToString() : null
            };

            return provincia;
        }
    }
}
