namespace Gh.Common
{
    public class UsuarioDto : BaseDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public float? MinHour { get; set; }
        public float? MaxHour { get; set; }

        /* DATABASE */
        public static string DBName
        {
            get
            {
                return "Usuario";
            }
        }
    }
}
