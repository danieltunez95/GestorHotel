namespace Gh.Common
{
    public class HabitacionDto : BaseDto
    {
        public int PosicionX { get; set; }

        public int PosicionY { get; set; }

        public int planta { get; set; }

        public double MetrosCuadrados { get; set; }

        public int Camas { get; set; }

        public int Dormitorios { get; set; }

        public string Descripcion { get; set; }
    }
}
