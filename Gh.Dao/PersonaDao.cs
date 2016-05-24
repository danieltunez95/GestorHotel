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
    public class PersonaDao : BaseDao<PersonaDto>, IDao<PersonaDto>
    {
        public PersonaDto Add(PersonaDto persona)
        {
            string commandText = "Persona_Add";
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
            nombreParameter.Value = persona.Nombre ?? Convert.DBNull;
            parameters.Add(nombreParameter);

            // PrimerApellido
            SqlParameter primerApellidoParameter = new SqlParameter();
            primerApellidoParameter.DbType = DbType.String;
            primerApellidoParameter.Direction = ParameterDirection.Input;
            primerApellidoParameter.ParameterName = "@PrimerApellido";
            primerApellidoParameter.Value = persona.PrimerApellido ?? Convert.DBNull;
            parameters.Add(primerApellidoParameter);

            // SegundoApellido
            SqlParameter segundoApellidoParameter = new SqlParameter();
            segundoApellidoParameter.DbType = DbType.String;
            segundoApellidoParameter.Direction = ParameterDirection.Input;
            segundoApellidoParameter.ParameterName = "@SegundoApellido";
            segundoApellidoParameter.Value = persona.SegundoApellido ?? Convert.DBNull;
            parameters.Add(segundoApellidoParameter);

            // Telefono
            SqlParameter telefonoParameter = new SqlParameter();
            telefonoParameter.DbType = DbType.String;
            telefonoParameter.Direction = ParameterDirection.Input;
            telefonoParameter.ParameterName = "@Telefono";
            telefonoParameter.Value = persona.Telefono ?? Convert.DBNull;
            parameters.Add(telefonoParameter);

            // Direccion
            SqlParameter direccionParameter = new SqlParameter();
            direccionParameter.DbType = DbType.String;
            direccionParameter.Direction = ParameterDirection.Input;
            direccionParameter.ParameterName = "@Direccion";
            direccionParameter.Value = persona.Direccion ?? Convert.DBNull;
            parameters.Add(direccionParameter);

            // Nif
            SqlParameter nifParameter = new SqlParameter();
            nifParameter.DbType = DbType.String;
            nifParameter.Direction = ParameterDirection.Input;
            nifParameter.ParameterName = "@Nif";
            nifParameter.Value = persona.Nif ?? Convert.DBNull;
            parameters.Add(nifParameter);

            // FechaNacimiento
            SqlParameter fechaNacimientoParameter = new SqlParameter();
            fechaNacimientoParameter.DbType = DbType.DateTime;
            fechaNacimientoParameter.Direction = ParameterDirection.Input;
            fechaNacimientoParameter.ParameterName = "@FechaNacimiento";
            fechaNacimientoParameter.Value = persona.FechaNacimiento.ToString("yyyy-MM-dd HH:mm:ss") ?? Convert.DBNull;
            parameters.Add(fechaNacimientoParameter);

            // IdPoblacion

            SqlParameter idPoblacionParameter = new SqlParameter();
            idPoblacionParameter.DbType = DbType.Int32;
            idPoblacionParameter.Direction = ParameterDirection.Input;
            idPoblacionParameter.ParameterName = "@IdPoblacion";
            if (persona.Poblacion != null)
                idPoblacionParameter.Value = persona.Poblacion.Id;
            else
                idPoblacionParameter.Value = DBNull.Value;
            parameters.Add(idPoblacionParameter);


            // IdMunicipio

            SqlParameter idMunicipioParameter = new SqlParameter();
            idMunicipioParameter.DbType = DbType.Int32;
            idMunicipioParameter.Direction = ParameterDirection.Input;
            idMunicipioParameter.ParameterName = "@IdMunicipio";
            if (persona.Municipio != null)
                idMunicipioParameter.Value = persona.Municipio.Id;
            else
                idMunicipioParameter.Value = DBNull.Value;
            parameters.Add(idMunicipioParameter);

            // IdPais

            SqlParameter idPaisParameter = new SqlParameter();
            idPaisParameter.DbType = DbType.Int32;
            idPaisParameter.Direction = ParameterDirection.Input;
            idPaisParameter.ParameterName = "@IdPais";
            if (persona.Pais != null)
                idPaisParameter.Value = persona.Pais.Id;
            else
                idPaisParameter.Value = DBNull.Value;
            parameters.Add(idPaisParameter);

            GetData(commandText, parameters, commandType);

            persona.Id = Convert.ToInt32(idParameter.Value);

            return persona;
        }

        public int Delete(PersonaDto persona)
        {
            string commandText = "Persona_Delete";
            CommandType commandType = CommandType.StoredProcedure;
            List<SqlParameter> parameters = new List<SqlParameter>();

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.ParameterName = "@Id";
            idParameter.Value = persona.Id;
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

        public List<PersonaDto> GetAll()
        {
            string commandText = @"SELECT
Id,
Nombre,
PrimerApellido,
SegundoApellido,
Nif,
FechaNacimiento,
IdPoblacion,
IdMunicipio,
IdPais,
Telefono,
Direccion
FROM Persona";
            List<PersonaDto> personas = GetData(commandText, null);

            return personas;
        }

        public PersonaDto GetById(int id)
        {
            string commandText = @"SELECT
Id,
Nombre,
PrimerApellido,
SegundoApellido,
Nif,
FechaNacimiento,
IdPoblacion,
IdMunicipio,
IdPais,
Telefono,
Direccion
FROM Persona
WHERE Id = @Id";
            List<SqlParameter> parameters = new List<SqlParameter>();

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.ParameterName = "@Id";
            idParameter.Value = id;
            parameters.Add(idParameter);

            List<PersonaDto> personas = GetData(commandText, parameters);
            PersonaDto persona = null;

            if (personas.Count == 1)
                persona = personas[0];

            return persona;
        }

        public int Update(PersonaDto persona)
        {
            string commandText = "Persona_Update";
            CommandType commandType = CommandType.StoredProcedure;
            List<SqlParameter> parameters = new List<SqlParameter>();

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.ParameterName = "@Id";
            idParameter.Value = persona.Id;
            parameters.Add(idParameter);

            // Nombre
            SqlParameter nombreParameter = new SqlParameter();
            nombreParameter.DbType = DbType.String;
            nombreParameter.Direction = ParameterDirection.Input;
            nombreParameter.ParameterName = "@Nombre";
            nombreParameter.Value = persona.Nombre ?? Convert.DBNull;
            parameters.Add(nombreParameter);

            // PrimerApellido
            SqlParameter primerApellidoParameter = new SqlParameter();
            primerApellidoParameter.DbType = DbType.String;
            primerApellidoParameter.Direction = ParameterDirection.Input;
            primerApellidoParameter.ParameterName = "@PrimerApellido";
            primerApellidoParameter.Value = persona.PrimerApellido ?? Convert.DBNull;
            parameters.Add(primerApellidoParameter);

            // SegundoApellido
            SqlParameter segundoApellidoParameter = new SqlParameter();
            segundoApellidoParameter.DbType = DbType.String;
            segundoApellidoParameter.Direction = ParameterDirection.Input;
            segundoApellidoParameter.ParameterName = "@SegundoApellido";
            segundoApellidoParameter.Value = persona.SegundoApellido ?? Convert.DBNull;
            parameters.Add(segundoApellidoParameter);

            // Telefono
            SqlParameter telefonoParameter = new SqlParameter();
            telefonoParameter.DbType = DbType.String;
            telefonoParameter.Direction = ParameterDirection.Input;
            telefonoParameter.ParameterName = "@Telefono";
            telefonoParameter.Value = persona.Telefono ?? Convert.DBNull;
            parameters.Add(telefonoParameter);

            // Direccion
            SqlParameter direccionParameter = new SqlParameter();
            direccionParameter.DbType = DbType.String;
            direccionParameter.Direction = ParameterDirection.Input;
            direccionParameter.ParameterName = "@Direccion";
            direccionParameter.Value = persona.Direccion ?? Convert.DBNull;
            parameters.Add(direccionParameter);

            // Nif
            SqlParameter nifParameter = new SqlParameter();
            nifParameter.DbType = DbType.String;
            nifParameter.Direction = ParameterDirection.Input;
            nifParameter.ParameterName = "@Nif";
            nifParameter.Value = persona.Nif ?? Convert.DBNull;
            parameters.Add(nifParameter);

            // FechaNacimiento
            SqlParameter fechaNacimientoParameter = new SqlParameter();
            fechaNacimientoParameter.DbType = DbType.DateTime;
            fechaNacimientoParameter.Direction = ParameterDirection.Input;
            fechaNacimientoParameter.ParameterName = "@FechaNacimiento";
            fechaNacimientoParameter.Value = persona.FechaNacimiento.ToString("yyyy-MM-dd HH:mm:ss") ?? Convert.DBNull;
            parameters.Add(fechaNacimientoParameter);

            // IdPoblacion

            SqlParameter idPoblacionParameter = new SqlParameter();
            idPoblacionParameter.DbType = DbType.Int32;
            idPoblacionParameter.Direction = ParameterDirection.Input;
            idPoblacionParameter.ParameterName = "@IdPoblacion";
            if (persona.Poblacion != null)
                idPoblacionParameter.Value = persona.Poblacion.Id;
            else
                idPoblacionParameter.Value = DBNull.Value;
            parameters.Add(idPoblacionParameter);


            // IdMunicipio

            SqlParameter idMunicipioParameter = new SqlParameter();
            idMunicipioParameter.DbType = DbType.Int32;
            idMunicipioParameter.Direction = ParameterDirection.Input;
            idMunicipioParameter.ParameterName = "@IdMunicipio";
            if (persona.Municipio != null)
                idMunicipioParameter.Value = persona.Municipio.Id;
            else
                idMunicipioParameter.Value = DBNull.Value;
            parameters.Add(idMunicipioParameter);

            // IdPais

            SqlParameter idPaisParameter = new SqlParameter();
            idPaisParameter.DbType = DbType.Int32;
            idPaisParameter.Direction = ParameterDirection.Input;
            idPaisParameter.ParameterName = "@IdPais";
            if (persona.Pais != null)
                idPaisParameter.Value = persona.Pais.Id;
            else
                idPaisParameter.Value = DBNull.Value;
            parameters.Add(idPaisParameter);

            // AffectedRows
            SqlParameter affectedRowsParameter = new SqlParameter();
            affectedRowsParameter.DbType = DbType.Int32;
            affectedRowsParameter.Direction = ParameterDirection.Output;
            affectedRowsParameter.ParameterName = "@AffectedRows";
            parameters.Add(affectedRowsParameter);

            GetData(commandText, parameters, commandType);

            return Convert.ToInt32(affectedRowsParameter.Value);
        }

        protected override PersonaDto MapDataReader(SqlDataReader dr)
        {
            PersonaDto persona = new PersonaDto()
            {
                Id = Convert.ToInt32(dr["Id"]),
                Nombre = dr["Nombre"] != null ? (string)dr["Nombre"] : null,
                PrimerApellido = dr["PrimerApellido"] != null ? (string)dr["PrimerApellido"] : null,
                SegundoApellido = dr["SegundoApellido"] != null ? (string)dr["SegundoApellido"] : null,
                Nif = dr["Nif"] != null ? (string)dr["Nif"] : null,
                FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]),
                Telefono = dr["Telefono"] != null ? (string)dr["Telefono"] : null,
                Direccion = dr["Direccion"] != null ? (string)dr["Direccion"] : null
            };
            if (dr["IdPoblacion"] != DBNull.Value)
            {
                persona.Poblacion = new PoblacionDto() { Id = Convert.ToInt32(dr["IdPoblacion"]) };
            }
            if (dr["IdMunicipio"] != DBNull.Value)
            {
                persona.Municipio = new MunicipioDto() { Id = Convert.ToInt32(dr["IdMunicipio"]) };
            }
            if (dr["IdPais"] != DBNull.Value)
            {
                persona.Pais = new PaisDto() { Id = Convert.ToInt32(dr["IdPais"]) };
            }

            return persona;
        }
    }
}
