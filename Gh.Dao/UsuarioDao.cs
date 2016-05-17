using Gh.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Gh.Dao
{
    public class UsuarioDao : BaseDao<UsuarioDto>, IDao<UsuarioDto>
    {
        public List<UsuarioDto> GetAll()
        {
            string commandText = @"SELECT Id,
Username,
Password,
Role,
MinHour,
MaxHour
FROM Usuario";
            List<UsuarioDto> usuarios = GetData(commandText, null);

            return usuarios;
        }

        public UsuarioDto GetById(int id)
        {
            string commandText = @"SELECT Id,
Username,
Password,
Role,
MinHour,
MaxHour
FROM Usuario
WHERE Id = @Id";
            List<SqlParameter> parameters = new List<SqlParameter>();

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.ParameterName = "@Id";
            idParameter.Value = id;
            parameters.Add(idParameter);

            List<UsuarioDto> usuarios = GetData(commandText, parameters);
            UsuarioDto usuario = null;

            if (usuarios.Count == 1)
                usuario = usuarios[0];

            return usuario;
        }

        public UsuarioDto GetByUsername(string username)
        {
            string commandText = @"SELECT Id,
Username,
Password,
Role,
MinHour,
MaxHour
FROM Usuario
WHERE Username = @Username";
            List<SqlParameter> parameters = new List<SqlParameter>();

            // Username
            SqlParameter usernameParameter = new SqlParameter();
            usernameParameter.DbType = DbType.String;
            usernameParameter.Direction = ParameterDirection.Input;
            usernameParameter.ParameterName = "@Username";
            usernameParameter.Value = username;
            parameters.Add(usernameParameter);

            List<UsuarioDto> usuarios = GetData(commandText, parameters);
            UsuarioDto usuario = null;

            if (usuarios.Count == 1)
                usuario = usuarios[0];

            return usuario;
        }

        public UsuarioDto Add(UsuarioDto usuario)
        {
            string commandText = "Usuario_Add";
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
            usernameParameter.Value = usuario.Username;
            parameters.Add(usernameParameter);

            // Password
            SqlParameter passwordParameter = new SqlParameter();
            passwordParameter.DbType = DbType.String;
            passwordParameter.Direction = ParameterDirection.Input;
            passwordParameter.ParameterName = "@Password";
            passwordParameter.Value = usuario.Password;
            parameters.Add(passwordParameter);

            // Role
            SqlParameter roleParameter = new SqlParameter();
            roleParameter.DbType = DbType.Int32;
            roleParameter.Direction = ParameterDirection.Input;
            roleParameter.ParameterName = "@Role";
            roleParameter.Value = usuario.Role;
            parameters.Add(roleParameter);

            // MinHour
            SqlParameter minHourParameter = new SqlParameter();
            minHourParameter.DbType = DbType.Double;
            minHourParameter.Direction = ParameterDirection.Input;
            minHourParameter.ParameterName = "@MinHour";
            minHourParameter.Value = usuario.MinHour;
            parameters.Add(minHourParameter);

            // MaxHour
            SqlParameter maxHourParameter = new SqlParameter();
            maxHourParameter.DbType = DbType.Double;
            maxHourParameter.Direction = ParameterDirection.Input;
            maxHourParameter.ParameterName = "@MaxHour";
            maxHourParameter.Value = usuario.MaxHour;
            parameters.Add(maxHourParameter);

            GetData(commandText, parameters, commandType);

            usuario.Id = Convert.ToInt32(idParameter.Value);

            return usuario;
        }

        public int Update(UsuarioDto usuario)
        {
            string commandText = "Usuario_Update";
            CommandType commandType = CommandType.StoredProcedure;
            List<SqlParameter> parameters = new List<SqlParameter>();

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.ParameterName = "@Id";
            idParameter.Value = usuario.Id;
            parameters.Add(idParameter);

            // Username
            SqlParameter usernameParameter = new SqlParameter();
            usernameParameter.DbType = DbType.String;
            usernameParameter.Direction = ParameterDirection.Input;
            usernameParameter.ParameterName = "@Username";
            usernameParameter.Value = usuario.Username;
            parameters.Add(usernameParameter);

            // Password
            SqlParameter passwordParameter = new SqlParameter();
            passwordParameter.DbType = DbType.String;
            passwordParameter.Direction = ParameterDirection.Input;
            passwordParameter.ParameterName = "@Password";
            passwordParameter.Value = usuario.Password;
            parameters.Add(passwordParameter);

            // Role
            SqlParameter roleParameter = new SqlParameter();
            roleParameter.DbType = DbType.Int32;
            roleParameter.Direction = ParameterDirection.Input;
            roleParameter.ParameterName = "@Role";
            roleParameter.Value = usuario.Role;
            parameters.Add(roleParameter);

            // MinHour
            SqlParameter minHourParameter = new SqlParameter();
            minHourParameter.DbType = DbType.Double;
            minHourParameter.Direction = ParameterDirection.Input;
            minHourParameter.ParameterName = "@MinHour";
            minHourParameter.Value = usuario.MinHour;
            parameters.Add(minHourParameter);

            // MaxHour
            SqlParameter maxHourParameter = new SqlParameter();
            maxHourParameter.DbType = DbType.Double;
            maxHourParameter.Direction = ParameterDirection.Input;
            maxHourParameter.ParameterName = "@MaxHour";
            maxHourParameter.Value = usuario.MaxHour;
            parameters.Add(maxHourParameter);

            // AffectedRows
            SqlParameter affectedRowsParameter = new SqlParameter();
            affectedRowsParameter.DbType = DbType.Int32;
            affectedRowsParameter.Direction = ParameterDirection.Output;
            affectedRowsParameter.ParameterName = "@AffectedRows";
            affectedRowsParameter.Value = 0;
            parameters.Add(affectedRowsParameter);

            GetData(commandText, parameters, commandType);

            return Convert.ToInt32(affectedRowsParameter.Value);
        }

        public int Delete(UsuarioDto usuario)
        {
            string commandText = "Usuario_Delete";
            CommandType commandType = CommandType.StoredProcedure;
            List<SqlParameter> parameters = new List<SqlParameter>();

            // Id
            SqlParameter idParameter = new SqlParameter();
            idParameter.DbType = DbType.Int32;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.ParameterName = "@Id";
            idParameter.Value = usuario.Id;
            parameters.Add(idParameter);

            // AffectedRows
            SqlParameter affectedRowsParameter = new SqlParameter();
            affectedRowsParameter.DbType = DbType.Int32;
            affectedRowsParameter.Direction = ParameterDirection.Output;
            affectedRowsParameter.ParameterName = "@AffectedRows";
            affectedRowsParameter.Value = 0;
            parameters.Add(affectedRowsParameter);

            GetData(commandText, parameters, commandType);

            return Convert.ToInt32(affectedRowsParameter.Value);
        }

        protected override UsuarioDto MapDataReader(SqlDataReader dr)
        {
            Role role = (Role)Enum.Parse(typeof(Role), dr["Role"].ToString());
            UsuarioDto usuario = new UsuarioDto()
            {
                Id = Convert.ToInt32(dr["Id"]),
                Username = dr["Username"] != null ? (string)dr["Username"] : null,
                Password = dr["Password"] != null ? (string)dr["Password"] : null,
                Role = role
            };
            if (Convert.ToString(dr["MinHour"]) != null)
                usuario.MinHour = float.Parse(Convert.ToString(dr["MinHour"]));
            if (Convert.ToString(dr["MaxHour"]) != null)
                usuario.MaxHour = float.Parse(Convert.ToString(dr["MaxHour"]));
            return usuario;
        }
    }
}
