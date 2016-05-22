using Gh.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Gh.Dao
{
    public class HabitacionDao : BaseDao<HabitacionDto>, IDao<HabitacionDto>
    {
        public HabitacionDto Add(HabitacionDto habitacion)
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

            // PosicionY
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

        public int Delete(HabitacionDto habitacion)
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

        public List<HabitacionDto> GetAll()
        {
            throw new Exception("Utilizar GetAllByIdHotel.");
        }

        public List<HabitacionDto> GetAllByIdHotel(HotelDto hotel)
        {
            string commandText = @"SELECT
Id,
IdHotel,
Planta,
PosicionX,
PosicionY,
TipoHabitacion
FROM Habitacion
WHERE IdHotel = @Idhotel";
            List<SqlParameter> parameters = new List<SqlParameter>();

            //Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.ParameterName = "@IdHotel";
            idParameter.Value = hotel.Id;
            parameters.Add(idParameter);

            List<HabitacionDto> habitaciones = GetData(commandText, parameters);

            return habitaciones;
        }

        public HabitacionDto GetById(int id)
        {
            string commandText = @"SELECT
Id,
IdHotel,
Planta,
PosicionX,
PosicionY,
TipoHabitacion
FROM Habitacion
WHERE Id = @Id";
            List<SqlParameter> parameters = new List<SqlParameter>();

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.Value = id;
            idParameter.ParameterName = "@Id";
            parameters.Add(idParameter);

            List<HabitacionDto> habitaciones = GetData(commandText, parameters);
            HabitacionDto habitacion = null;
            if (habitaciones.Count == 1)
                habitacion = habitaciones[0];

            return habitacion;
        }

        public List<HabitacionDto> GetByTipoHabitacion(TipoHabitacionDto tipoHabitacion)
        {
            string commandText = @"SELECT
Id,
IdHotel,
Planta,
PosicionX,
PosicionY,
TipoHabitacion
FROM Habitacion
WHERE TipoHabitacion = @TipoHabitacion";
            List<SqlParameter> parameters = new List<SqlParameter>();

            // TipoHabitacion
            SqlParameter tipoHabitacionParameter = new SqlParameter();
            tipoHabitacionParameter.DbType = DbType.Int32;
            tipoHabitacionParameter.Direction = ParameterDirection.Input;
            tipoHabitacionParameter.Value = tipoHabitacion.Id;
            tipoHabitacionParameter.ParameterName = "@TipoHabitacion";
            parameters.Add(tipoHabitacionParameter);

            List<HabitacionDto> habitaciones = GetData(commandText, parameters);
            
            return habitaciones;
        }

        public bool isBusy(int idHotel, int posicionX, int posicionY, int planta, DateTime fechaInicio, DateTime fechaFinal)
        {
            string commandText = @"SELECT
DISTINCT 1 
FROM Habitacion h
INNER JOIN Reserva r ON (h.Id = r.IdHabitacion)
WHERE h.IdHotel = @IdHotel 
AND h.PosicionX = @PosicionX
AND h.PosicionY = @PosicionY
AND h.Planta    = @Planta
AND r.FechaInicio >= @FechaInicio
AND r.FechaFinal <= @FechaFinal";

            //string sqlFormattedDate = fechaInicio.ToString("yyyy-MM-dd HH:mm:ss");
            List<SqlParameter> parameters = new List<SqlParameter>();

            // HotelId
            SqlParameter hotelIdParameter = new SqlParameter();
            hotelIdParameter.DbType = DbType.Int32;
            hotelIdParameter.Direction = ParameterDirection.Input;
            hotelIdParameter.ParameterName = "@Idhotel";
            hotelIdParameter.Value = idHotel;
            parameters.Add(hotelIdParameter);

            // PosicionX
            SqlParameter posicionXParameter = new SqlParameter();
            posicionXParameter.DbType = DbType.Int32;
            posicionXParameter.Direction = ParameterDirection.Input;
            posicionXParameter.ParameterName = "@PosicionX";
            posicionXParameter.Value = posicionX;
            parameters.Add(posicionXParameter);

            // PosicionY
            SqlParameter posicionYParameter = new SqlParameter();
            posicionYParameter.DbType = DbType.Int32;
            posicionYParameter.Direction = ParameterDirection.Input;
            posicionYParameter.ParameterName = "@PosicionY";
            posicionYParameter.Value = posicionY;
            parameters.Add(posicionYParameter);

            // Planta
            SqlParameter plantaParameter = new SqlParameter();
            plantaParameter.DbType = DbType.Int32;
            plantaParameter.Direction = ParameterDirection.Input;
            plantaParameter.ParameterName = "@Planta";
            plantaParameter.Value = planta;
            parameters.Add(plantaParameter);

            // FechaInicio
            fechaInicio = fechaInicio.AddHours(16);
            SqlParameter fechaInicioParameter = new SqlParameter();
            fechaInicioParameter.DbType = DbType.String;
            fechaInicioParameter.Direction = ParameterDirection.Input;
            fechaInicioParameter.ParameterName = "@FechaInicio";
            fechaInicioParameter.Value = fechaInicio.ToString("yyyy-MM-dd HH:mm:ss");
            parameters.Add(fechaInicioParameter);

            // FechaFinal
            fechaFinal = fechaFinal.AddHours(16);
            SqlParameter fechaFinalParameter = new SqlParameter();
            fechaFinalParameter.DbType = DbType.String;
            fechaFinalParameter.Direction = ParameterDirection.Input;
            fechaFinalParameter.ParameterName = "@FechaFinal";
            fechaFinalParameter.Value = fechaFinal.ToString("yyyy-MM-dd HH:mm:ss");
            parameters.Add(fechaFinalParameter);

            string result = GetDataScalar(commandText, parameters, CommandType.Text);
            
            return Convert.ToBoolean(Convert.ToInt32(result));
        }

        public bool existHabitacion(int idHotel, int posicionX, int posicionY, int planta)
        {
            string commandText = @"SELECT
DISTINCT 1
FROM Habitacion
WHERE IdHotel = @IdHotel
AND PosicionX = @PosicionX
AND PosicionY = @PosicionY
AND Planta = @Planta";
            List<SqlParameter> parameters = new List<SqlParameter>();

            // IdHotel
            SqlParameter idHotelParameter = new SqlParameter();
            idHotelParameter.DbType = DbType.Int32;
            idHotelParameter.Direction = ParameterDirection.Input;
            idHotelParameter.ParameterName = "@IdHotel";
            idHotelParameter.Value = idHotel;
            parameters.Add(idHotelParameter);

            // PosicionX
            SqlParameter posicionXParameter = new SqlParameter();
            posicionXParameter.DbType = DbType.Int32;
            posicionXParameter.Direction = ParameterDirection.Input;
            posicionXParameter.ParameterName = "@PosicionX";
            posicionXParameter.Value = posicionX;
            parameters.Add(posicionXParameter);

            // PosicionY
            SqlParameter posicionYParameter = new SqlParameter();
            posicionYParameter.DbType = DbType.Int32;
            posicionYParameter.Direction = ParameterDirection.Input;
            posicionYParameter.ParameterName = "@PosicionY";
            posicionYParameter.Value = posicionY;
            parameters.Add(posicionYParameter);

            // Planta
            SqlParameter plantaParameter = new SqlParameter();
            plantaParameter.DbType = DbType.Int32;
            plantaParameter.Direction = ParameterDirection.Input;
            plantaParameter.ParameterName = "@Planta";
            plantaParameter.Value = planta;
            parameters.Add(plantaParameter);

            string result = GetDataScalar(commandText, parameters, CommandType.Text);

            return Convert.ToBoolean(Convert.ToInt32(result));
        }

        public int Update(HabitacionDto habitacion)
        {
            string commandText = "Habitacion_Update";
            CommandType commandType = CommandType.StoredProcedure;
            List<SqlParameter> parameters = new List<SqlParameter>();

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.Value = habitacion.Id;
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

            // TipoHabitacion
            SqlParameter tipoHabitacionParameter = new SqlParameter();
            tipoHabitacionParameter.DbType = DbType.Int32;
            tipoHabitacionParameter.Direction = ParameterDirection.Input;
            tipoHabitacionParameter.Value = habitacion.TipoHabitacion.Id;
            tipoHabitacionParameter.ParameterName = "@TipoHabitacion";
            parameters.Add(tipoHabitacionParameter);

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

        protected override HabitacionDto MapDataReader(SqlDataReader dr)
        {
            // Habrá algo que no sea NULL, hablarlo con Dani.
            CamaEnum IdCama = (CamaEnum)Enum.Parse(typeof(CamaEnum), dr["IdCama"].ToString());
            HabitacionDto habitacion = new HabitacionDto()
            {
                Id = Convert.ToInt32(dr["Id"]),
                HotelId = Convert.ToInt32(dr["IdHotel"]),
                Planta = Convert.ToInt32(dr["Planta"]),
                PosicionX = Convert.ToInt32(dr["PosicionX"]),
                PosicionY = Convert.ToInt32(dr["PosicionY"])
            };
            if (dr["TipoHabitacion"] != null)
                habitacion.TipoHabitacion = new TipoHabitacionDto() { Id = Convert.ToInt32(dr["TipoHabitacion"]) };

            return habitacion;
        }
    }
}