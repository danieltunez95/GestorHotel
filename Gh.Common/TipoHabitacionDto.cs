namespace Gh.Common
{
    public class TipoHabitacionDto : BaseDto
    {
        public int? MetrosCuadrados { get; set; }

        public string Descripcion { get; set; }

        public string Imagen { get; set; }

        public decimal? Precio { get; set; }
    }
}
