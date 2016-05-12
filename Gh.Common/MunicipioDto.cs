namespace Gh.Common
{
    public class MunicipioDto : BaseDto
    { 
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
