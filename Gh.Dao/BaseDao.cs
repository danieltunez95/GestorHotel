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

        //public void GetData(string commandText, string commandType, List<SqlParameter> parameters)
        //{
        //    using (SqlConnection connection = new SqlConnection("Server=tcp:gestorhotel.database.windows.net,1433;Database=GestorHotel;User ID=hoteladmin@gestorhotel;Password=Abcd1234;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30"))
        //    {
        //        using (SqlCommand command = new SqlCommand())
        //        {
        //            SqlDataReader reader;
        //            command.CommandText = commandText;
        //            command.CommandType = (CommandType)Enum.Parse(typeof(CommandType), commandType);
        //            foreach (SqlParameter param in parameters)
        //            {
        //                command.Parameters.Add(param);
        //            }

        //            command.Connection = connection;
        //            connection.Open();
        //            reader = command.ExecuteReader();
        //        }
        //    }
        //}

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

        protected abstract T MapDataReader(SqlDataReader dr);



    }

}