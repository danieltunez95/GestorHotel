using Gh.Common;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System;
using System.Data;

namespace Gh.Dao
{
    public class EmpleadoDao : BaseDao<EmpleadoDto>, IDao<EmpleadoDto>
    {
        public EmpleadoDto Add(EmpleadoDto empleado)
        {
            string commandText = "Empleado_Add";
            CommandType commandType = CommandType.StoredProcedure;

            List<SqlParameter> parameters = new List<SqlParameter>();

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Output;
            idParameter.ParameterName = "@Id";
            parameters.Add(idParameter);

            // PersonaId
            SqlParameter personaIdParameter = new SqlParameter();
            personaIdParameter.DbType = DbType.Int32;
            personaIdParameter.Direction = ParameterDirection.Input;
            personaIdParameter.ParameterName = "@PersonaId";
            personaIdParameter.Value = empleado.Persona.Id;
            parameters.Add(personaIdParameter);

            // OficioId
            SqlParameter oficioIdParameter = new SqlParameter();
            oficioIdParameter.DbType = DbType.Int32;
            oficioIdParameter.Direction = ParameterDirection.Input;
            oficioIdParameter.ParameterName = "@OficioId";
            oficioIdParameter.Value = Convert.ToInt32(empleado.Oficio);
            parameters.Add(oficioIdParameter);

            // TurnoId
            SqlParameter turnoIdParameter = new SqlParameter();
            turnoIdParameter.DbType = DbType.Int32;
            turnoIdParameter.Direction = ParameterDirection.Input;
            turnoIdParameter.ParameterName = "@TurnoId";
            turnoIdParameter.Value = empleado.Turno.Id;
            parameters.Add(turnoIdParameter);

            // SalarioBruto
            SqlParameter salarioBrutoParameter = new SqlParameter();
            salarioBrutoParameter.DbType = DbType.Decimal;
            salarioBrutoParameter.Direction = ParameterDirection.Input;
            salarioBrutoParameter.ParameterName = "@SalarioBruto";
            salarioBrutoParameter.Value = empleado.SalarioBruto;
            parameters.Add(salarioBrutoParameter);

            // CuentaBancaria
            SqlParameter cuentaBancariaParameter = new SqlParameter();
            cuentaBancariaParameter.DbType = DbType.String;
            cuentaBancariaParameter.Direction = ParameterDirection.Input;
            cuentaBancariaParameter.ParameterName = "@CuentaBancaria";
            cuentaBancariaParameter.Value = empleado.CuentaBancaria;
            parameters.Add(cuentaBancariaParameter);

            // FechaContrato
            SqlParameter fechaContratoParameter = new SqlParameter();
            fechaContratoParameter.DbType = DbType.DateTime;
            fechaContratoParameter.Direction = ParameterDirection.Input;
            fechaContratoParameter.ParameterName = "@FechaContrato";
            fechaContratoParameter.Value = empleado.FechaInicio;
            parameters.Add(fechaContratoParameter);

            // FechaExpiracion
            SqlParameter fechaExpiracionParameter = new SqlParameter();
            fechaExpiracionParameter.DbType = DbType.DateTime;
            fechaExpiracionParameter.Direction = ParameterDirection.Input;
            fechaExpiracionParameter.ParameterName = "@FechaExpiracion";
            fechaExpiracionParameter.Value = empleado.FechaFin;
            parameters.Add(fechaExpiracionParameter);

            GetData(commandText, parameters, commandType);

            empleado.Id = Convert.ToInt32(idParameter.Value);
            return empleado;
        }

