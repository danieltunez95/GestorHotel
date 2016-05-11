using Gh.Common;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Gh.Dao
{
    public class EmpleadoDao : IDao<EmpleadoDto>
    {
        string connectionString;

        public EmpleadoDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public EmpleadoDto Add(EmpleadoDto entity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    StringBuilder query = new StringBuilder();
                    query.Append("INSERT INTO ");
                }
            }
            return entity;
        }

        public int Delete(EmpleadoDto entity)
        {
            string commandText = "Empleado_Delete";
            int result = 0;
            return result;
        }

        public List<EmpleadoDto> GetAll()
        {
            List<EmpleadoDto> empleados = new List<EmpleadoDto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM empleado";
                    SqlDataReader reader = null;
                    reader = command.ExecuteReader();


                }
            }
            return empleados;
        }

        public EmpleadoDto GetById(int id)
        {
            string commandText = @"SELECT guid, id, nombre, apellido1, apellido2, fecha_inicio, fecha_nacimiento, id_oficio
                                   FROM empleado
                                   WHERE id = @pID";
            EmpleadoDto empleado = new EmpleadoDto();
            return empleado;
        }

        public int Update(EmpleadoDto entity)
        {
            string commandText = "Empleado_Update";
            int result = 0;
            return result;
        }
    }
}
