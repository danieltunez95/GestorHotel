using GestorHotel.Common;
using System.Collections.Generic;

namespace GestorHotel.Dao
{
    public class EmpleadoDao : IDao<Empleado>
    {
        public Empleado Add(Empleado adding)
        {
            string storedProcedure = "Empleado_Add";
            return adding;
        }

        public int Delete(Empleado deleting)
        {
            string storedProcedure = "Empleado_Delete";
            int result = 0;
            return result;
        }

        public List<Empleado> GetAll()
        {
            string commandText = @"SELECT guid, id, nombre, apellido1, apellido2, fecha_inicio, fecha_nacimiento, id_oficio
                                   FROM empleado";
            List<Empleado> empleados = new List<Empleado>();
            return empleados;
        }

        public Empleado GetById(int id)
        {
            string commandText = @"SELECT guid, id, nombre, apellido1, apellido2, fecha_inicio, fecha_nacimiento, id_oficio
                                   FROM empleado
                                   WHERE id = @pID";
            Empleado empleado = new Empleado();
            return empleado;
        }

        public int Update(Empleado updating)
        {
            string storedProcedure = "Empleado_Update";
            int result = 0;
            return result;
        }
    }
}
