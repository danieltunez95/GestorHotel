using Gh.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Gh.Dao
{
    public class HotelDao : BaseDao<HotelDto>, IDao<HotelDto>
    {
        public HotelDto Add(HotelDto hotel)
        {
            string commandText = "Hotel_Add";
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
            nombreParameter.Value = hotel.Nombre ?? Convert.DBNull;
            nombreParameter.ParameterName = "@Nombre";
            parameters.Add(nombreParameter);

            // Poblacion
            SqlParameter poblacionParameter = new SqlParameter();
            poblacionParameter.DbType = DbType.Int32;
            poblacionParameter.Direction = ParameterDirection.Input;
            poblacionParameter.Value = hotel.Poblacion.Id != -1 ? hotel.Poblacion.Id : Convert.DBNull;
            poblacionParameter.ParameterName = "@IdPoblacion";
            parameters.Add(poblacionParameter);

            // Municipio
            SqlParameter municipioParameter = new SqlParameter();
            municipioParameter.DbType = DbType.Int32;
            municipioParameter.Direction = ParameterDirection.Input;
            municipioParameter.Value = hotel.Municipio.Id != -1 ? hotel.Municipio.Id : Convert.DBNull;
            municipioParameter.ParameterName = "@IdMunicipio";
            parameters.Add(municipioParameter);

            // Direccion
            SqlParameter direccionParameter = new SqlParameter();
            direccionParameter.DbType = DbType.String;
            direccionParameter.Direction = ParameterDirection.Input;
            direccionParameter.Value = hotel.Direccion ?? Convert.DBNull;
            direccionParameter.ParameterName = "@Direccion";
            parameters.Add(direccionParameter);

            // Plantas
            SqlParameter plantasParameter = new SqlParameter();
            plantasParameter.DbType = DbType.Int32;
            plantasParameter.Direction = ParameterDirection.Input;
            plantasParameter.Value = hotel.Plantas > 0 ? hotel.Plantas : 0;
            plantasParameter.ParameterName = "@Plantas";
            parameters.Add(plantasParameter);

            // Estrellas
            SqlParameter estrellasParameter = new SqlParameter();
            estrellasParameter.DbType = DbType.Int32;
            estrellasParameter.Direction = ParameterDirection.Input;
            estrellasParameter.Value = hotel.Estrellas ?? Convert.DBNull;
            estrellasParameter.ParameterName = "@Estrellas";
            parameters.Add(estrellasParameter);

            GetData(commandText, parameters, commandType);

            hotel.Id = Convert.ToInt32(idParameter.Value);

            #region Habitaciones
            if (hotel.Habitaciones != null)
            {
                if (hotel.Habitaciones.Count > 0)
                {

                    foreach (HabitacionDto habitacion in hotel.Habitaciones)
                    {
                        habitacion.HotelId = hotel.Id;
                        HabitacionDto habitacionTemp = AddHabitacion(habitacion);
                    }
                }
            }

            #endregion

            return hotel;
        }

        private HabitacionDto AddHabitacion(HabitacionDto habitacion)
        {
            string commandText = "Habitacion_Add";
            CommandType commandType = CommandType.StoredProcedure;
            List<SqlParameter> parameters = new List<SqlParameter>();

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Output;
            idParameter.ParameterName = "@Id";
            parameters.Add(idParameter);

            // Hotel
            SqlParameter hotelParameter = new SqlParameter();
            hotelParameter.DbType = DbType.Int32;
            hotelParameter.Direction = ParameterDirection.Input;
            hotelParameter.Value = habitacion.HotelId;
            hotelParameter.ParameterName = "@IdHotel";
            parameters.Add(hotelParameter);

            // Planta
            SqlParameter plantaParameter = new SqlParameter();
            plantaParameter.DbType = DbType.Int32;
            plantaParameter.Direction = ParameterDirection.Input;
            plantaParameter.Value = habitacion.Planta;
            plantaParameter.ParameterName = "@Planta";
            parameters.Add(plantaParameter);

            // PosicionX
            SqlParameter posicionXParameter = new SqlParameter();
            posicionXParameter.DbType = DbType.Int32;
            posicionXParameter.Direction = ParameterDirection.Input;
            posicionXParameter.Value = habitacion.PosicionX;
            posicionXParameter.ParameterName = "@PosicionX";
            parameters.Add(posicionXParameter);

            // PosicionX
            SqlParameter posicionYParameter = new SqlParameter();
            posicionYParameter.DbType = DbType.Int32;
            posicionYParameter.Direction = ParameterDirection.Input;
            posicionYParameter.Value = habitacion.PosicionY;
            posicionYParameter.ParameterName = "@PosicionY";
            parameters.Add(posicionYParameter);

            GetData(commandText, parameters, commandType);

            habitacion.Id = Convert.ToInt32(idParameter.Value);

            return habitacion;
        }

        public int Delete(HotelDto hotel)
        {
            string commandText = "Hotel_Delete";
            CommandType commandType = CommandType.StoredProcedure;
            List<SqlParameter> parameters = new List<SqlParameter>();

            #region Habitaciones
            if (hotel.Habitaciones != null)
            {
                if (hotel.Habitaciones.Count > 0)
                {
                    int habitacionesAEliminar = hotel.Habitaciones.Count;
                    int habitacionesEliminadas = 0;
                    foreach (HabitacionDto habitacion in hotel.Habitaciones)
                    {
                        habitacionesEliminadas += DeleteHabitacion(habitacion);
                    }
                    if (habitacionesEliminadas != habitacionesAEliminar)
                    {
                        throw new Exception("No se han podido eliminar todas las habitaciones.");
                    }
                }
            }

            #endregion

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.Value = hotel.Id;
            idParameter.ParameterName = "@Id";
            parameters.Add(idParameter);

            // AffectedRows
            SqlParameter affectedRowsParameter = new SqlParameter();
            affectedRowsParameter.DbType = DbType.Int32;
            affectedRowsParameter.Direction = ParameterDirection.Output;
            affectedRowsParameter.Value = 0;
            affectedRowsParameter.ParameterName = "@AffectedRows";
            parameters.Add(affectedRowsParameter);

            GetData(commandText, parameters, commandType);

            return Convert.ToInt32(affectedRowsParameter.Value);
        }

        private int DeleteHabitacion(HabitacionDto habitacion)
        {
            string commandText = "Habitacion_Delete";
            CommandType commandType = CommandType.StoredProcedure;
            List<SqlParameter> parameters = new List<SqlParameter>();

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.Value = habitacion.Id;
            idParameter.ParameterName = "@Id";
            parameters.Add(idParameter);

            // AffectedRows
            SqlParameter affectedRowsParameter = new SqlParameter();
            affectedRowsParameter.DbType = DbType.Int32;
            affectedRowsParameter.Direction = ParameterDirection.Output;
            affectedRowsParameter.Value = 0;
            affectedRowsParameter.ParameterName = "@AffectedRows";
            parameters.Add(affectedRowsParameter);

            GetData(commandText, parameters, commandType);

            return Convert.ToInt32(affectedRowsParameter.Value);
        }

        public List<HotelDto> GetAll()
        {
            string commandText = @"SELECT
Id,
Nombre,
IdPoblacion,
IdMunicipio,
Direccion,
Plantas,
IdPropietario,
Estrellas
FROM Hotel";

            List<HotelDto> hoteles = GetData(commandText, null);

            return hoteles;
        }

        public HotelDto GetById(int id)
        {
            string commandText = @"SELECT
Id,
Nombre,
IdPoblacion,
IdMunicipio,
Direccion,
Plantas,
IdPropietario,
Estrellas
FROM Hotel
WHERE Id = @Id";
            List<SqlParameter> parameters = new List<SqlParameter>();

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.Value = id;
            idParameter.ParameterName = "@Id";
            parameters.Add(idParameter);

            List<HotelDto> hoteles = GetData(commandText, parameters);

            HotelDto hotel = null;
            if (hoteles.Count == 1)
                hotel = hoteles[0];

            return hotel;
        }

        public int Update(HotelDto hotel)
        {
            string commandText = "Hotel_Update";
            CommandType commandType = CommandType.StoredProcedure;
            List<SqlParameter> parameters = new List<SqlParameter>();

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.Value = hotel.Id;
            idParameter.ParameterName = "@Id";
            parameters.Add(idParameter);

            // Nombre
            SqlParameter nombreParameter = new SqlParameter();
            nombreParameter.DbType = DbType.String;
            nombreParameter.Direction = ParameterDirection.Input;
            nombreParameter.Value = hotel.Nombre ?? Convert.DBNull;
            nombreParameter.ParameterName = "@Nombre";
            parameters.Add(nombreParameter);

            // Poblacion
            SqlParameter poblacionParameter = new SqlParameter();
            poblacionParameter.DbType = DbType.Int32;
            poblacionParameter.Direction = ParameterDirection.Input;
            poblacionParameter.Value = hotel.Poblacion.Id != -1 ? hotel.Poblacion.Id : Convert.DBNull;
            poblacionParameter.ParameterName = "@IdPoblacion";
            parameters.Add(poblacionParameter);

            // Municipio
            SqlParameter municipioParameter = new SqlParameter();
            municipioParameter.DbType = DbType.Int32;
            municipioParameter.Direction = ParameterDirection.Input;
            municipioParameter.Value = hotel.Municipio.Id != -1 ? hotel.Municipio.Id : Convert.DBNull;
            municipioParameter.ParameterName = "@IdMunicipio";
            parameters.Add(municipioParameter);

            // Direccion
            SqlParameter direccionParameter = new SqlParameter();
            direccionParameter.DbType = DbType.String;
            direccionParameter.Direction = ParameterDirection.Input;
            direccionParameter.Value = hotel.Direccion ?? Convert.DBNull;
            direccionParameter.ParameterName = "@Direccion";
            parameters.Add(direccionParameter);

            // Plantas
            SqlParameter plantasParameter = new SqlParameter();
            plantasParameter.DbType = DbType.Int32;
            plantasParameter.Direction = ParameterDirection.Input;
            plantasParameter.Value = hotel.Plantas > 0 ? hotel.Plantas : 0;
            plantasParameter.ParameterName = "@Plantas";
            parameters.Add(plantasParameter);

            // Propietario
            SqlParameter propietarioParameter = new SqlParameter();
            propietarioParameter.DbType = DbType.Int32;
            propietarioParameter.Direction = ParameterDirection.Input;
            propietarioParameter.Value = hotel.Propietario.Id != -1 ? hotel.Propietario.Id : Convert.DBNull;
            propietarioParameter.ParameterName = "@IdPropietario";
            parameters.Add(propietarioParameter);

            // Estrellas
            SqlParameter estrellasParameter = new SqlParameter();
            estrellasParameter.DbType = DbType.Int32;
            estrellasParameter.Direction = ParameterDirection.Input;
            estrellasParameter.Value = hotel.Estrellas ?? Convert.DBNull;
            estrellasParameter.ParameterName = "@Estrellas";
            parameters.Add(estrellasParameter);

            // AffectedRows
            SqlParameter affectedRowsParameter = new SqlParameter();
            affectedRowsParameter.DbType = DbType.Int32;
            affectedRowsParameter.Direction = ParameterDirection.Output;
            affectedRowsParameter.Value = 0;
            affectedRowsParameter.ParameterName = "@AffectedRows";
            parameters.Add(affectedRowsParameter);

            GetData(commandText, parameters, commandType);

            return Convert.ToInt32(affectedRowsParameter.Value);
        }

        public bool HasAnyHotel()
        {
            bool hasHotel = false;
            string commandText = @"SELECT TOP 1 * FROM Hotel";
            List<HotelDto> hoteles = GetData(commandText, null);
            if (hoteles.Count > 0)
                hasHotel = true;
            return hasHotel;
        }

        public int GetReservasByIdHotel(HotelDto hotel)
        {
           string commandText = @"SELECT count(*) 
FROM reserva 
WHERE IdHotel = @IdHotel
AND FechaInicio <= GetDate() 
AND FechaFinal >= GetDate()";
            List<SqlParameter> parameters = new List<SqlParameter>();
            CommandType commandType = CommandType.Text;

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.ParameterName = "@IdHotel";
            idParameter.Value = hotel.Id;
            parameters.Add(idParameter);

            string result = GetDataScalar(commandText, parameters, commandType);

            return Convert.ToInt32(result);
        }

        public int GetEntradasByIdHotel(HotelDto hotel)
        {
            string commandText = @"SELECT count(*) 
FROM reserva 
WHERE IdHotel = @IdHotel
AND CONVERT(VARCHAR(10), FechaInicio, 103) = CONVERT(VARCHAR(10), GetDate(), 103)";
            List<SqlParameter> parameters = new List<SqlParameter>();
            CommandType commandType = CommandType.Text;

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.ParameterName = "@IdHotel";
            idParameter.Value = hotel.Id;
            parameters.Add(idParameter);

            string result = GetDataScalar(commandText, parameters, commandType);

            return Convert.ToInt32(result);
        }

        public int GetSalidasByIdHotel(HotelDto hotel)
        {
            string commandText = @"SELECT count(*) 
FROM reserva 
WHERE IdHotel = @IdHotel 
AND CONVERT(VARCHAR(10), FechaFinal, 103) = CONVERT(VARCHAR(10), GetDate(), 103)
";
            List<SqlParameter> parameters = new List<SqlParameter>();
            CommandType commandType = CommandType.Text;

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.ParameterName = "@IdHotel";
            idParameter.Value = hotel.Id;
            parameters.Add(idParameter);

            string result = GetDataScalar(commandText, parameters, commandType);

            return Convert.ToInt32(result);
        }

        public HotelDto GetByNombre(string nombre)
        {
            string commandText = @"SELECT 
Id,
Nombre,
IdPoblacion,
IdMunicipio,
Direccion,
Plantas,
IdPropietario,
Estrellas
 FROM Hotel WHERE Nombre = @Nombre";
            List<SqlParameter> parameters = new List<SqlParameter>();

            // Nombre
            SqlParameter nombreParameter = new SqlParameter();
            nombreParameter.DbType = DbType.String;
            nombreParameter.Direction = ParameterDirection.Input;
            nombreParameter.ParameterName = "@Nombre";
            nombreParameter.Value = nombre;
            parameters.Add(nombreParameter);

            List<HotelDto> hoteles = GetData(commandText, parameters);
            HotelDto hotel = null;

            if (hoteles.Count == 1)
                hotel = hoteles[0];

            return hotel;
        }

        protected override HotelDto MapDataReader(SqlDataReader dr)
        {
            HotelDto hotel = new HotelDto()
            {
                Id = Convert.ToInt32(dr["Id"]),
                Nombre = dr["Nombre"] != null ? (string)dr["Nombre"] : null,
                Poblacion = new PoblacionDto()
                {
                    Id = Convert.ToInt32(dr["IdPoblacion"])
                },
                Municipio = new MunicipioDto()
                {
                    Id = Convert.ToInt32(dr["IdMunicipio"])
                },
                Direccion = dr["Direccion"] != null ? (string)dr["Direccion"] : null,
                Plantas = Convert.ToInt32(dr["Plantas"]),
                Estrellas = dr["Estrellas"] != null ?  Convert.ToInt32(dr["Estrellas"]) : (int?)null // Probar esto
            };
            if(dr["IdPropietario"] != DBNull.Value)
                hotel.Propietario = new EmpleadoDto(){Id = Convert.ToInt32(dr["IdPropietario"])};
            return hotel;
        }
    }
}
