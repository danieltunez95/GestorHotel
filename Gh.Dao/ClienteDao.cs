using Gh.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Gh.Dao
{
    public class ClienteDao : BaseDao<ClienteDto>, IDao<ClienteDto>
    {
        public ClienteDto Add(ClienteDto cliente)
        {
            string commandText = "Cliente_Add";
            CommandType commandType = CommandType.StoredProcedure;
            List<SqlParameter> parameters = new List<SqlParameter>();

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Output;
            idParameter.ParameterName = "@Id";
            parameters.Add(idParameter);

            // Username
            SqlParameter usernameParameter = new SqlParameter();
            usernameParameter.DbType = DbType.String;
            usernameParameter.Direction = ParameterDirection.Input;
            usernameParameter.ParameterName = "@Username";
            usernameParameter.Value = cliente.Username ?? Convert.DBNull;
            parameters.Add(usernameParameter);

            // Email
            SqlParameter emailParameter = new SqlParameter();
            emailParameter.DbType = DbType.String;
            emailParameter.Direction = ParameterDirection.Input;
            emailParameter.ParameterName = "@Email";
            emailParameter.Value = cliente.Correo ?? Convert.DBNull;
            parameters.Add(emailParameter);

            // Password
            SqlParameter passwordParameter = new SqlParameter();
            passwordParameter.DbType = DbType.String;
            passwordParameter.Direction = ParameterDirection.Input;
            passwordParameter.ParameterName = "@Password";
            passwordParameter.Value = cliente.Password ?? Convert.DBNull;
            parameters.Add(passwordParameter);

            // Telefono
            SqlParameter telefonoParameter = new SqlParameter();
            telefonoParameter.DbType = DbType.String;
            telefonoParameter.Direction = ParameterDirection.Input;
            telefonoParameter.ParameterName = "@Telefono";
            telefonoParameter.Value = cliente.Telefono ?? Convert.DBNull;
            parameters.Add(telefonoParameter);

            // IdPersona
            SqlParameter idPersonaParameter = new SqlParameter();
            idPersonaParameter.DbType = DbType.Int32;
            idPersonaParameter.Direction = ParameterDirection.Input;
            idPersonaParameter.ParameterName = "@IdPersona";
            if (cliente.Persona != null)
                idPersonaParameter.Value = cliente.Persona.Id;
            else
                idPersonaParameter.Value = Convert.DBNull;
            parameters.Add(idPersonaParameter);

            GetData(commandText, parameters, commandType);

            cliente.Id = Convert.ToInt32(idParameter.Value);

            return cliente;
        }

        public int Delete(ClienteDto cliente)
        {
            string commandText = "Cliente_Delete";
            CommandType commandType = CommandType.StoredProcedure;

            List<SqlParameter> parameters = new List<SqlParameter>();

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.ParameterName = "@Id";
            idParameter.Value = cliente.Id;
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

        public List<ClienteDto> GetAll()
        {
            string commandText = @"SELECT
Id,
Username,
Email,
Password,
Telefono,
IdPersona
FROM Cliente";
            List<ClienteDto> clientes = GetData(commandText, null);

            return clientes;
        }

        public ClienteDto GetById(int id)
        {
            string commandText = @"SELECT
Id,
Username,
Email,
Password,
Telefono,
IdPersona
FROM Cliente
WHERE Id = @Id";
            List<SqlParameter> parameters = new List<SqlParameter>();

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.ParameterName = "@Id";
            idParameter.Value = id;
            parameters.Add(idParameter);

            List<ClienteDto> clientes = GetData(commandText, parameters);
            ClienteDto cliente = null;

            if (clientes.Count == 1)
                cliente = clientes[0];

            return cliente;
        }

        public int Update(ClienteDto cliente)
        {
            string commandText = "Cliente_Update";
            CommandType commandType = CommandType.StoredProcedure;
            List<SqlParameter> parameters = new List<SqlParameter>();

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.ParameterName = "@Id";
            idParameter.Value = cliente.Id;
            parameters.Add(idParameter);

            // Username
            SqlParameter usernameParameter = new SqlParameter();
            usernameParameter.DbType = DbType.String;
            usernameParameter.Direction = ParameterDirection.Input;
            usernameParameter.ParameterName = "@Username";
            usernameParameter.Value = cliente.Username;
            parameters.Add(usernameParameter);

            // Email
            SqlParameter emailParameter = new SqlParameter();
            emailParameter.DbType = DbType.String;
            emailParameter.Direction = ParameterDirection.Input;
            emailParameter.ParameterName = "@Email";
            emailParameter.Value = cliente.Correo;
            parameters.Add(emailParameter);

            // Password
            SqlParameter passwordParameter = new SqlParameter();
            passwordParameter.DbType = DbType.String;
            passwordParameter.Direction = ParameterDirection.Input;
            passwordParameter.ParameterName = "@Password";
            passwordParameter.Value = cliente.Password;
            parameters.Add(passwordParameter);

            // Telefono
            SqlParameter telefonoParameter = new SqlParameter();
            telefonoParameter.DbType = DbType.String;
            telefonoParameter.Direction = ParameterDirection.Input;
            telefonoParameter.ParameterName = "@Telefono";
            telefonoParameter.Value = cliente.Telefono;
            parameters.Add(telefonoParameter);

            // IdPersona
            SqlParameter idPersonaParameter = new SqlParameter();
            idPersonaParameter.DbType = DbType.Int32;
            idPersonaParameter.Direction = ParameterDirection.Input;
            idPersonaParameter.ParameterName = "@IdPersona";
            idPersonaParameter.Value = cliente.Persona.Id;
            parameters.Add(idPersonaParameter);

            // AffectedRows
            SqlParameter affectedRowsParameter = new SqlParameter();
            affectedRowsParameter.DbType = DbType.Int32;
            affectedRowsParameter.Direction = ParameterDirection.Output;
            affectedRowsParameter.ParameterName = "@AffectedRows";
            parameters.Add(affectedRowsParameter);

            GetData(commandText, parameters, commandType);

            return Convert.ToInt32(affectedRowsParameter.Value);
        }

        protected override ClienteDto MapDataReader(SqlDataReader dr)
        {
            ClienteDto cliente = new ClienteDto()
            {
                Id = Convert.ToInt32(dr["Id"]),
                Correo = dr["Email"] != null ? (string)dr["Email"] : null,
                Username = dr["Username"] != null ? (string)dr["Username"] : null,
                Password = dr["Password"] != null ? (string)dr["Password"] : null,
                Telefono = dr["Telefono"] != null ? (string)dr["Telefono"] : null
            };
            if (dr["IdPersona"] != DBNull.Value)
            {
                cliente.Persona = new PersonaDto() { Id = Convert.ToInt32(dr["IdPersona"]) };
            }                

            return cliente;
        }
    }
}
