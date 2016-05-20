using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gh.Dao
{
    public abstract class BaseDao<T>
    {
        public SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(AppConfigReader.GetConnectionString());

            conn.Open();

            return conn;
        }

        protected virtual List<T> GetData(string commandText, List<SqlParameter> parameters)
        {
            List<T> dtos = GetData(commandText, parameters, CommandType.Text);
            return dtos;
        }

        protected virtual List<T> GetData(string commandText, List<SqlParameter> parameters, CommandType commandType)
        {
            List<T> dtos = new List<T>();
            using (SqlConnection conn = this.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand() { CommandText = commandText, CommandType = commandType, Connection = conn })
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.Clear();
                        foreach (SqlParameter parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                    }
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            T dto = MapDataReader(dr);
                            dtos.Add(dto);
                        }
                    }
                }
                return dtos;
            }
        }

        protected virtual string GetDataScalar(string commandText, List<SqlParameter> parameters, CommandType commandType)
        {
            string result;
            using (SqlConnection conn = this.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand() { CommandText = commandText, CommandType = commandType, Connection = conn })
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.Clear();
                        foreach (SqlParameter parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                    }
                    dynamic test = cmd.ExecuteScalar();
                    result = cmd.ExecuteScalar() != null ? cmd.ExecuteScalar().ToString() : null;
                }
                return result;
            }
        }

        protected abstract T MapDataReader(SqlDataReader dr);



    }

}