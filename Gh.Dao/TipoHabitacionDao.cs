using Gh.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Gh.Dao
{
    public class TipoHabitacionDao : BaseDao<TipoHabitacionDto>, IDao<TipoHabitacionDto>
    {
        public TipoHabitacionDto Add(TipoHabitacionDto tipoHabitacion)
        {
            string commandText = "TipoHabitacion_Add";
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
            nombreParameter.DbType = DbType.String;
            nombreParameter.Direction = ParameterDirection.Input;
            nombreParameter.ParameterName = "@Nombre";
            nombreParameter.Value = tipoHabitacion.Nombre;
            parameters.Add(nombreParameter);

            // MetrosCuadrados
            SqlParameter metrosCuadradosParameter = new SqlParameter();
            metrosCuadradosParameter.DbType = DbType.Int32;
            metrosCuadradosParameter.Direction = ParameterDirection.Input;
            metrosCuadradosParameter.ParameterName = "@MetrosCuadrados";
            metrosCuadradosParameter.Value = tipoHabitacion.MetrosCuadrados;
            parameters.Add(metrosCuadradosParameter);

            // Descripcion
            SqlParameter descripcionParameter = new SqlParameter();
            descripcionParameter.DbType = DbType.String;
            descripcionParameter.Direction = ParameterDirection.Input;
            descripcionParameter.ParameterName = "@Descripcion";
            descripcionParameter.Value = tipoHabitacion.Descripcion;
            parameters.Add(descripcionParameter);

            // Imagen
            SqlParameter imagenParameter = new SqlParameter();
            imagenParameter.DbType = DbType.String;
            imagenParameter.Direction = ParameterDirection.Input;
            imagenParameter.ParameterName = "@Imagen";
            imagenParameter.Value = tipoHabitacion.Imagen != null ? tipoHabitacion.Imagen : Convert.DBNull;
            parameters.Add(imagenParameter);

            // Precio
            SqlParameter precioParameter = new SqlParameter();
            precioParameter.DbType = DbType.Decimal;
            precioParameter.Direction = ParameterDirection.Input;
            precioParameter.ParameterName = "@Precio";
            precioParameter.Value = tipoHabitacion.Precio;
            parameters.Add(precioParameter);

            GetData(commandText, parameters, commandType);

            tipoHabitacion.Id = Convert.ToInt32(idParameter.Value);

            return tipoHabitacion;
        }

        public int Delete(TipoHabitacionDto tipoHabitacion)
        {
            string commandText = "TipoHabitacion_Delete";
            CommandType commandType = CommandType.StoredProcedure;

            List<SqlParameter> parameters = new List<SqlParameter>();

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.ParameterName = "@Id";
            idParameter.Value = tipoHabitacion.Id;
            parameters.Add(idParameter);

            // AffectedRows
            SqlParameter affectedRowsParameter = new SqlParameter();
            affectedRowsParameter.DbType = DbType.Int32;
            affectedRowsParameter.Direction = ParameterDirection.Output;
            affectedRowsParameter.ParameterName = "@AffectedRows";
            parameters.Add(affectedRowsParameter);

            GetData(commandText, parameters, commandType);

            return Convert.ToInt32(affectedRowsParameter.Value);
        }

        public List<TipoHabitacionDto> GetAll()
        {
            string commandText = @"SELECT
Id,
Nombre,
MetrosCuadrados,
Descripcion,
Imagen,
Precio
FROM TipoHabitacion";

            List<TipoHabitacionDto> tiposDeHabitacion = GetData(commandText, null);

            return tiposDeHabitacion;
        }

        public TipoHabitacionDto GetById(int id)
        {
            string commandText = @"SELECT
Id,
Nombre,
MetrosCuadrados,
Descripcion,
Imagen,
Precio
FROM TipoHabitacion
WHERE Id = @Id";
            List<SqlParameter> parameters = new List<SqlParameter>();

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.ParameterName = "@Id";
            idParameter.Value = id;
            parameters.Add(idParameter);

            List<TipoHabitacionDto> tiposDeHabitacion = GetData(commandText, parameters);
            TipoHabitacionDto tipoHabitacion = null;

            if (tiposDeHabitacion.Count == 1)
                tipoHabitacion = tiposDeHabitacion[0];

            return tipoHabitacion;
        }

        public int Update(TipoHabitacionDto tipoHabitacion)
        {
            string commandText = "TipoHabitacion_Update";
            CommandType commandType = CommandType.StoredProcedure;

            List<SqlParameter> parameters = new List<SqlParameter>();

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.ParameterName = "@Id";
            idParameter.Value = tipoHabitacion.Id;
            parameters.Add(idParameter);

            // Nombre
            SqlParameter nombreParameter = new SqlParameter();
            nombreParameter.DbType = DbType.String;
            nombreParameter.Direction = ParameterDirection.Input;
            nombreParameter.ParameterName = "@Nombre";
            nombreParameter.Value = tipoHabitacion.Nombre;
            parameters.Add(nombreParameter);

            // MetrosCuadrados
            SqlParameter metrosCuadradosParameter = new SqlParameter();
            metrosCuadradosParameter.DbType = DbType.Int32;
            metrosCuadradosParameter.Direction = ParameterDirection.Input;
            metrosCuadradosParameter.ParameterName = "@MetrosCuadrados";
            metrosCuadradosParameter.Value = tipoHabitacion.MetrosCuadrados;
            parameters.Add(metrosCuadradosParameter);

            // Descripcion
            SqlParameter descripcionParameter = new SqlParameter();
            descripcionParameter.DbType = DbType.String;
            descripcionParameter.Direction = ParameterDirection.Input;
            descripcionParameter.ParameterName = "@Descripcion";
            descripcionParameter.Value = tipoHabitacion.Descripcion;
            parameters.Add(descripcionParameter);

            // Imagen
            SqlParameter imagenParameter = new SqlParameter();
            imagenParameter.DbType = DbType.String;
            imagenParameter.Direction = ParameterDirection.Input;
            imagenParameter.ParameterName = "@Imagen";
            imagenParameter.Value = tipoHabitacion.Imagen != null ? tipoHabitacion.Imagen : Convert.DBNull;
            parameters.Add(imagenParameter);

            // Precio
            SqlParameter precioParameter = new SqlParameter();
            precioParameter.DbType = DbType.Decimal;
            precioParameter.Direction = ParameterDirection.Input;
            precioParameter.ParameterName = "@Precio";
            precioParameter.Value = tipoHabitacion.Precio;
            parameters.Add(precioParameter);

            // AffectedRows
            SqlParameter affectedRowsParameter = new SqlParameter();
            affectedRowsParameter.DbType = DbType.Int32;
            affectedRowsParameter.Direction = ParameterDirection.Output;
            affectedRowsParameter.ParameterName = "@AffectedRows";
            parameters.Add(affectedRowsParameter);

            GetData(commandText, parameters, commandType);

            return Convert.ToInt32(affectedRowsParameter.Value);
        }

        protected override TipoHabitacionDto MapDataReader(SqlDataReader dr)
        {
            TipoHabitacionDto tipoHabitacion = new TipoHabitacionDto()
            {
                Id = Convert.ToInt32(dr["Id"]),
                Nombre = dr["Nombre"] != null ? (string)dr["Nombre"] : null,
                MetrosCuadrados = dr["MetrosCuadrados"] != null ? (int?)dr["MetrosCuadrados"] : null,
                Descripcion = dr["Descripcion"] != null ? (string)dr["Descripcion"] : null,
                Precio = dr["Precio"] != null ? (decimal?)dr["Precio"] : null
            };
            if (tipoHabitacion.Imagen != null)
                tipoHabitacion.Imagen = (string)dr["Imagen"];

            return tipoHabitacion;
        }
    }
}
