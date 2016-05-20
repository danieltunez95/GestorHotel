using Gh.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Gh.Dao
{
    public class ReservaDao : BaseDao<ReservaDto>, IDao<ReservaDto>
    {
        public ReservaDto Add(ReservaDto reserva)
        {
            string commandText = "Reserva_Add";
            CommandType commandType = CommandType.StoredProcedure;
            List<SqlParameter> parameters = new List<SqlParameter>();

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Output;
            idParameter.ParameterName = "@Id";
            parameters.Add(idParameter);

            // IdHotel
            SqlParameter idHotelParameter = new SqlParameter();
            idHotelParameter.DbType = DbType.Int32;
            idHotelParameter.Direction = ParameterDirection.Input;
            idHotelParameter.ParameterName = "@IdHotel";
            idHotelParameter.Value = reserva.IdHotel;
            parameters.Add(idHotelParameter);

            // IdHabitacion
            SqlParameter idHabitacionParameter = new SqlParameter();
            idHabitacionParameter.DbType = DbType.Int32;
            idHabitacionParameter.Direction = ParameterDirection.Input;
            idHabitacionParameter.ParameterName = "@IdHabitacion";
            idHabitacionParameter.Value = reserva.IdHabitacion;
            parameters.Add(idHabitacionParameter);

            // IdCliente
            SqlParameter idClienteParameter = new SqlParameter();
            idClienteParameter.DbType = DbType.Int32;
            idClienteParameter.Direction = ParameterDirection.Input;
            idClienteParameter.ParameterName = "@IdCliente";
            idClienteParameter.Value = reserva.IdCliente;
            parameters.Add(idClienteParameter);

            // Tipo
            SqlParameter tipoParameter = new SqlParameter();
            tipoParameter.DbType = DbType.Int32;
            tipoParameter.Direction = ParameterDirection.Input;
            tipoParameter.ParameterName = "@Tipo";
            tipoParameter.Value = reserva.Tipo;
            parameters.Add(tipoParameter);

            // Comentario
            SqlParameter comentarioParameter = new SqlParameter();
            comentarioParameter.DbType = DbType.String;
            comentarioParameter.Direction = ParameterDirection.Input;
            comentarioParameter.ParameterName = "@Comentario";
            comentarioParameter.Value = reserva.Comentario != null ? reserva.Comentario : Convert.DBNull;
            parameters.Add(comentarioParameter);

            // FechaInicio
            SqlParameter fechaInicioParameter = new SqlParameter();
            fechaInicioParameter.DbType = DbType.DateTime;
            fechaInicioParameter.Direction = ParameterDirection.Input;
            fechaInicioParameter.ParameterName = "@FechaInicio";
            fechaInicioParameter.Value = reserva.FechaInicio;
            parameters.Add(fechaInicioParameter);

            // FechaFinal
            SqlParameter fechaFinalParameter = new SqlParameter();
            fechaFinalParameter.DbType = DbType.DateTime;
            fechaFinalParameter.Direction = ParameterDirection.Input;
            fechaFinalParameter.ParameterName = "@FechaFinal";
            fechaFinalParameter.Value = reserva.FechaFinal;
            parameters.Add(fechaFinalParameter);

            // FechaReserva
            SqlParameter fechaReservaParameter = new SqlParameter();
            fechaReservaParameter.DbType = DbType.DateTime;
            fechaReservaParameter.Direction = ParameterDirection.Input;
            fechaReservaParameter.ParameterName = "@FechaCreacion";
            fechaReservaParameter.Value = reserva.FechaReserva;
            parameters.Add(fechaReservaParameter);

            // Importe
            SqlParameter importeParameter = new SqlParameter();
            importeParameter.DbType = DbType.Decimal;
            importeParameter.Direction = ParameterDirection.Input;
            importeParameter.ParameterName = "@Importe";
            importeParameter.Value = reserva.Importe != null ? reserva.Importe : null;
            parameters.Add(importeParameter);

            // Descuento
            SqlParameter descuentoParameter = new SqlParameter();
            importeParameter.DbType = DbType.Decimal;
            importeParameter.Direction = ParameterDirection.Input;
            importeParameter.ParameterName = "@Descuento";
            importeParameter.Value = reserva.Descuento != null ? reserva.Descuento : null;
            parameters.Add(importeParameter);

            // ImporteFinal
            SqlParameter importeFinalParameter = new SqlParameter();
            importeFinalParameter.DbType = DbType.Decimal;
            importeFinalParameter.Direction = ParameterDirection.Input;
            importeFinalParameter.ParameterName = "@ImporteFinal";
            importeFinalParameter.Value = reserva.ImporteFinal != null ? reserva.ImporteFinal : null;
            parameters.Add(importeFinalParameter);

            GetData(commandText, parameters, commandType);

            reserva.Id = Convert.ToInt32(idParameter.Value);

            return reserva;
        }

        public int Delete(ReservaDto reserva)
        {
            string commandText = "Reserva_Delete";
            CommandType commandType = CommandType.StoredProcedure;

            List<SqlParameter> parameters = new List<SqlParameter>();

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.ParameterName = "@Id";
            idParameter.Value = reserva.Id;
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

        public List<ReservaDto> GetAll()
        {
            string commandText = @"SELECT Id,
IdHotel,
IdHabitacion,
IdCliente,
Tipo,
Comentario,
FechaInicio,
FechaFinal,
FechaCreacion,
Importe,
Descuento,
ImporteFinal
FROM Reserva";

            List<ReservaDto> reservas = GetData(commandText, null);

            return reservas;
        }

        public ReservaDto GetById(int id)
        {
            string commandText = @"SELECT Id,
IdHotel,
IdHabitacion,
IdCliente,
Tipo,
Comentario,
FechaInicio,
FechaFinal,
FechaCreacion,
Importe,
Descuento,
ImporteFinal
FROM Reserva
WHERE Id = @Id";

            List<SqlParameter> parameters = new List<SqlParameter>();

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.ParameterName = "@Id";
            idParameter.Value = id;
            parameters.Add(idParameter);

            List<ReservaDto> reservas = GetData(commandText, parameters);
            ReservaDto reserva = null;

            if (reservas.Count == 1)
                reserva = reservas[0];

            return reserva;
        }

        public int Update(ReservaDto reserva)
        {
            string commandText = "Reserva_Add";
            CommandType commandType = CommandType.StoredProcedure;
            List<SqlParameter> parameters = new List<SqlParameter>();

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.ParameterName = "@Id";
            idParameter.Value = reserva.Id;
            parameters.Add(idParameter);

            // IdHotel
            SqlParameter idHotelParameter = new SqlParameter();
            idHotelParameter.DbType = DbType.Int32;
            idHotelParameter.Direction = ParameterDirection.Input;
            idHotelParameter.ParameterName = "@IdHotel";
            idHotelParameter.Value = reserva.IdHotel;
            parameters.Add(idHotelParameter);

            // IdHabitacion
            SqlParameter idHabitacionParameter = new SqlParameter();
            idHabitacionParameter.DbType = DbType.Int32;
            idHabitacionParameter.Direction = ParameterDirection.Input;
            idHabitacionParameter.ParameterName = "@IdHabitacion";
            idHabitacionParameter.Value = reserva.IdHabitacion;
            parameters.Add(idHabitacionParameter);

            // IdCliente
            SqlParameter idClienteParameter = new SqlParameter();
            idClienteParameter.DbType = DbType.Int32;
            idClienteParameter.Direction = ParameterDirection.Input;
            idClienteParameter.ParameterName = "@IdCliente";
            idClienteParameter.Value = reserva.IdCliente;
            parameters.Add(idClienteParameter);

            // Tipo
            SqlParameter tipoParameter = new SqlParameter();
            tipoParameter.DbType = DbType.Int32;
            tipoParameter.Direction = ParameterDirection.Input;
            tipoParameter.ParameterName = "@Tipo";
            tipoParameter.Value = reserva.Tipo;
            parameters.Add(tipoParameter);

            // Comentario
            SqlParameter comentarioParameter = new SqlParameter();
            comentarioParameter.DbType = DbType.String;
            comentarioParameter.Direction = ParameterDirection.Input;
            comentarioParameter.ParameterName = "@Comentario";
            comentarioParameter.Value = reserva.Comentario != null ? reserva.Comentario : Convert.DBNull;
            parameters.Add(comentarioParameter);

            // FechaInicio
            SqlParameter fechaInicioParameter = new SqlParameter();
            fechaInicioParameter.DbType = DbType.DateTime;
            fechaInicioParameter.Direction = ParameterDirection.Input;
            fechaInicioParameter.ParameterName = "@FechaInicio";
            fechaInicioParameter.Value = reserva.FechaInicio;
            parameters.Add(fechaInicioParameter);

            // FechaFinal
            SqlParameter fechaFinalParameter = new SqlParameter();
            fechaFinalParameter.DbType = DbType.DateTime;
            fechaFinalParameter.Direction = ParameterDirection.Input;
            fechaFinalParameter.ParameterName = "@FechaFinal";
            fechaFinalParameter.Value = reserva.FechaFinal;
            parameters.Add(fechaFinalParameter);

            // FechaReserva
            SqlParameter fechaReservaParameter = new SqlParameter();
            fechaReservaParameter.DbType = DbType.DateTime;
            fechaReservaParameter.Direction = ParameterDirection.Input;
            fechaReservaParameter.ParameterName = "@FechaCreacion";
            fechaReservaParameter.Value = reserva.FechaReserva;
            parameters.Add(fechaReservaParameter);

            // Importe
            SqlParameter importeParameter = new SqlParameter();
            importeParameter.DbType = DbType.Decimal;
            importeParameter.Direction = ParameterDirection.Input;
            importeParameter.ParameterName = "@Importe";
            importeParameter.Value = reserva.Importe != null ? reserva.Importe : null;
            parameters.Add(importeParameter);

            // Descuento
            SqlParameter descuentoParameter = new SqlParameter();
            importeParameter.DbType = DbType.Decimal;
            importeParameter.Direction = ParameterDirection.Input;
            importeParameter.ParameterName = "@Descuento";
            importeParameter.Value = reserva.Descuento != null ? reserva.Descuento : null;
            parameters.Add(importeParameter);

            // ImporteFinal
            SqlParameter importeFinalParameter = new SqlParameter();
            importeFinalParameter.DbType = DbType.Decimal;
            importeFinalParameter.Direction = ParameterDirection.Input;
            importeFinalParameter.ParameterName = "@ImporteFinal";
            importeFinalParameter.Value = reserva.ImporteFinal != null ? reserva.ImporteFinal : null;
            parameters.Add(importeFinalParameter);

            // AffectedRows
            SqlParameter affectedRowsParameter = new SqlParameter();
            affectedRowsParameter.DbType = DbType.Int32;
            affectedRowsParameter.Direction = ParameterDirection.Output;
            affectedRowsParameter.ParameterName = "@AffectedRows";
            parameters.Add(affectedRowsParameter);

            GetData(commandText, parameters, commandType);

            return Convert.ToInt32(affectedRowsParameter.Value);
        }

        protected override ReservaDto MapDataReader(SqlDataReader dr)
        {
            ReservaDto reserva = new ReservaDto()
            {
                Id = Convert.ToInt32(dr["Id"]),
                IdHotel = Convert.ToInt32(dr["IdHotel"]),
                IdCliente = Convert.ToInt32(dr["IdHabitacion"]),
                Tipo = Convert.ToInt32(dr["Tipo"]),
                Comentario = dr["Comentario"] != null ? (string)dr["Comentario"] : null,
                FechaInicio =  Convert.ToDateTime(dr["FechaInicio"]),
                FechaFinal = Convert.ToDateTime(dr["FechaFinal"]),
                FechaReserva = Convert.ToDateTime(dr["FechaCreacion"]),
                Importe = dr["Importe"] != null ? (decimal?)dr["Importe"] : null,
                Descuento = dr["Descuento"] != null ? (decimal?)dr["Descuento"] : null,
                ImporteFinal = dr["DescuentoFinal"] != null ? (decimal?)dr["ImporteFinal"] : null
            };

            return reserva;
        }
    }
}
