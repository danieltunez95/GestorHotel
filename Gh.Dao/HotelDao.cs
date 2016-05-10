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
            string storedProcedure = "Hotel_Add";
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
            plantasParameter.Value = hotel.Plantas ?? 1;
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

            GetData(storedProcedure, parameters, commandType);

            hotel.Id = Convert.ToInt32(idParameter.Value);

            #region Habitaciones
            List<HabitacionDto> habitaciones = new List<HabitacionDto>();
            
            foreach (HabitacionDto habitacion in hotel.Habitaciones)
            {
                HabitacionDto habitacionTemp = AddHabitacion(habitacion, hotel.Id);
                habitaciones.Add(habitacionTemp);
            }

            #endregion

            return hotel;
        }

        private HabitacionDto AddHabitacion(HabitacionDto habitacion, int idHotel)
        {
            string storedProcedure = "Habitacion_Add";
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
            hotelParameter.Value = idHotel;
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

            // Precio
            SqlParameter precioParameter = new SqlParameter();
            precioParameter.DbType = DbType.Int32;
            precioParameter.Direction = ParameterDirection.Input;
            precioParameter.Value = 3123; // Falta añadir preceio
            precioParameter.ParameterName = "@Precio";
            parameters.Add(precioParameter);

            return habitacion;
        }

        public int Delete(HotelDto entity)
        {
            throw new NotImplementedException();
        }

        public List<HotelDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public HotelDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(HotelDto entity)
        {
            throw new NotImplementedException();
        }

        protected override HotelDto MapDataReader(SqlDataReader dr)
        {
            throw new NotImplementedException();
        }
    }
}
