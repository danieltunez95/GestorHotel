namespace Gh.Common
{
    public class ClienteDto : BaseDto
    {
        public string Correo { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Telefono { get; set; }

        public PersonaDto Persona { get; set; }
    }
}
