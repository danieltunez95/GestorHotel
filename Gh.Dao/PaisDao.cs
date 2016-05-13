using Gh.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Gh.Dao
{
    public class PaisDao : BaseDao<PaisDto>, IDaoReadOnly<PaisDto>
    {
        public List<PaisDto> GetAll()
        {
            string commandText = @"SELECT
Id,
Abreviacion,
Nombre
FROM Pais";

            List<PaisDto> paises = GetData(commandText, null);

            return paises;
        }

        public PaisDto GetById(int id)
        {
            string commandText = @"SELECT
Id,
Abreviacion,
Nombre
FROM Pais
WHERE Id = @Id";
            List<SqlParameter> parameters = new List<SqlParameter>();

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.ParameterName = "@Id";
            idParameter.Value = id;
            parameters.Add(idParameter);

            List<PaisDto> paises = GetData(commandText, parameters);
            PaisDto pais = null;

            if (paises.Count == 1)
                pais = paises[0];

            return pais;
        }

        protected override PaisDto MapDataReader(SqlDataReader dr)
        {
            PaisDto pais = new PaisDto()
            {
                Id = Convert.ToInt32(dr["Id"]),
                Abreviacion = dr["Abreviacion"] != null ? dr["Abreviacion"].ToString() : null,
                Nombre = dr["Nombre"] != null ? dr["Nombre"].ToString() : null
            };
            return pais;
        }
    }
}