        public int Delete(EmpleadoDto empleado)
        {
            string commandText = "Empleado_Delete";
            CommandType commandType = CommandType.StoredProcedure;

            List<SqlParameter> parameters = new List<SqlParameter>();

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.ParameterName = "@Id";
            idParameter.Value = empleado.Id;
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

        public List<EmpleadoDto> GetAll()
        {
            string commandText = @"SELECT Id,
PersonaId,
OficioId,
TurnoId,
SalarioBruto,
CuentaBancaria,
FechaContrato,
FechaExpiracion
FROM Empleado";

            List<EmpleadoDto> empleados = GetData(commandText, null);

            return empleados;
        }

        public EmpleadoDto GetById(int id)
        {
            string commandText = @"SELECT 
Id, 
PersonaId, 
OficioId, 
TurnoId,
SalarioBruto,
CuentaBancaria,
FechaContrato,
FechaExpiracion
FROM empleado
 WHERE Id = @Id";

            List<SqlParameter> parameters = new List<SqlParameter>();

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.ParameterName = "@Id";
            idParameter.Value = id;
            parameters.Add(idParameter);

            List<EmpleadoDto> empleados = GetData(commandText, parameters);
            EmpleadoDto empleado = null;

            if (empleados.Count == 1)
                empleado = empleados[0];

            return empleado;
        }

        public int Update(EmpleadoDto empleado)
        {
            string commandText = "Empleado_Update";
            CommandType commandType = CommandType.StoredProcedure;

            List<SqlParameter> parameters = new List<SqlParameter>();

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.ParameterName = "@Id";
            idParameter.Value = empleado.Id;
            parameters.Add(idParameter);

            // PersonaId
            SqlParameter personaIdParameter = new SqlParameter();
            personaIdParameter.DbType = DbType.Int32;
            personaIdParameter.Direction = ParameterDirection.Input;
            personaIdParameter.ParameterName = "@PersonaId";
            personaIdParameter.Value = empleado.Persona.Id;
            parameters.Add(personaIdParameter);

            // OficioId
            SqlParameter oficioIdParameter = new SqlParameter();
            oficioIdParameter.DbType = DbType.Int32;
            oficioIdParameter.Direction = ParameterDirection.Input;
            oficioIdParameter.ParameterName = "@OficioId";
            oficioIdParameter.Value = Convert.ToInt32(empleado.Oficio);
            parameters.Add(oficioIdParameter);

            // TurnoId
            SqlParameter turnoIdParameter = new SqlParameter();
            turnoIdParameter.DbType = DbType.Int32;
            turnoIdParameter.Direction = ParameterDirection.Input;
            turnoIdParameter.ParameterName = "@TurnoId";
            turnoIdParameter.Value = empleado.Turno.Id;
            parameters.Add(turnoIdParameter);

            // SalarioBruto
            SqlParameter salarioBrutoParameter = new SqlParameter();
            salarioBrutoParameter.DbType = DbType.Decimal;
            salarioBrutoParameter.Direction = ParameterDirection.Input;
            salarioBrutoParameter.ParameterName = "@SalarioBruto";
            salarioBrutoParameter.Value = empleado.SalarioBruto;
            parameters.Add(salarioBrutoParameter);

            // CuentaBancaria
            SqlParameter cuentaBancariaParameter = new SqlParameter();
            cuentaBancariaParameter.DbType = DbType.String;
            cuentaBancariaParameter.Direction = ParameterDirection.Input;
            cuentaBancariaParameter.ParameterName = "@CuentaBancaria";
            cuentaBancariaParameter.Value = empleado.CuentaBancaria;
            parameters.Add(cuentaBancariaParameter);

            // FechaContrato
            SqlParameter fechaContratoParameter = new SqlParameter();
            fechaContratoParameter.DbType = DbType.DateTime;
            fechaContratoParameter.Direction = ParameterDirection.Input;
            fechaContratoParameter.ParameterName = "@FechaContrato";
            fechaContratoParameter.Value = empleado.FechaInicio;
            parameters.Add(fechaContratoParameter);

            // FechaExpiracion
            SqlParameter fechaExpiracionParameter = new SqlParameter();
            fechaExpiracionParameter.DbType = DbType.DateTime;
            fechaExpiracionParameter.Direction = ParameterDirection.Input;
            fechaExpiracionParameter.ParameterName = "@FechaExpiracion";
            fechaExpiracionParameter.Value = empleado.FechaFin;
            parameters.Add(fechaExpiracionParameter);

            // AffectedRows
            SqlParameter affectedRowsParameter = new SqlParameter();
            affectedRowsParameter.DbType = DbType.Int32;
            affectedRowsParameter.Direction = ParameterDirection.Output;
            affectedRowsParameter.ParameterName = "@AffectedRows";
            parameters.Add(affectedRowsParameter);

            GetData(commandText, parameters, commandType);

            return Convert.ToInt32(affectedRowsParameter.Value);
        }

        protected override EmpleadoDto MapDataReader(SqlDataReader dr)
        {
            Oficio oficio = (Oficio)Enum.Parse(typeof(Oficio), dr["OficioId"].ToString());
            EmpleadoDto empleado = new EmpleadoDto()
            {
                Id = Convert.ToInt32(dr["Id"]),
                Oficio = oficio,
                SalarioBruto = Convert.ToDecimal(dr["SalarioBruto"]),
                CuentaBancaria = dr["CuentaBancaria"] != null ? (string)dr["CuentaBancaria"] : null,
                FechaInicio = Convert.ToDateTime(dr["FechaContrato"]),
                FechaFin = Convert.ToDateTime(dr["FechaExpiracion"])
            };
            if(Convert.ToString(dr["PersonaId"]) != null)
                empleado.Persona = new PersonaDto(){ Id = Convert.ToInt32(dr["PersonaId"])};
            if (Convert.ToString(dr["PersonaId"]) != null)
                empleado.Turno = new TurnoDto() { Id = Convert.ToInt32(dr["TurnoId"]) };

            return empleado;
        }
    }
}
