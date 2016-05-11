namespace Gh.Common
{
    public class HabitacionDto : BaseDto
    {
        public int PosicionX { get; set; }

        public int PosicionY { get; set; }

        public int Planta { get; set; }

        public double MetrosCuadrados { get; set; }

        public int Camas { get; set; }

        public CamaEnum TipoCama { get; set; }

        public int Dormitorios { get; set; }

        public string Descripcion { get; set; }

        public double Precio { get; set; }

        public HotelDto Hotel { get; set; }

        public string Imagen { get; set; }
    }
}
