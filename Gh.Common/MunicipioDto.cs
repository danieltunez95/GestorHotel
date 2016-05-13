namespace Gh.Common
{
    public class MunicipioDto : BaseDto
    { 
        public ProvinciaDto Provincia { get; set; }

        public MunicipioDto(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public MunicipioDto()
        {

        }
    }
}
