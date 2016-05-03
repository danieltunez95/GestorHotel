using Gh.Common;
using System.Collections.Generic;

namespace Gh.Dao
{
    public class EmpleadoDao : IDao<EmpleadoDto>
    {
        public EmpleadoDto Add(EmpleadoDto entity)
        {
            string storedProcedure = "Empleado_Add";
            return entity;
        }

        public int Delete(EmpleadoDto entity)
        {
            string storedProcedure = "Empleado_Delete";
            int result = 0;
            return result;
        }

        public List<EmpleadoDto> GetAll()
        {
            string commandText = @"SELECT guid, id, nombre, apellido1, apellido2, fecha_inicio, fecha_nacimiento, id_oficio
                                   FROM empleado";
            List<EmpleadoDto> empleados = new List<EmpleadoDto>();
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
            string storedProcedure = "Empleado_Update";
            int result = 0;
            return result;
        }
    }
}
