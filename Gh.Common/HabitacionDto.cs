namespace Gh.Common
{
    public class HabitacionDto : BaseDto
    {
        public int PosicionX { get; set; }

        public int PosicionY { get; set; }

        public int Planta { get; set; }

        public int HotelId { get; set; }

        public bool Ocupada { get; set; }

        public TipoHabitacionDto TipoHabitacion { get; set; }
    }
}
